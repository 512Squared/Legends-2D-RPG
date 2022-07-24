using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

public class IconTagAttributeDrawer : OdinAttributeDrawer<IconTagAttribute>
{
    private ValueResolver<EditorIcon> iconResolver;

    protected override void Initialize()
    {
        iconResolver = ValueResolver<bool>.Get<EditorIcon>(Property, Attribute.Icon);
    }

    protected override void DrawPropertyLayout(GUIContent label)
    {
        EditorGUILayout.BeginHorizontal();
        // create a style based on the default label style
        GUIStyle pad = new GUIStyle (GUI.skin.label); 
        // do whatever you want with this style, e.g.:
        pad.margin=new RectOffset(0,300,1,0);

        CallNextDrawer(label);
        var icon = iconResolver.GetValue();
        var iconRect = GUILayoutUtility.GetRect(20, 20, new GUIStyle(pad));
        icon.Draw(iconRect, 20);

        EditorGUILayout.EndHorizontal();
    }
}