using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TFEasyPrefabBrowser : EditorWindow
{
    // THE EDITOR WINDOW INITIALIZATION AND DRAWING

    #region " PROPERTIES "

    private bool canRender = true;
    private bool initialize = true;

    struct SPagination
    {
        public int page;
        public int fromIndex;
        public int toIndex;
        public int last;
        public int totalPages;

        public bool goBack;
        public bool goNext;
        public string infos;

        public int size;
    }

    struct SMouse
    {
        public List<Rect> positions;
    }

    private List<GameObject> prefabs = new List<GameObject>();
    private List<Texture> textures = new List<Texture>();
    private string folder;

    private List<Editor> gameObjectEditors = new List<Editor>();

    private int spaceH = 2;
    private int spaceV = 20;
    Vector2 scrollPos;
    private int tab = 0;

    public enum ECOLORS
    {
        Dark = 0,
        Medium = 1,
        Light = 2,
        Green = 3,
        Blue = 4,
        Magenta = 5
    }

    public enum ESIZEMODE
    {
        ByItemSize = 0,
        ByColumnsNumber = 1
    }

    public ECOLORS op = ECOLORS.Medium;
    public ESIZEMODE mode = ESIZEMODE.ByColumnsNumber;
    public int itemWidth = 100;
    public int columns = 3;
    public string filter = "*";
    public int totalItems = 0;
    public bool showItemNumber = true;
    public bool useInteractivePreview = true;
    public bool showBorders = true;
    public bool loadModels = false;
    public bool rememberLastFolder = true;
    public string lastFolder = "";

    private SPagination pagination;
    private SMouse mouse;
    private int loadedPrefabs = 0;
    private string objectTypeLoading = "";

    private GUIStyle stylePagination;
    private GUIStyle styleLabel;
    private GUIStyle styleNumber;
    private Rect workArea;
    private Color32 colorMedium;
    private Color32 colorLight;
    private Color32 colorGreen;
    private Color32 colorBlue;
    private Color32 colorMagenta;
    private Color colorBorder;

    private static TFEasyPrefabBrowser window;

    private string warning = "";

    #endregion


    #region " EDITOR WINDOW INITIALIZATION "

    // Builds the "Easy Prefab Browser" window and makes it available in the Unity "Window" menu.

    [MenuItem("Window/TigerForge/Easy Prefabs Browser 2.0")]
    static void Init()
    {
        window = (TFEasyPrefabBrowser)EditorWindow.GetWindow(typeof(TFEasyPrefabBrowser));
        var content = EditorGUIUtility.IconContent("d_GridLayoutGroup Icon");
        content.text = " Easy Prefabs Browser 2.0";
        window.titleContent = content;
        window.Show();
    }

    void OnEnable()
    {
        if (window != null)
        {
            var content = EditorGUIUtility.IconContent("d_GridLayoutGroup Icon");
            content.text = " Easy Prefabs Browser 2.0";
            window.titleContent = content;
        }
    }

    /// <summary>
    /// Initialize styles, labels and other fixed elements that should be done just once.
    /// </summary>
    void Initialize()
    {
        stylePagination = Style(Color.white, 10, TextAnchor.MiddleCenter);

        styleLabel = new GUIStyle("label");
        styleLabel.alignment = TextAnchor.UpperCenter;
        styleLabel.normal.textColor = new Color(1, 1, 1, 0.8f);
        styleLabel.fontSize = 10;

        styleNumber = Style(new Color(1, 1, 1, 0.8f), 10, TextAnchor.UpperLeft);

        colorMedium = new Color32(52, 52, 52, 100);
        colorLight = Color.grey;
        colorGreen = new Color32(0, 117, 64, 100);
        colorBlue = new Color32(0, 71, 187, 100);
        colorMagenta = new Color32(255, 0, 144, 100);

        colorBorder = new Color(1, 1, 1, 0.5f);

        initialize = false;
    }

    #endregion


    #region " EDITOR WINDOW DRAWING (OnGUI) "

    void OnGUI()
    {
        if (initialize) Initialize();

        DrawTabs();

        switch (tab)
        {
            case 0:

                DrawTabBrowser();

                Event e = Event.current;
                if (e.isMouse) OnMouseClick(e);
                break;

            case 1:

                DrawTabSettings();
                break;

            default:
                break;
        }

        
    }

    #endregion
    

    // THE BROWSER TAB

    #region " TAB: BROWSER "

    /// <summary>
    /// Draws the Browser tab content.
    /// </summary>
    void DrawTabBrowser()
    {
        filter = EditorGUILayout.TextField(GLabel("Search filter:", "SEARCH FILTER\nFilter the Prefabs list by file name. Look at the 'Help' in the 'Settings' tab for details."), filter);

        EditorGUILayout.BeginHorizontal();
        var buttonLoadPrefabs = "LOAD PREFABS";
        if (!canRender && objectTypeLoading == "t:Prefab" && loadedPrefabs > 0) buttonLoadPrefabs = "Loading " + loadedPrefabs + " Prefabs...";
        if (GUILayout.Button(buttonLoadPrefabs)) GetPrefabList("t:Prefab");

        var buttonLoadModels = "LOAD MODELS";
        if (!canRender && objectTypeLoading == "t:Model" && loadedPrefabs > 0) buttonLoadModels = "Loading " + loadedPrefabs + " 3D Models...";
        if (GUILayout.Button(buttonLoadModels)) GetPrefabList("t:Model");

        var buttonLoadTextures = "LOAD TEXTURES";
        if (!canRender && objectTypeLoading == "t:Texture" && loadedPrefabs > 0) buttonLoadTextures = "Loading " + loadedPrefabs + " Textures...";
        if (GUILayout.Button(buttonLoadTextures)) GetPrefabList("t:Texture");

        var buttonLoadAll = "LOAD ALL";
        if (!canRender && objectTypeLoading == "t:Prefab t:Model" && loadedPrefabs > 0) buttonLoadAll = "Loading " + loadedPrefabs + " assets...";
        if (GUILayout.Button(buttonLoadAll)) GetPrefabList("t:Prefab t:Model");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        pagination.goBack = GUILayout.Button("<<");
        EditorGUILayout.LabelField(pagination.infos, stylePagination);
        pagination.goNext = GUILayout.Button(">>");
        EditorGUILayout.EndHorizontal();

        if (warning != "")
        {
            EditorGUILayout.HelpBox(warning, MessageType.Warning);
        }

        if (pagination.size < 1 || pagination.size > 60) pagination.size = 10;
        pagination.totalPages = (int)Mathf.Ceil((float)totalItems / pagination.size);

        if (pagination.goBack)
        {
            pagination.page--;
            if (pagination.page < 0) pagination.page = 0;
            scrollPos.y = 0;
        }

        if (pagination.goNext)
        {
            pagination.page++;
            if (pagination.page >= pagination.totalPages) pagination.page = pagination.totalPages - 1;
            scrollPos.y = 0;
        }

        if (prefabs.Count > 0 && canRender)
        {
            var itemSize = itemWidth;
            var cols = Mathf.Floor((position.width - 12) / (itemSize + spaceH));
            if (mode == ESIZEMODE.ByColumnsNumber)
            {
                cols = columns;
                itemSize = (int)Mathf.Floor((position.width - 12) / cols) - spaceH;
            }

            var maxWidth = (itemSize + spaceH) * cols;
            var maxHeight = ((Mathf.Min(prefabs.Count, pagination.size) / cols) * (itemSize + spaceV)) + pagination.size;
            var startX = 10;
            var x = startX;
            var y = 64;

            pagination.infos = "Page " + (pagination.page + 1) + " of " + pagination.totalPages + " (Total: " + totalItems + " assets)";

            workArea = GUILayoutUtility.GetRect(10, 10000, 10, 10000);
            scrollPos = GUI.BeginScrollView(workArea, scrollPos, new Rect(6, 60, maxWidth, maxHeight));

            Color background = Color.black;
            if (op == ECOLORS.Medium) background = colorMedium;
            if (op == ECOLORS.Light) background = colorLight;
            if (op == ECOLORS.Green) background = colorGreen;
            if (op == ECOLORS.Blue) background = colorBlue;
            if (op == ECOLORS.Magenta) background = colorMagenta;

            pagination.fromIndex = pagination.page * pagination.size;
            pagination.toIndex = pagination.fromIndex + pagination.size;
            if (pagination.toIndex >= totalItems) pagination.toIndex = totalItems;

            if (pagination.page != pagination.last)
            {
                foreach (var ed in gameObjectEditors) DestroyImmediate(ed);
                gameObjectEditors = new List<Editor>();
            }

            Editor gameObjectEditor = null;
            var counter = 0;
            mouse.positions = new List<Rect>();
            var gameObjectEditorsLength = gameObjectEditors.Count;

            for (var i = pagination.fromIndex; i < pagination.toIndex; i++)
            {
                if (pagination.page != pagination.last)
                {
                    if (objectTypeLoading == "t:Texture") {
                        gameObjectEditor = Editor.CreateEditor(textures[i]);
                    } else {
                        gameObjectEditor = Editor.CreateEditor(prefabs[i]);
                    }
                   
                    gameObjectEditors.Add(gameObjectEditor);
                }
                else
                {
                    if (counter >= gameObjectEditorsLength)
                    {
                        pagination.page = 0;
                        return;
                    }
                    gameObjectEditor = gameObjectEditors[counter];
                    counter++;
                }

                Rect rectPrefab = new Rect(x, y, itemSize, itemSize);
                GUIStyle gStyle = new GUIStyle();
                gStyle.normal.background = MakeTex(itemSize, itemSize, background);
                mouse.positions.Add(new Rect(x, y, itemSize, itemSize));
                if (useInteractivePreview) gameObjectEditor.OnInteractivePreviewGUI(rectPrefab, gStyle); else gameObjectEditor.OnPreviewGUI(rectPrefab, gStyle);

                Rect labelBgRect = new Rect(x, y + itemSize, itemSize, spaceV - 2);
                EditorGUI.DrawRect(labelBgRect, new Color(0, 0, 0, 0.6f));

                Rect labelRect = new Rect(x + 2, y + itemSize, itemSize - 4, spaceV);

                if (objectTypeLoading == "t:Texture")
                {
                    GUIContent label = new GUIContent(textures[i].name, textures[i].name);
                    EditorGUI.LabelField(labelRect, label, styleLabel);
                }
                else
                {
                    GUIContent label = new GUIContent(prefabs[i].name, prefabs[i].name);
                    EditorGUI.LabelField(labelRect, label, styleLabel);
                }
                

                if (showBorders)
                {
                    EditorGUI.DrawRect(new Rect(rectPrefab.x, rectPrefab.y, rectPrefab.width, 1), colorBorder);
                    EditorGUI.DrawRect(new Rect(labelBgRect.x, labelBgRect.y + labelBgRect.height - 1, labelBgRect.width, 1), colorBorder);
                    EditorGUI.DrawRect(new Rect(rectPrefab.x, rectPrefab.y, 1, rectPrefab.height + labelBgRect.height), colorBorder);
                    EditorGUI.DrawRect(new Rect(rectPrefab.x + rectPrefab.width - 1, rectPrefab.y, 1, rectPrefab.height + labelBgRect.height), colorBorder);
                }

                if (showItemNumber)
                {
                    EditorGUI.LabelField(new Rect(x + 2, y, itemSize, itemSize), "" + (i + 1), styleNumber);
                }

                x += itemSize + spaceH;

                if (x > maxWidth)
                {
                    x = startX;
                    y += itemSize + spaceV;
                }

                if (i == pagination.toIndex - 1) pagination.last = pagination.page;
            }

            GUILayout.BeginArea(new Rect(6, 60, maxWidth, maxHeight));
            GUILayout.EndArea();
            GUI.EndScrollView();

        }
    }

    #endregion


    // THE SETTINGS TAB

    #region " TAB: SETTINGS "

    /// <summary>
    /// Draws the Settings tab content.
    /// </summary>
    void DrawTabSettings()
    {
        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("LIST GENERATION", Style(Color.white, 10, TextAnchor.UpperLeft, FontStyle.Bold));

        EditorGUILayout.Separator();

        mode = (ESIZEMODE)EditorGUILayout.EnumPopup(GLabel("Preview Size Mode", "PREVIEW SIZE MODE\nSet how the Prefab preview size has to be calculated.\n\nBy Item Size: use a size in pixels as specified in 'Preview Size' field.\nBy Columns Number: use the full window width divided by the value specified in 'Number of Columns' field."), mode);

        itemWidth = EditorGUILayout.IntField(GLabel("Preview Size [px]", "PREVIEW SIZE\nSpecify the width in pixels of the Prefab previews. This size is used when 'By Item Size' option is selected in the 'Preview Size Mode' menu."), itemWidth);
        columns = EditorGUILayout.IntField(GLabel("Number of Columns", "NUMBER OF COLUMNS\nSpecify in how many columns the window width has to be divided, in order to resize the Prefab previews. This value is used when 'By Columns Number' option is selected in the 'Preview Size Mode' menu."), columns);

        if (itemWidth < 50) itemWidth = 50;
        if (columns < 1) columns = 1;
        if (columns > 10) columns = 10;

        pagination.size = EditorGUILayout.IntField(GLabel("Prefabs per Page", "PREFABS PER PAGE\nSpecify the maximum number of Prefab previews to show in the window. A pagination system is automatically activated in order to show all the available Prefabs."), pagination.size);
        if (pagination.size < 1 || pagination.size > 60) pagination.size = 10;

        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("LIST ASPECT", Style(Color.white, 10, TextAnchor.UpperLeft, FontStyle.Bold));

        EditorGUILayout.Separator();

        op = (ECOLORS)EditorGUILayout.EnumPopup(GLabel("Background Color", "BACKGROUND COLOR\nChange the background color of the Prefab preview."), op);
        showItemNumber = EditorGUILayout.Toggle(GLabel("Show Item Number", "SHOW ITEM NUMBER\nShow an index number in the left top corner of each preview."), showItemNumber);
        showBorders = EditorGUILayout.Toggle(GLabel("Show Item Borders", "SHOW ITEM BORDERS\nShow a white border around each preview."), showBorders);

        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("OTHER SETTINGS", Style(Color.white, 10, TextAnchor.UpperLeft, FontStyle.Bold));

        EditorGUILayout.Separator();

        rememberLastFolder = EditorGUILayout.Toggle(GLabel("Remember Last Folder", "REMEMBER LAST FOLDER\nIf the folder containing the Assets to preview gets unselected, Easy Prefabs Browser will use the last selected folder."), rememberLastFolder);

        useInteractivePreview = EditorGUILayout.Toggle(GLabel("Interactive Previews", "INTERACTIVE PREVIEWS\nSpecify if to use Unity OnInteractivePreviewGUI or OnPreviewGUI features. See Unity manual for details."), useInteractivePreview);

        DrawHelpGuide();
    }

    #endregion


    // MOUSE EVENTS MANAGEMENT

    #region " MOUSE "

    /// <summary>
    /// When the user click the preview list...
    /// </summary>
    /// <param name="e"></param>
    void OnMouseClick(Event e)
    {
        if (e.button == 0) OnMouseLeftClick(e);
        if (e.type == EventType.MouseDown) OnMouseDown(e);
    }

    /// <summary>
    /// On left click + CTRL the clicked GameObject is put on Scene, at position 0,0,0.
    /// On left click + SHIFT the clicked GameObjects gets selected on the Project tab.
    /// </summary>
    /// <param name="e"></param>
    void OnMouseLeftClick(Event e)
    {
        if (e.control)
        {
            var go = FindClickedPreview(e);
            if (go != null)
            {
                go.transform.position = new Vector3();
                PrefabUtility.InstantiatePrefab(go);
            }
        }
        else if (e.shift)
        {
            var go = FindClickedPreview(e);
            if (go != null)
            {
                Selection.activeObject = go;
            }
        }
    }

    /// <summary>
    /// On mouse down in a preview label, the Drag & Drop feature is activated.
    /// Because the label is outside the "click control", its Y coordinate is adjusted so to "simulate" a click on the GameObject.
    /// </summary>
    /// <param name="e"></param>
    void OnMouseDown(Event e)
    {
        var go = FindClickedPreview(e, 42);
        if (go != null)
        {
            DragAndDrop.PrepareStartDrag();
            DragAndDrop.StartDrag("Dragging");
            DragAndDrop.objectReferences = new Object[] { go };
            DragAndDrop.visualMode = DragAndDropVisualMode.Move;
        }
    }

    /// <summary>
    /// Returns the GameObject that is under the mouse pointer coordinates.
    /// Because the preview GameObjects haven't a click event, the click is "detected" searching the mouse X/Y coordinates inside the coordinates of each GameObject shown on the tab.
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    GameObject FindClickedPreview(Event e)
    {
        if (mouse.positions == null) return null;

        for (var i = 0; i < mouse.positions.Count; i++)
        {
            Vector2 mousePosition = new Vector2(e.mousePosition.x, e.mousePosition.y + scrollPos.y);
            if (mouse.positions[i].Contains(mousePosition))
            {
                var index = (pagination.page * pagination.size) + i;
                return prefabs[index];
            }
        }

        return null;
    }

    /// <summary>
    /// Overload of the FindClickedPreview() method: offsetY modifies the mouse Y coordinate (when the click is on a preview label).
    /// In this way, when the user clicks a label is as if the user has clicked the GameObject.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="offsetY"></param>
    /// <returns></returns>
    GameObject FindClickedPreview(Event e, float offsetY)
    {
        if (mouse.positions == null) return null;
        if (loadedPrefabs == 0) return null;

        for (var i = 0; i < mouse.positions.Count; i++)
        {
            Vector2 mousePosition = new Vector2(e.mousePosition.x, e.mousePosition.y + scrollPos.y - offsetY);
            if (mouse.positions[i].Contains(mousePosition))
            {
                var index = (pagination.page * pagination.size) + i;
                return prefabs[index];
            }
        }

        return null;
    }


    #endregion


    // EDITOR WINDOW DRAWING HELPERS

    #region " INTERFACE "

    /// <summary>
    /// Draws the two tabs Browser and Settings.
    /// </summary>
    private void DrawTabs()
    {
        var tabBrowser = EditorGUIUtility.IconContent("d_SceneViewOrtho");
        tabBrowser.text = "Browser";

        var tabSettings = EditorGUIUtility.IconContent("d_SettingsIcon");
        tabSettings.text = "Settings";

        GUIContent[] toolbar = new GUIContent[] { tabBrowser, tabSettings };
        tab = GUILayout.Toolbar(tab, toolbar);
    }

    /// <summary>
    /// Draws the Help guide with the instructions about how to use Easy Prefab Browser.
    /// </summary>
    private void DrawHelpGuide()
    {
        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("HELP", Style(Color.white, 10, TextAnchor.UpperLeft, FontStyle.Bold));

        EditorGUILayout.Separator();

        EditorGUILayout.HelpBox(
            "• MOUSE OPERATIONS\n\nLeft click + [SHIFT]: select the prefab on the Project tab.\nLeft click + [CTRL]: insert the prefab in the current Scene.\nClick down on label: performs drag & drop.",
            MessageType.Info);
        EditorGUILayout.HelpBox(
            "• SEARCH FILTER\nFilter the list by prefab file name (case insensitive).\n\nstring: exact file name.\nstring*: file name starting with string.\n*string: file name ending with string.\n*string*: file name containing the string.",
            MessageType.Info);
        EditorGUILayout.HelpBox(
             "• LIMITS\nSome value limits are applied to Settings so as to have better performances.\n\nPreview size: min. 50 pixels.\nNumber of colums: min. 1, max. 10\nPrefabs per page: min. 1, max 60",
             MessageType.Warning);
        EditorGUILayout.HelpBox(
            "• NOTES\n\n- Preview list is limited to 60 Prefabs per page due some Unity memory limits.\n- Preview interaction might be not available on items with size under 60 pixels.\n- Some Settings change might request a list refresh.",
            MessageType.Info);
    }

    /// <summary>
    /// Repaint the Easy Prefab Browser window.
    /// </summary>
    void OnInspectorUpdate()
    {
        if (EditorWindow.focusedWindow == this &&
            EditorWindow.mouseOverWindow == this)
        {
            this.Repaint();
        }
    }

    #endregion


    // VARIOUS HELPER METHODS

    #region " HELPERS "

    /// <summary>
    /// Fills the prefabs variable with a list of all the GameObjects (Prefabs, Models or All) found in the selected folder.
    /// If a Filter string is defined, the GameObjects found are listed according to the filtering request.
    /// </summary>
    /// <param name="objectType"></param>
    public async void GetPrefabList(string objectType)
    {
        canRender = false;
        objectTypeLoading = objectType;
        warning = "";
        pagination.infos = "";

        totalItems = 0;
        pagination.page = 0;
        pagination.last = -1;

        prefabs = new List<GameObject>();
        textures = new List<Texture>();

        folder = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (folder == null || folder == "")
        {
            if (rememberLastFolder && lastFolder != "")
            {
                folder = lastFolder;
            }
            else
            {
                warning = "You must select a folder in your Project where to search for Prefabs.";
                return;
            }
        }

        lastFolder = folder;

        var guids = AssetDatabase.FindAssets(objectType, new[] { folder });
        loadedPrefabs = guids.Length;

        await System.Threading.Tasks.Task.Delay(100);

        if (filter == "" || filter == "*")
        {
            if (objectType == "t:Texture")
            {
                foreach (string guid in guids)
                {
                    var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                    textures.Add((Texture)AssetDatabase.LoadAssetAtPath(assetPath, typeof(Texture)));
                    prefabs.Add(null);
                    totalItems++;
                    await System.Threading.Tasks.Task.Delay(1);
                }
            }
            else
            {
                foreach (string guid in guids)
                {
                    var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                    prefabs.Add((GameObject)AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)));
                    totalItems++;
                    await System.Threading.Tasks.Task.Delay(1);
                }
            }

        }
        else
        {

            bool startsWith = filter.StartsWith("*");
            bool endsWith = filter.EndsWith("*");
            string find = filter.Replace("*", "").ToLower();

            foreach (string guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var fileName = Path.GetFileNameWithoutExtension(assetPath).ToLower();
                bool isValid = false;

                if (startsWith && endsWith)
                {
                    isValid = fileName.Contains(find);
                }
                else if (startsWith)
                {
                    isValid = fileName.StartsWith(find);
                }
                else if (endsWith)
                {
                    isValid = fileName.EndsWith(find);
                }
                else
                {
                    isValid = fileName == find;
                }

                if (isValid)
                {
                    var obj = (GameObject)AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject));
                    prefabs.Add(obj);
                    totalItems++;
                    await System.Threading.Tasks.Task.Delay(1);
                }

            }

        }

        if (prefabs.Count == 0) warning = "The currently selected Project folder doesn't contains items to display. Select a folder containing Prefabs and/or Models.";

        canRender = true;

    }

    /// <summary>
    /// Returns a GUIStyle with the given parameters.
    /// </summary>
    /// <param name="color"></param>
    /// <param name="size"></param>
    /// <param name="align"></param>
    /// <param name="fontStyle"></param>
    /// <returns></returns>
    GUIStyle Style(Color color, int size, TextAnchor align, FontStyle fontStyle = FontStyle.Normal)
    {
        GUIStyle infoStyle = new GUIStyle();
        infoStyle.alignment = align;
        infoStyle.normal.textColor = color;
        infoStyle.fontSize = size;
        infoStyle.fontStyle = fontStyle;

        return infoStyle;
    }

    /// <summary>
    /// Returns a GUICOntent label with the given parameters.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="tooltip"></param>
    /// <param name="icon"></param>
    /// <returns></returns>
    GUIContent GLabel(string text, string tooltip = "", string icon = "")
    {
        GUIContent content = new GUIContent();
        if (icon != "") content = EditorGUIUtility.IconContent(icon);

        content.text = text;
        content.tooltip = tooltip;

        return content;

    }

    /// <summary>
    /// Creates and returns a 2D Texture of the given color. It's used for drawing the previews background.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];

        for (int i = 0; i < pix.Length; i++)
            pix[i] = col;

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();

        return result;
    }

    #endregion


}

