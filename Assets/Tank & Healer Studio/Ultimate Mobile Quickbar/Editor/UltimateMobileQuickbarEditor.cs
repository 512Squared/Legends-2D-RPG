/* UltimateMobileQuickbarEditor.cs */
/* Written by Kaz Crowe */
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditorInternal;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[CustomEditor( typeof( UltimateMobileQuickbar ) )]
public class UltimateMobileQuickbarEditor : Editor
{
	UltimateMobileQuickbar targ;

	// QUICKBAR POSITIONING //
	Canvas relativeTransformParentCanvas;
	SerializedProperty relativeTransform, buttonPerQuickbar, quickbarCount;
	SerializedProperty overallAngle, centerAngle;
	SerializedProperty buttonSize, buttonOrbitRadius;
	// Quickbar Set Display //
	SerializedProperty useSetDisplay, setDisplayReverseOrder, setDisplayAngle, setDisplayAnglePer, setDisplayOrbitDistance;
	SerializedProperty setDisplayImageSize, setDisplayDefaultScaleMultiplier, setDisplayDefaultColor, setDisplaySelectedColor, setDisplaySprite;
	// Transition //
	SerializedProperty transitionDuration;

	// QUICKBAR SETTINGS //
	SerializedProperty buttonSprite, buttonColor;
	// Input Settings //
	SerializedProperty quickbarButtonInputRadius, actionInvoke, swipeTransition;
	SerializedProperty inputActiveScale, swipeHeadingThreshold, swipeDistanceModifier;
	// Cooldown //
	SerializedProperty cooldownSprite, cooldownColor, useCooldownText, textAnchorMod, displayDecimalCooldown, cooldownTextScaleCurve;
	Image.FillMethod fillMethod = Image.FillMethod.Radial360;
	float cooldownTestValue = 0.0f;
	// Icon //
	SerializedProperty iconScale, useIconMask, iconMaskSprite;
	Sprite tempIcon;
	// Count Text //
	SerializedProperty useCountText, countTextPosX, countTextPosY, countTextSize, countTextBackgroundSprite;
	bool countTextStyle = false;
	// Text Options //
	SerializedProperty textColor, textOutline, textOutlineColor;
	Font textFont;
	// Overlay //
	SerializedProperty useButtonOverlay, buttonOverlaySprite, buttonOverlayColor;
	// Reorder Child Hierarchy //
	List<RectTransform> childTransforms = new List<RectTransform>();
	ReorderableList childObjects;

	// SCRIPT REFERENCE //
	SerializedProperty quickbarName;
	bool NameDuplicate, NameUnassigned, NameAssigned;
	// Example Code //
	class ExampleCode
	{
		public string optionName = "";
		public string optionDescription = "";
		public string basicCode = "";
	}
	ExampleCode[] ExampleCodes = new ExampleCode[]
	{
		// RegisterToQuickbar
		new ExampleCode()
		{
			optionName = "RegisterToQuickbar",
			optionDescription = "Registers the information to the first button that is not registered on this Ultimate Mobile Quickbar.",
			basicCode = "UltimateMobileQuickbar.RegisterToQuickbar( \"{0}\", YourCallbackFunction, quickbarButtonInfo );"
		},
		// RegisterToQuickbar
		new ExampleCode()
		{
			optionName = "RegisterToQuickbar (specific slot)",
			optionDescription = "Registers the information to the targeted button on the targeted Ultimate Mobile Quickbar.",
			basicCode = "UltimateMobileQuickbar.RegisterToQuickbar( \"{0}\", YourCallbackFunction, quickbarButtonInfo, 0, 0 );"
		},
		// EnableQuickbar
		new ExampleCode()
		{
			optionName = "EnableQuickbar",
			optionDescription = "Enables this Ultimate Mobile Quickbar.",
			basicCode = "UltimateMobileQuickbar.EnableQuickbar( \"{0}\" );"
		},
		// DisableQuickbar
		new ExampleCode()
		{
			optionName = "DisableQuickbar",
			optionDescription = "Disables this Ultimate Mobile Quickbar.",
			basicCode = "UltimateMobileQuickbar.DisableQuickbar( \"{0}\" );"
		},
		// CycleQuickbarSets
		new ExampleCode()
		{
			optionName = "CycleQuickbarSets",
			optionDescription = "Cycles through the quickbar sets on this Ultimate Mobile Quickbar.",
			basicCode = "UltimateMobileQuickbar.CycleQuickbarSets( \"{0}\", true );"
		},
		// AddNewQuickbarSet
		new ExampleCode()
		{
			optionName = "AddNewQuickbarSet",
			optionDescription = "Adds a new quickbar set to this Ultimate Mobile Quickbar.",
			basicCode = "UltimateMobileQuickbar.AddNewQuickbarSet( \"{0}\" );"
		},
		// RemoveEmptyQuickbarSets
		new ExampleCode()
		{
			optionName = "RemoveEmptyQuickbarSets",
			optionDescription = "Removes any extra quickbar sets from this Ultimate Mobile Quickbar that are not populated with any button information.",
			basicCode = "UltimateMobileQuickbar.RemoveEmptyQuickbarSets( \"{0}\" );"
		},
		// ClearQuickbar
		new ExampleCode()
		{
			optionName = "ClearQuickbar",
			optionDescription = "Clears this Ultimate Mobile Quickbar of all information and removes excess quickbar parents.",
			basicCode = "UltimateMobileQuickbar.ClearQuickbar( \"{0}\" );"
		},
	};
	List<string> ExampleCodeOptions = new List<string>();
	int exampleCodeIndex = 0;

	// SCENE GUI //
	class DisplaySceneGizmo
	{
		public int frames = maxFrames;
		public bool hover = false;
		
		public bool HighlightGizmo
		{
			get
			{
				return hover || frames < maxFrames;
			}
		}

		public void PropertyUpdated ()
		{
			frames = 0;
		}
	}
	DisplaySceneGizmo DisplayOverallAngle = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplayCenterAngle = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplayButtonSize = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplayButtonOrbitRadius = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplaySetDisplayAngle = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplaySetDisplayOrbitRadius = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplayInputRadius = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplaySwipeTransition = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplayHeadingThreshold = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplayCooldownTextAnchor = new DisplaySceneGizmo();
	DisplaySceneGizmo DisplayCountTextRect = new DisplaySceneGizmo();
	const int maxFrames = 200;
	int cooldownTimeMax = 1;
	// Gizmo Colors //
	Color colorDefault = Color.black;
	Color colorValueChanged = Color.black;

	// DEVELOPMENT MODE //
	bool showDefaultInspector = false;

	// MISC //
	GUIStyle neededVariablesTextStyle = new GUIStyle();
	GUIStyle collapsableSectionStyle = new GUIStyle();
	Canvas parentCanvas;
	

	void OnEnable () 
	{
		StoreReferences();
		
		Undo.undoRedoPerformed += UndoRedoCallback;

		if( EditorPrefs.HasKey( "UMQ_ColorHexSetup" ) )
		{
			ColorUtility.TryParseHtmlString( EditorPrefs.GetString( "UMQ_ColorDefaultHex" ), out colorDefault );
			ColorUtility.TryParseHtmlString( EditorPrefs.GetString( "UMQ_ColorValueChangedHex" ), out colorValueChanged );
		}
	}

	void OnDisable ()
	{
		Undo.undoRedoPerformed -= UndoRedoCallback;
	}
	
	void UndoRedoCallback ()
	{
		StoreReferences();
	}

	void UpdateReorderChildren ()
	{
		if( targ == null )
			return;

		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
		{
			if( targ.QuickbarParents[ i ].transform == null )
				break;

			for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.transform.SetSiblingIndex( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonIcon.transform.GetSiblingIndex() );
				targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownImage.transform.SetSiblingIndex( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownImage.transform.GetSiblingIndex() );

				if( targ.useCooldownText )
					targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.transform.SetSiblingIndex( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownText.transform.GetSiblingIndex() );

				if( targ.useButtonOverlay )
					targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage.transform.SetSiblingIndex( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonOverlayImage.transform.GetSiblingIndex() );

				if( targ.useCountText )
				{
					targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.transform.SetSiblingIndex( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countText.transform.GetSiblingIndex() );

					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground != null )
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground.transform.SetSiblingIndex( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countTextBackground.transform.GetSiblingIndex() );
				}
			}
		}
	}

	void StoreReferences ()
	{
		targ = ( UltimateMobileQuickbar )target;

		CanvasGroup cg = targ.GetComponent<CanvasGroup>();
		cg.interactable = false;
		cg.blocksRaycasts = false;
		cg.ignoreParentGroups = true;

		// QUICKBAR POSITIONING //
		if( targ.relativeTransform != null )
		{
			Transform parent = targ.relativeTransform.parent;

			// If the parent is null, then just return.
			if( parent == null )
				return;

			// While the parent is assigned...
			while( parent != null )
			{
				// If the parent object has a Canvas component, then assign the ParentCanvas and transform.
				if( parent.transform.GetComponent<Canvas>() )
				{
					relativeTransformParentCanvas = parent.transform.GetComponent<Canvas>();
					break;
				}

				// If the parent does not have a canvas, then store it's parent to loop again.
				parent = parent.transform.parent;
			}
		}

		relativeTransform = serializedObject.FindProperty( "relativeTransform" );
		quickbarCount = serializedObject.FindProperty( "quickbarCount" );
		buttonPerQuickbar = serializedObject.FindProperty( "buttonPerQuickbar" );
		overallAngle = serializedObject.FindProperty( "overallAngle" );
		centerAngle = serializedObject.FindProperty( "centerAngle" );
		buttonSize = serializedObject.FindProperty( "buttonSize" );
		quickbarButtonInputRadius = serializedObject.FindProperty( "quickbarButtonInputRadius" );
		buttonOrbitRadius = serializedObject.FindProperty( "buttonOrbitRadius" );
		// Set Display //
		useSetDisplay = serializedObject.FindProperty( "useSetDisplay" );
		setDisplayReverseOrder = serializedObject.FindProperty( "setDisplayReverseOrder" );
		setDisplayAngle = serializedObject.FindProperty( "setDisplayAngle" );
		setDisplayAnglePer = serializedObject.FindProperty( "setDisplayAnglePer" );
		setDisplayOrbitDistance = serializedObject.FindProperty( "setDisplayOrbitDistance" );
		setDisplayImageSize = serializedObject.FindProperty( "setDisplayImageSize" );
		setDisplayDefaultScaleMultiplier = serializedObject.FindProperty( "setDisplayDefaultScaleMultiplier" );
		setDisplaySelectedColor = serializedObject.FindProperty( "setDisplaySelectedColor" );
		setDisplayDefaultColor = serializedObject.FindProperty( "setDisplayDefaultColor" );
		setDisplaySprite = serializedObject.FindProperty( "setDisplaySprite" );
		// Transition Settings //
		transitionDuration = serializedObject.FindProperty( "transitionDuration" );

		// QUICKBAR SETTINGS //
		buttonSprite = serializedObject.FindProperty( "buttonSprite" );
		buttonColor = serializedObject.FindProperty( "buttonColor" );
		// Input Settings //
		inputActiveScale = serializedObject.FindProperty( "inputActiveScale" );
		actionInvoke = serializedObject.FindProperty( "actionInvoke" );
		swipeTransition = serializedObject.FindProperty( "swipeTransition" );
		swipeHeadingThreshold = serializedObject.FindProperty( "swipeHeadingThreshold" );
		swipeDistanceModifier = serializedObject.FindProperty( "swipeDistanceModifier" );
		// Cooldown Settings //
		cooldownSprite = serializedObject.FindProperty( "cooldownSprite" );
		cooldownColor = serializedObject.FindProperty( "cooldownColor" );
		useCooldownText = serializedObject.FindProperty( "useCooldownText" );
		textAnchorMod = serializedObject.FindProperty( "textAnchorMod" );
		displayDecimalCooldown = serializedObject.FindProperty( "displayDecimalCooldown" );
		cooldownTextScaleCurve = serializedObject.FindProperty( "cooldownTextScaleCurve" );
		// Icon Settings //
		iconScale = serializedObject.FindProperty( "iconScale" );
		useIconMask = serializedObject.FindProperty( "useIconMask" );
		iconMaskSprite = serializedObject.FindProperty( "iconMaskSprite" );
		// Count Text //
		useCountText = serializedObject.FindProperty( "useCountText" );
		countTextPosX = serializedObject.FindProperty( "countTextPosX" );
		countTextPosY = serializedObject.FindProperty( "countTextPosY" );
		countTextSize = serializedObject.FindProperty( "countTextSize" );
		countTextBackgroundSprite = serializedObject.FindProperty( "countTextBackgroundSprite" );
		// Text Options //
		textColor = serializedObject.FindProperty( "textColor" );
		textOutline = serializedObject.FindProperty( "textOutline" );
		textOutlineColor = serializedObject.FindProperty( "textOutlineColor" );
		// Button Overlay //
		useButtonOverlay = serializedObject.FindProperty( "useButtonOverlay" );
		buttonOverlaySprite = serializedObject.FindProperty( "buttonOverlaySprite" );
		buttonOverlayColor = serializedObject.FindProperty( "buttonOverlayColor" );
		
		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
		{
			if( targ.QuickbarParents[ i ].transform == null )
			{
				Debug.LogError( "Ultimate Mobile Quickbar - A quickbar parent has been detected as null. Did you delete a quickbar parent transform? Reseting list to avoid errors." );// EDIT: This should explain how to properly delete a parent.
				serializedObject.FindProperty( "QuickbarParents" ).arraySize = 0;
				serializedObject.ApplyModifiedProperties();
				StoreReferences();
				return;
			}

			for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform == null )
				{
					Debug.LogError( "Ultimate Mobile Quickbar - A quickbar button has been detected as null. Did you delete a quickbar button transform? Reseting list to avoid errors." );// EDIT: This should explain how to properly delete a button.
					serializedObject.FindProperty( "QuickbarParents" ).arraySize = 0;
					serializedObject.ApplyModifiedProperties();
					StoreReferences();
					return;
				}
			}
		}

		if( targ.QuickbarParents.Count > 0 && targ.QuickbarParents[ 0 ].QuickbarButtons.Count > 0 )
		{
			if( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownImage != null )
			{
				fillMethod = targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownImage.fillMethod;
				cooldownTestValue = targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownImage.fillAmount * cooldownTimeMax;
			}

			if( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countText != null && targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countText.text != string.Empty )
				countTextStyle = true;
			else
				countTextStyle = false;

			if( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownText != null )
			{
				textFont = targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownText.font;
			}
			else if( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countText != null )
			{
				textFont = targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countText.font;
			}

			UpdateReorderChildren();
			StoreChildTransforms();

			tempIcon = targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonIcon.sprite;
		}

		// SCRIPT REFERENCE //
		quickbarName = serializedObject.FindProperty( "quickbarName" );
		NameDuplicate = DuplicateQuickbarName();
		NameUnassigned = targ.quickbarName == string.Empty ? true : false;
		NameAssigned = NameDuplicate == false && targ.quickbarName != string.Empty ? true : false;
		// Example Code //
		ExampleCodeOptions = new List<string>();
		for( int i = 0; i < ExampleCodes.Length; i++ )
			ExampleCodeOptions.Add( ExampleCodes[ i ].optionName );
	}

	void StoreChildTransforms ()
	{
		if( targ.QuickbarParents[ 0 ].transform == null )
			return;

		childTransforms = new List<RectTransform>();
		RectTransform[] childRectTrans = targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonTransform.GetComponentsInChildren<RectTransform>();
		for( int i = 0; i < childRectTrans.Length; i++ )
		{
			if( childRectTrans[ i ] == targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonTransform )
				continue;

			if( childRectTrans[ i ] == targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonIcon.rectTransform )
			{
				if( targ.useIconMask )
					continue;
			}

			childTransforms.Add( childRectTrans[ i ] );
		}

		childObjects = new ReorderableList( childTransforms, typeof( RectTransform ), true, false, false, false );

		childObjects.drawHeaderCallback = ( Rect rect ) =>
		{
			EditorGUI.LabelField( rect, "Quickbar Button" );
		};

		childObjects.drawElementCallback = ( Rect rect, int index, bool isActive, bool isFocused ) =>
		{
			if( index > childTransforms.Count - 1 )
				return;
			
			var element = childObjects.list;
			rect.y += 2;
			string objectName = childTransforms[ index ].name;
			objectName = objectName.Substring( 0, objectName.Length - 3 );
			EditorGUI.LabelField( new Rect( rect.x, rect.y, EditorGUIUtility.currentViewWidth, EditorGUIUtility.singleLineHeight ), objectName );
		};

		childObjects.onChangedCallback = ( ReorderableList l ) =>
		{
			for( int i = 0; i < childTransforms.Count; i++ )
			{
				childTransforms[ i ].SetSiblingIndex( i );
			}
			UpdateReorderChildren();
		};
	}

	bool DuplicateQuickbarName ()
	{
		UltimateMobileQuickbar[] ultimateMobileQuickbars = FindObjectsOfType<UltimateMobileQuickbar>();

		for( int i = 0; i < ultimateMobileQuickbars.Length; i++ )
		{
			if( ultimateMobileQuickbars[ i ].quickbarName == string.Empty )
				continue;

			if( ultimateMobileQuickbars[ i ] != targ && ultimateMobileQuickbars[ i ].quickbarName == targ.quickbarName )
				return true;
		}
		return false;
	}

	void DisplayHeaderDropdown ( string headerName, string editorPref )
	{
		EditorGUILayout.Space();
		
		GUIStyle toolbarStyle = new GUIStyle( EditorStyles.toolbarButton ) { alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, fontSize = 11 };
		GUILayout.BeginHorizontal();
		GUILayout.Space( -10 );
		EditorPrefs.SetBool( editorPref, GUILayout.Toggle( EditorPrefs.GetBool( editorPref ), ( EditorPrefs.GetBool( editorPref ) ? "▼" : "►" ) + headerName, toolbarStyle ) );
		GUILayout.EndHorizontal();

		if( EditorPrefs.GetBool( editorPref ) == true )
			EditorGUILayout.Space();
	}

	bool DisplayCollapsibleBoxSection ( string sectionTitle, string editorPref )
	{
		if( EditorPrefs.GetBool( editorPref ) )
			collapsableSectionStyle.fontStyle = FontStyle.Bold;
		
		if( GUILayout.Button( sectionTitle, collapsableSectionStyle ) )
			EditorPrefs.SetBool( editorPref, !EditorPrefs.GetBool( editorPref ) );
		
		if( EditorPrefs.GetBool( editorPref ) )
			collapsableSectionStyle.fontStyle = FontStyle.Normal;

		return EditorPrefs.GetBool( editorPref );
	}

	bool DisplayCollapsibleBoxSection ( string sectionTitle, string editorPref, SerializedProperty enabledProp, ref bool valueChanged )
	{
		if( EditorPrefs.GetBool( editorPref ) && enabledProp.boolValue )
			collapsableSectionStyle.fontStyle = FontStyle.Bold;

		EditorGUILayout.BeginHorizontal();

		EditorGUI.BeginChangeCheck();
		enabledProp.boolValue = EditorGUILayout.Toggle( enabledProp.boolValue, GUILayout.Width( 25 ) );
		if( EditorGUI.EndChangeCheck() )
		{
			serializedObject.ApplyModifiedProperties();

			if( enabledProp.boolValue )
				EditorPrefs.SetBool( editorPref, true );
			else
				EditorPrefs.SetBool( editorPref, false );

			valueChanged = true;
		}

		GUILayout.Space( -30 );

		EditorGUI.BeginDisabledGroup( !enabledProp.boolValue );
		if( GUILayout.Button( sectionTitle, collapsableSectionStyle ) )
			EditorPrefs.SetBool( editorPref, !EditorPrefs.GetBool( editorPref ) );
		EditorGUI.EndDisabledGroup();

		EditorGUILayout.EndHorizontal();

		if( EditorPrefs.GetBool( editorPref ) )
			collapsableSectionStyle.fontStyle = FontStyle.Normal;

		return EditorPrefs.GetBool( editorPref ) && enabledProp.boolValue;
	}

	void CheckPropertyHover ( DisplaySceneGizmo displaySceneGizmo )
	{
		displaySceneGizmo.hover = false;
		var rect = GUILayoutUtility.GetLastRect();
		if( Event.current.type == EventType.Repaint && rect.Contains( Event.current.mousePosition ) )
			displaySceneGizmo.hover = true;
	}

	public override void OnInspectorGUI ()
	{
		if( Application.isPlaying && targ.QuickbarParents.Count == 0 )
		{
			EditorGUILayout.HelpBox( "The Quickbar List has been cleared and there are no buttons present.", MessageType.Error );
			return;
		}
		
		serializedObject.Update();

		collapsableSectionStyle = new GUIStyle( EditorStyles.label ) { alignment = TextAnchor.MiddleCenter, onActive = new GUIStyleState() { textColor = Color.black } };
		collapsableSectionStyle.active.textColor = collapsableSectionStyle.normal.textColor;

		if( GetCanvasError() )
		{
			EditorGUILayout.BeginVertical( "Box" );
			int fontSize = GUI.skin.font.fontSize;
			GUIStyle warningStyle = new GUIStyle( GUI.skin.label )
			{
				fontStyle = FontStyle.Bold,
				alignment = TextAnchor.MiddleCenter,
				wordWrap = true,
				fontSize = fontSize + 2
			};
			warningStyle.normal.textColor = Color.red;
			EditorGUILayout.LabelField( "WARNING", warningStyle );
			EditorGUILayout.LabelField( "  The Ultimate Mobile Quickbar needs to have consistent and reliable calculations to make the script correctly.", EditorStyles.wordWrappedLabel );
			EditorGUILayout.LabelField( "Therefore, the parent Canvas needs to be set to 'Screen Space - Overlay' in order for the Ultimate Mobile Quickbar to function properly.", EditorStyles.wordWrappedLabel );// EDIT: these messages.
			if( GUILayout.Button( "Fix Current Canvas", EditorStyles.miniButton ) )
			{
				Undo.RecordObject( parentCanvas, "Update Canvas Render Mode" );
				parentCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

				if( parentCanvas.GetComponent<CanvasScaler>() )
					parentCanvas.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
			}
			if( GUILayout.Button( "Create New Canvas", EditorStyles.miniButton ) )
			{
				RequestCanvas( Selection.activeGameObject );
				parentCanvas = GetParentCanvas();
			}
			EditorGUILayout.EndVertical();
			Repaint();
			return;
		}

		if( targ.QuickbarParents.Count == 0 || targ.QuickbarParents[ 0 ].transform == null )
		{
			neededVariablesTextStyle = new GUIStyle( EditorStyles.label ) { richText = true };

			EditorGUILayout.BeginVertical( "Box" );

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel( targ.relativeTransform == null ? "<b>Relative Transform</b> <color=#ff0000ff>*</color>" : "Relative Transform", neededVariablesTextStyle, neededVariablesTextStyle );
			EditorGUILayout.PropertyField( relativeTransform, GUIContent.none );
			EditorGUILayout.EndHorizontal();
			if( EditorGUI.EndChangeCheck() )
				serializedObject.ApplyModifiedProperties();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField( "Button Per Quickbar: " + targ.buttonPerQuickbar );
			GUILayout.FlexibleSpace();
			if( GUILayout.Button( "+", EditorStyles.miniButtonLeft, GUILayout.Width( 20 ) ) )
			{
				buttonPerQuickbar.intValue++;
				serializedObject.ApplyModifiedProperties();
			}
			EditorGUI.BeginDisabledGroup( buttonPerQuickbar.intValue <= 2 );
			if( GUILayout.Button( "-", EditorStyles.miniButtonRight, GUILayout.Width( 20 ) ) )
			{
				buttonPerQuickbar.intValue--;
				serializedObject.ApplyModifiedProperties();
			}
			EditorGUI.EndDisabledGroup();
			EditorGUILayout.EndHorizontal();

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.Slider( overallAngle, 0.0f, 360.0f, new GUIContent( "Overall Angle", "The overall angle for the quickbar buttons to fit into." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				DisplayOverallAngle.PropertyUpdated();
				serializedObject.ApplyModifiedProperties();
			}
			CheckPropertyHover( DisplayOverallAngle );

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.Slider( centerAngle, -180.0f, 180.0f, new GUIContent( "Center Angle", "The center angle of the quickbar." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				DisplayCenterAngle.PropertyUpdated();
				serializedObject.ApplyModifiedProperties();
			}
			CheckPropertyHover( DisplayCenterAngle );

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.Slider( buttonSize, 0.0f, 7.5f, new GUIContent( "Button Size", "The size of the buttons." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				DisplayButtonSize.PropertyUpdated();
				serializedObject.ApplyModifiedProperties();
			}
			CheckPropertyHover( DisplayButtonSize );

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.Slider( buttonOrbitRadius, 0.0f, 1.5f, new GUIContent( "Button Orbit Radius", "The radius around the relative transform for the buttons to orbit." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				DisplayButtonOrbitRadius.PropertyUpdated();
				serializedObject.ApplyModifiedProperties();
			}
			CheckPropertyHover( DisplayButtonOrbitRadius );

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel( targ.buttonSprite == null ? "<b>Button Sprite</b> <color=#ff0000ff>*</color>" : "Button Sprite", neededVariablesTextStyle, neededVariablesTextStyle );
			EditorGUILayout.PropertyField( buttonSprite, GUIContent.none );
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel( targ.cooldownSprite == null ? "<b>Cooldown Sprite</b> <color=#ff0000ff>*</color>" : "Cooldown Sprite", neededVariablesTextStyle, neededVariablesTextStyle );
			EditorGUILayout.PropertyField( cooldownSprite, GUIContent.none );
			EditorGUILayout.EndHorizontal();

			if( EditorGUI.EndChangeCheck() )
				serializedObject.ApplyModifiedProperties();
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel( "Placeholder Icon" );
			tempIcon = ( Sprite )EditorGUILayout.ObjectField( tempIcon, typeof( Sprite ), false );
			EditorGUILayout.EndHorizontal();
			
			EditorGUI.BeginDisabledGroup( targ.relativeTransform == null || targ.buttonSprite == null || targ.cooldownSprite == null );
			if( GUILayout.Button( "Generate" ) )
				GenerateNewQuickbarSet();
			EditorGUI.EndDisabledGroup();

			if( targ.relativeTransform == null || targ.buttonSprite == null || targ.cooldownSprite == null )
				EditorGUILayout.LabelField( "<i><color=#ff0000ff>*</color> Required Field</i>", neededVariablesTextStyle );

			EditorGUILayout.EndVertical();
			Repaint();
			return;
		}
		
		if( targ.relativeTransform == null )
		{
			EditorGUILayout.BeginVertical( "Box" );

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField( relativeTransform, new GUIContent( "Relative Transform", "The transform to calculate the quickbar in relative position to." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				serializedObject.ApplyModifiedProperties();
				StoreReferences();
			}

			EditorGUILayout.EndVertical();
			Repaint();
			return;
		}

		if( targ.QuickbarParents.Count > 0 && targ.QuickbarParents[ 0 ].transform == null )
		{
			serializedObject.FindProperty( "QuickbarParents" ).arraySize = 0;
			serializedObject.ApplyModifiedProperties();
			return;
		}

		bool valueChanged = false;
		
		DisplayHeaderDropdown( "Quickbar Positioning", "UMQ_QuickbarPositioning" );
		if( EditorPrefs.GetBool( "UMQ_QuickbarPositioning" ) )
		{
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField( relativeTransform, new GUIContent( "Relative Transform", "The transform to calculate the quickbar in relative position to." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				serializedObject.ApplyModifiedProperties();

				if( targ.relativeTransform != null )
				{
					Transform parent = targ.relativeTransform.parent;

					// If the parent is null, then just return.
					if( parent == null )
						return;

					// While the parent is assigned...
					while( parent != null )
					{
						// If the parent object has a Canvas component, then assign the ParentCanvas and transform.
						if( parent.transform.GetComponent<Canvas>() )
						{
							relativeTransformParentCanvas = parent.transform.GetComponent<Canvas>();
							break;
						}

						// If the parent does not have a canvas, then store it's parent to loop again.
						parent = parent.transform.parent;
					}
				}
			}

			if( relativeTransform != null && targ.ParentCanvas != null && relativeTransformParentCanvas != null && relativeTransformParentCanvas != targ.ParentCanvas )
				EditorGUILayout.HelpBox( "The relative transform is not within the same Canvas object.", MessageType.Error );

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField( "Button Per Quickbar: " + targ.buttonPerQuickbar );
			GUILayout.FlexibleSpace();
			if( GUILayout.Button( "+", EditorStyles.miniButtonLeft, GUILayout.Width( 20 ) ) )
				AddButtonPerQuickbar();
			EditorGUI.BeginDisabledGroup( targ.buttonPerQuickbar <= 2 );
			if( GUILayout.Button( "-", EditorStyles.miniButtonRight, GUILayout.Width( 20 ) ) )
				RemoveButtonPerQuickbar();
			EditorGUI.EndDisabledGroup();
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField( "Quickbar Count: " + quickbarCount.intValue );
			GUILayout.FlexibleSpace();
			if( GUILayout.Button( "+", EditorStyles.miniButtonLeft, GUILayout.Width( 20 ) ) )
				GenerateNewQuickbarSet();
			EditorGUI.BeginDisabledGroup( quickbarCount.intValue <= 1 );
			if( GUILayout.Button( "-", EditorStyles.miniButtonRight, GUILayout.Width( 20 ) ) )
				RemoveQuickbarSet();
			EditorGUI.EndDisabledGroup();
			EditorGUILayout.EndHorizontal();

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.Slider( overallAngle, 0.0f, 360.0f, new GUIContent( "Overall Angle", "The overall angle for the buttons to populate." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				DisplayOverallAngle.PropertyUpdated();
				serializedObject.ApplyModifiedProperties();
			}
			CheckPropertyHover( DisplayOverallAngle );

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.Slider( centerAngle, -180.0f, 180.0f, new GUIContent( "Center Angle", "The center angle of the buttons." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				DisplayCenterAngle.PropertyUpdated();
				serializedObject.ApplyModifiedProperties();
			}
			CheckPropertyHover( DisplayCenterAngle );

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.Slider( buttonSize, 0.0f, 7.5f, new GUIContent( "Button Size", "The size of the buttons." ) );
			if( EditorGUI.EndChangeCheck() )
				serializedObject.ApplyModifiedProperties();

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.Slider( buttonOrbitRadius, 0.0f, 1.5f, new GUIContent( "Button Orbit Radius", "The radius around the relative transform for the buttons to orbit." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				DisplayButtonOrbitRadius.PropertyUpdated();
				serializedObject.ApplyModifiedProperties();
			}
			CheckPropertyHover( DisplayButtonOrbitRadius );

			// ----------------------------- SET DISPLAY ----------------------------- //
			valueChanged = false;
			EditorGUILayout.BeginVertical( "Box" );
			if( DisplayCollapsibleBoxSection( "Quickbar Set Display", "UMQ_SetDisplaySettings", useSetDisplay, ref valueChanged ) )
			{
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( setDisplayAngle, 0.0f, 360.0f, new GUIContent( "Angle", "The middle angle of the set display." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					DisplaySetDisplayAngle.PropertyUpdated();
					serializedObject.ApplyModifiedProperties();
				}
				CheckPropertyHover( DisplaySetDisplayAngle );

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( setDisplayAnglePer, 0.0f, 45.0f, new GUIContent( "Angle Per", "The angle per set display image." ) );
				if( EditorGUI.EndChangeCheck() )
					serializedObject.ApplyModifiedProperties();

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( setDisplayOrbitDistance, 0.0f, 1.0f, new GUIContent( "Orbit Distance", "The orbit distance of the set display images." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					DisplaySetDisplayOrbitRadius.PropertyUpdated();
					serializedObject.ApplyModifiedProperties();
				}
				CheckPropertyHover( DisplaySetDisplayOrbitRadius );

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( setDisplayImageSize, 0.0f, 5.0f, new GUIContent( "Image Size", "The size of the set display images." ) );
				EditorGUILayout.Slider( setDisplayDefaultScaleMultiplier, 0.5f, 1.5f, new GUIContent( "Default Scale", "The default scale of the set display images for when they are not selected." ) );
				if( EditorGUI.EndChangeCheck() )
					serializedObject.ApplyModifiedProperties();

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( setDisplaySprite, new GUIContent( "Display Sprite", "The sprite to apply to the set display images." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].setDisplayImage, "Update Set Display Sprite" );
						targ.QuickbarParents[ i ].setDisplayImage.sprite = targ.setDisplaySprite;
					}
				}

				EditorGUI.indentLevel++;
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( setDisplaySelectedColor, new GUIContent( "Selected Color", "The color to apply to the set display image that is selected." ) );
				EditorGUILayout.PropertyField( setDisplayDefaultColor, new GUIContent( "Default Color", "The default color to apply to the set display images that are not selected." ) );
				if( EditorGUI.EndChangeCheck() )
					serializedObject.ApplyModifiedProperties();
				EditorGUI.indentLevel--;

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( setDisplayReverseOrder, new GUIContent( "Reverse Order", "Reverses the positioning order of the set display images." ) );
				if( EditorGUI.EndChangeCheck() )
					serializedObject.ApplyModifiedProperties();

				GUILayout.Space( 1 );
			}
			EditorGUILayout.EndVertical();
			if( valueChanged )
			{
				if( setDisplayAngle.floatValue == 0.0f )
				{
					float calcDisplayAngle = targ.centerAngle += 180;
					if( calcDisplayAngle > 360 )
						calcDisplayAngle -= 360;
					else if( calcDisplayAngle < 0 )
						calcDisplayAngle += 360;

					setDisplayAngle.floatValue = calcDisplayAngle;
				}
				
				CheckForSetDisplayObjects();
			}
			// --------------------------- END SET DISPLAY --------------------------- //

			// ----------------------------- TRANSITION SETTINGS ----------------------------- //
			EditorGUILayout.BeginVertical( "Box" );
			if( DisplayCollapsibleBoxSection( "Transition", "UMQ_TransitionSettings" ) )
			{
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( transitionDuration, new GUIContent( "Transition Duration", "The duration of the quickbar transition." ) );
				if( EditorGUI.EndChangeCheck() )
					serializedObject.ApplyModifiedProperties();

				GUILayout.Space( 1 );
			}
			EditorGUILayout.EndVertical();
			// --------------------------- END TRANSITION SETTINGS --------------------------- //
		}

		DisplayHeaderDropdown( "Quickbar Settings", "UMQ_QuickbarSettings" );
		if( EditorPrefs.GetBool( "UMQ_QuickbarSettings" ) )
		{
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField( buttonSprite, new GUIContent( "Button Sprite", "The sprite for the quickbar buttons." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				serializedObject.ApplyModifiedProperties();

				for( int i = 0; i < targ.QuickbarParents.Count; i++ )
				{
					for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.GetComponent<Image>(), "Change Button Sprite" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.GetComponent<Image>().sprite = targ.buttonSprite;
					}
				}
			}

			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField( buttonColor, new GUIContent( "Button Color", "The color of the button images." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				serializedObject.ApplyModifiedProperties();

				for( int i = 0; i < targ.QuickbarParents.Count; i++ )
				{
					for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.GetComponent<Image>(), "Change Button Color" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.GetComponent<Image>().enabled = false;
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.GetComponent<Image>().color = targ.buttonColor;
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform.GetComponent<Image>().enabled = true;
					}
				}
			}

			// ----------------------------- INPUT SETTINGS ----------------------------- //
			EditorGUILayout.BeginVertical( "Box" );
			if( DisplayCollapsibleBoxSection( "Input", "UMQ_InputSettings" ) )
			{
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( quickbarButtonInputRadius, 0.0f, 1.5f, new GUIContent( "Button Input Radius", "The input radius around the button to accept input from." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					DisplayInputRadius.PropertyUpdated();
					serializedObject.ApplyModifiedProperties();
				}
				CheckPropertyHover( DisplayInputRadius );

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( inputActiveScale, 0.5f, 1.5f, new GUIContent( "Input Active Scale", "The scale of the button when being interacted with." ) );
				if( EditorGUI.EndChangeCheck() )
					serializedObject.ApplyModifiedProperties();

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( actionInvoke, new GUIContent( "Action Invoke", "Determines when the callbacks are invoke when interacting with the buttons." ) );
				if( EditorGUI.EndChangeCheck() )
					serializedObject.ApplyModifiedProperties();

				if( targ.actionInvoke == UltimateMobileQuickbar.ActionInvoke.OnButtonUp )
				{
					EditorGUI.indentLevel++;

					EditorGUI.BeginChangeCheck();
					EditorGUILayout.PropertyField( swipeTransition, new GUIContent( "Swipe Transition", "Allows for swiping towards another button to transition the menu.\n\nScene Gizmo\nGreen Arrow = Direction to increase quickbar set.\nRed Arrow = Direction to decrease quickbar set." ) );
					if( EditorGUI.EndChangeCheck() )
					{
						serializedObject.ApplyModifiedProperties();

						DisplaySwipeTransition.PropertyUpdated();
					}
					CheckPropertyHover( DisplaySwipeTransition );

					EditorGUI.BeginDisabledGroup( targ.swipeTransition == UltimateMobileQuickbar.SwipeTransition.Disabled );
					{
						EditorGUI.BeginChangeCheck();
						EditorGUILayout.Slider( swipeDistanceModifier, 0.01f, 0.5f, new GUIContent( "Distance Modifier", "The distance to swipe relative to the size of the button to be able to activate a transition. A value of 0.5 is equivalent to the swipe distance having to be at least half of the button before a transition can be made." ) );
						if( EditorGUI.EndChangeCheck() )
							serializedObject.ApplyModifiedProperties();

						EditorGUI.BeginChangeCheck();
						EditorGUILayout.Slider( swipeHeadingThreshold, 0.0f, 1.0f, new GUIContent( "Heading Threshold", "The calculated angle of trajectory in the target direction to activate a transition. The smaller the value, the larger the angle allowed." ) );
						if( EditorGUI.EndChangeCheck() )
						{
							DisplayHeadingThreshold.PropertyUpdated();
							serializedObject.ApplyModifiedProperties();
						}
						CheckPropertyHover( DisplayHeadingThreshold );
					}
					EditorGUI.EndDisabledGroup();
					EditorGUI.indentLevel--;
				}

				GUILayout.Space( 1 );
			}
			EditorGUILayout.EndVertical();
			// --------------------------- END INPUT SETTINGS --------------------------- //

			// ---------------------------- COOLDOWN SETTINGS ---------------------------- //
			EditorGUILayout.BeginVertical( "Box" );
			if( DisplayCollapsibleBoxSection( "Cooldown", "UMQ_CooldownSettings" ) )
			{
				EditorGUI.BeginChangeCheck();
				cooldownTestValue = EditorGUILayout.Slider( "Cooldown Test", cooldownTestValue, 0.0f, cooldownTimeMax );
				if( EditorGUI.EndChangeCheck() )
				{
					for( int i = 0; i < targ.QuickbarParents[ 0 ].QuickbarButtons.Count; i++ )
					{
						Undo.RecordObject( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownImage, "Cooldown Test" );

						if( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText != null )
							Undo.RecordObject( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText, "Cooldown Text Test" );

						targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownImage.enabled = false;
						targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].UpdateCooldown( cooldownTestValue, cooldownTimeMax );
						targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownImage.enabled = true;

						if( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText != null )
							targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText.rectTransform.localScale = Vector3.Lerp( Vector3.zero, Vector3.one, targ.cooldownTextScaleCurve.Evaluate( -cooldownTestValue + 1 ) );

						if( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText != null && cooldownTestValue == 0.0f )
						{
							targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText.rectTransform.localScale = Vector3.one;
							targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText.text = "00";
						}
					}
				}
				
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( cooldownSprite, new GUIContent( "Cooldown Sprite", "The sprite to use for the cooldown image." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
						{
							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownImage == null )
								continue;

							Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownImage, "Update Cooldown Sprite" );
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownImage.sprite = targ.cooldownSprite;
						}
					}
				}

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( cooldownColor, new GUIContent( "Image Color", "The color of the cooldown image." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
						{
							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownImage == null )
								continue;

							Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownImage, "Update Cooldown Color" );
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownImage.color = targ.cooldownColor;
						}
					}
				}

				EditorGUI.BeginChangeCheck();
				fillMethod = ( Image.FillMethod )EditorGUILayout.EnumPopup( "Fill Method", fillMethod );
				if( EditorGUI.EndChangeCheck() )
				{
					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
						{
							Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownImage, "Change Fill Method" );
							targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownImage.enabled = false;
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownImage.fillMethod = fillMethod;
							targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownImage.enabled = true;
						}
					}
				}
				
				// ------------------------------ COOLDOWN TEXT SETTINGS ------------------------------ //
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( useCooldownText, new GUIContent( "Use Cooldown Text", "Determines if the buttons should display cooldown text." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					CheckForButtonCooldownTextObjects();

					if( !useCooldownText.boolValue && !targ.useCooldownText )
						EditorPrefs.SetBool( "UMQ_TextOptions", false );
				}
				
				EditorGUI.BeginDisabledGroup( !useCooldownText.boolValue );
				EditorGUI.indentLevel++;
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( textAnchorMod, 0.0f, 1.0f, new GUIContent( "Text Size", "The size of the cooldown text." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					DisplayCooldownTextAnchor.PropertyUpdated();
					serializedObject.ApplyModifiedProperties();
				}
				CheckPropertyHover( DisplayCooldownTextAnchor );
				
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( displayDecimalCooldown, new GUIContent( "Display Decimal", "Determines if the cooldown time should display the decimal point." ) );
				EditorGUILayout.PropertyField( cooldownTextScaleCurve, new GUIContent( "Text Scale Curve", "The scale curve of the text while processing the cooldown." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					for( int i = 0; i < targ.QuickbarParents[ 0 ].QuickbarButtons.Count; i++ )
					{
						Undo.RecordObject( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownImage, "Cooldown Test" );

						if( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText != null )
							Undo.RecordObject( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText, "Cooldown Text Test" );
						
						targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].UpdateCooldown( cooldownTestValue, cooldownTimeMax );

						if( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText != null && cooldownTestValue == 0.0f )
						{
							targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText.rectTransform.localScale = Vector3.one;
							targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText.text = "00";
						}
					}
				}
				EditorGUI.indentLevel--;
				EditorGUI.EndDisabledGroup();
				GUILayout.Space( 1 );
				// ------------------------------ END COOLDOWN TEXT SETTINGS ------------------------------ //
			}
			EditorGUILayout.EndVertical();
			// -------------------------- END COOLDOWN SETTINGS -------------------------- //

			// ------------------------------ ICON SETTINGS ----------------------------- //
			EditorGUILayout.BeginVertical( "Box" );
			if( DisplayCollapsibleBoxSection( "Icon", "UMQ_IconSettings" ) )
			{
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( iconScale, 0.0f, 2.0f, new GUIContent( "Icon Scale", "The scale of the icon for the button." ) );
				if( EditorGUI.EndChangeCheck() )
					serializedObject.ApplyModifiedProperties();


				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( useIconMask, new GUIContent( "Use Icon Mask", "Determines if the button should use a mask for the icon." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					CheckForIconMaskObjects();
				}

				EditorGUI.BeginDisabledGroup( !useIconMask.boolValue );
				EditorGUI.indentLevel++;
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( iconMaskSprite, new GUIContent( "Mask Sprite", "The sprite to use for the icon mask." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
						{
							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIconMask == null )
								continue;

							Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIconMask, "Update Icon Mask Sprite" );
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIconMask.sprite = targ.iconMaskSprite;
						}
					}
				}
				EditorGUI.indentLevel--;
				EditorGUI.EndDisabledGroup();

				EditorGUI.BeginChangeCheck();
				tempIcon = ( Sprite )EditorGUILayout.ObjectField( "Temporary Icon", tempIcon, typeof( Sprite ), false );
				if( EditorGUI.EndChangeCheck() )
				{
					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
						{
							Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon, "Update Temp Icon" );
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.enabled = false;
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.sprite = tempIcon;
							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.color == Color.clear )
								targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.color = Color.white;
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.enabled = true;
						}
					}
				}
				GUILayout.Space( 1 );
			}
			EditorGUILayout.EndVertical();
			// ---------------------------- END ICON SETTINGS -------------------------- //

			// ------------------------------ COUNT TEXT ------------------------------ //
			valueChanged = false;
			EditorGUILayout.BeginVertical( "Box" );
			if( DisplayCollapsibleBoxSection( "Count Text", "UMQ_CountTextSettings", useCountText, ref valueChanged ) )
			{
				DisplayCountTextRect.hover = false;

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( countTextSize, 0.0f, 1.0f, new GUIContent( "Text Size", "The size of the count text." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();
					DisplayCountTextRect.PropertyUpdated();

					if( !countTextStyle )
					{
						countTextStyle = true;
						UpdateQuickbarSprites();
					}
				}
				CheckPropertyHover( DisplayCountTextRect );

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.Slider( countTextPosX, 0.0f, 100.0f, new GUIContent( "Horizontal Position", "The horizontal position of the count text in relation to the button." ) );
				EditorGUILayout.Slider( countTextPosY, 0.0f, 100.0f, new GUIContent( "Vertical Position", "The vertical position of the count text in relation to the button." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();
					DisplayCountTextRect.PropertyUpdated();

					if( !countTextStyle )
					{
						countTextStyle = true;
						UpdateQuickbarSprites();
					}
				}

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( countTextBackgroundSprite, new GUIContent( "Background Sprite", "The sprite to show behind the count text." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					CheckForCountTextBackgroundObjects();

					if( targ.countTextBackgroundSprite != null )
					{
						countTextStyle = true;
						UpdateQuickbarSprites();
					}
				}

				EditorGUILayout.BeginHorizontal();
				EditorGUI.BeginChangeCheck();
				countTextStyle = !GUILayout.Toggle( !countTextStyle, "  Default  ", EditorStyles.miniButtonLeft );
				if( EditorGUI.EndChangeCheck() )
				{
					if( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countText.text == string.Empty )
						countTextStyle = false;

					UpdateQuickbarSprites();
				}

				EditorGUI.BeginChangeCheck();
				countTextStyle = GUILayout.Toggle( countTextStyle, "Count Text", EditorStyles.miniButtonRight );
				if( EditorGUI.EndChangeCheck() )
				{
					if( targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].countText.text != string.Empty )
						countTextStyle = true;

					UpdateQuickbarSprites();
				}

				EditorGUILayout.EndHorizontal();
			}
			EditorGUILayout.EndVertical();
			if( valueChanged )
			{
				CheckForCountTextObjects();

				if( useCountText.boolValue )
				{
					countTextStyle = true;
					UpdateQuickbarSprites();
				}
				else
				{
					countTextStyle = false;
					UpdateQuickbarSprites();

					if( !targ.useCooldownText )
						EditorPrefs.SetBool( "UMQ_TextOptions", false );
				}
			}
			// ---------------------------- END COUNT TEXT ---------------------------- //

			// ----------------------------- TEXT OPTIONS ----------------------------- //
			EditorGUI.BeginDisabledGroup( !targ.useCooldownText && !targ.useCountText );
			EditorGUILayout.BeginVertical( "Box" );
			if( DisplayCollapsibleBoxSection( "Text Options", "UMQ_TextOptions" ) )
			{
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( textColor, new GUIContent( "Text Color", "The color to apply to the text components." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
						{
							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText != null )
							{
								Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText, "Update Text Color" );
								targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.color = textColor.colorValue;
							}

							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText != null )
							{
								Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText, "Update Text Color" );
								targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.color = textColor.colorValue;
							}
						}
					}
				}

				EditorGUI.BeginChangeCheck();
				textFont = ( Font )EditorGUILayout.ObjectField( "Font", textFont, typeof( Font ), false );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					if( textFont != null )
					{
						for( int i = 0; i < targ.QuickbarParents.Count; i++ )
						{
							for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
							{
								if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText != null )
								{
									Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText, "Update Text Font" );
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.enabled = false;
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.font = textFont;
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.enabled = true;
								}

								if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText != null )
								{
									Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText, "Update Text Font" );
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.enabled = false;
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.font = textFont;
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.enabled = true;
								}
							}
						}
					}
				}

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( textOutline, new GUIContent( "Text Outline", "Determines if the text should have an outline or not." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
						{
							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText != null )
							{
								if( textOutline.boolValue && !targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.GetComponent<Outline>() )
								{
									Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject, "Update Text Outline" );
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.AddComponent<Outline>();
								}

								if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.GetComponent<Outline>() )
								{
									Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.GetComponent<Outline>(), "Update Text Outline" );
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.GetComponent<Outline>().enabled = textOutline.boolValue;
								}
							}

							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText != null )
							{
								if( textOutline.boolValue && !targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.GetComponent<Outline>() )
								{
									Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject, "Update Text Outline" );
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.AddComponent<Outline>();
								}

								if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.GetComponent<Outline>() )
								{
									Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.GetComponent<Outline>(), "Update Text Outline" );
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.GetComponent<Outline>().enabled = textOutline.boolValue;
								}
							}
						}
					}
				}

				EditorGUI.BeginDisabledGroup( !targ.textOutline );
				{
					EditorGUI.indentLevel++;
					EditorGUI.BeginChangeCheck();
					EditorGUILayout.PropertyField( textOutlineColor, new GUIContent( "Outline Color", "The color to apply to the outline component." ) );
					if( EditorGUI.EndChangeCheck() )
					{
						serializedObject.ApplyModifiedProperties();

						for( int i = 0; i < targ.QuickbarParents.Count; i++ )
						{
							for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
							{
								if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText != null )
								{
									Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.GetComponent<Outline>(), "Update Outline Color" );
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.GetComponent<Outline>().effectColor = textOutlineColor.colorValue;
								}

								if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText != null )
								{
									Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.GetComponent<Outline>(), "Update Outline Color" );
									targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.GetComponent<Outline>().effectColor = textOutlineColor.colorValue;
								}
							}
						}
					}
					EditorGUI.indentLevel--;
				}
				EditorGUI.EndDisabledGroup();
				GUILayout.Space( 1 );
			}
			EditorGUILayout.EndVertical();
			EditorGUI.EndDisabledGroup();
			// --------------------------- END TEXT OPTIONS --------------------------- //

			// ----------------------------- BUTTON OVERLAY ----------------------------- //
			EditorGUILayout.BeginVertical( "Box" );
			if( DisplayCollapsibleBoxSection( "Button Overlay", "UMQ_ButtonOverlay" ) )
			{
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( useButtonOverlay, new GUIContent( "Use Button Overlay", "Determines if the button should use an overlay image." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					CheckForButtonOverlayObjects();
				}

				EditorGUI.BeginDisabledGroup( !useButtonOverlay.boolValue );
				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( buttonOverlaySprite, new GUIContent( "Overlay Sprite", "The sprite to be used for the overlay image." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
						{
							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage == null )
								continue;

							Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage, "Update Overlay Sprite" );
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage.sprite = targ.buttonOverlaySprite;
						}
					}
				}

				EditorGUI.BeginChangeCheck();
				EditorGUILayout.PropertyField( buttonOverlayColor, new GUIContent( "Image Color", "The color to apply to the overlay image." ) );
				if( EditorGUI.EndChangeCheck() )
				{
					serializedObject.ApplyModifiedProperties();

					for( int i = 0; i < targ.QuickbarParents.Count; i++ )
					{
						for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
						{
							if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage == null )
								continue;

							Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage, "Update Overlay Color" );
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage.color = targ.buttonOverlayColor;
						}
					}
				}
				EditorGUI.EndDisabledGroup();
				GUILayout.Space( 1 );
			}
			EditorGUILayout.EndVertical();
			// --------------------------- END BUTTON OVERLAY --------------------------- //

			// ------------------------------ CHILD HEIRARCHY ------------------------------ //
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField( "Reorder Child Hierarchy" );
			EditorPrefs.SetBool( "UMQ_ChildHierarchy", GUILayout.Toggle( EditorPrefs.GetBool( "UMQ_ChildHierarchy" ), EditorPrefs.GetBool( "UMQ_ChildHierarchy" ) == true ? "-" : "+", EditorStyles.miniButton, GUILayout.Width( 20 ) ) );
			EditorGUILayout.EndHorizontal();
			if( EditorPrefs.GetBool( "UMQ_ChildHierarchy" ) )
				childObjects.DoLayoutList();
			// ------------------------------ END CHILD HEIRARCHY ------------------------------ //
		}

		DisplayHeaderDropdown( "Script Reference", "UUI_ScriptReference" );
		if( EditorPrefs.GetBool( "UUI_ScriptReference" ) )
		{
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField( quickbarName, new GUIContent( "Quickbar Name", "The name to be used for reference from scripts." ) );
			if( EditorGUI.EndChangeCheck() )
			{
				serializedObject.ApplyModifiedProperties();

				NameDuplicate = DuplicateQuickbarName();
				NameUnassigned = targ.quickbarName == string.Empty ? true : false;
				NameAssigned = NameDuplicate == false && targ.quickbarName != string.Empty ? true : false;
			}

			if( NameUnassigned )
				EditorGUILayout.HelpBox( "Please make sure to assign a name so that this Ultimate Mobile Quickbar can be referenced from your scripts.", MessageType.Warning );

			if( NameDuplicate )
				EditorGUILayout.HelpBox( "This name has already been used in your scene. Please make sure to make the Quickbar Name unique.", MessageType.Error );

			if( NameAssigned )
			{
				EditorGUILayout.BeginVertical( "Box" );
				GUILayout.Space( 1 );
				EditorGUILayout.LabelField( "Example Code Generator", EditorStyles.boldLabel );

				exampleCodeIndex = EditorGUILayout.Popup( "Function", exampleCodeIndex, ExampleCodeOptions.ToArray() );

				EditorGUILayout.LabelField( "Function Description", EditorStyles.boldLabel );
				GUIStyle wordWrappedLabel = new GUIStyle( GUI.skin.label ) { wordWrap = true };
				EditorGUILayout.LabelField( ExampleCodes[ exampleCodeIndex ].optionDescription, wordWrappedLabel );

				EditorGUILayout.LabelField( "Example Code", EditorStyles.boldLabel );
				GUIStyle wordWrappedTextArea = new GUIStyle( GUI.skin.textArea ) { wordWrap = true };
				EditorGUILayout.TextArea( string.Format( ExampleCodes[ exampleCodeIndex ].basicCode, quickbarName.stringValue, 0 ), wordWrappedTextArea );

				if( exampleCodeIndex <= 1 )
				{
					EditorGUILayout.LabelField( "Needed Variable", EditorStyles.boldLabel );
					EditorGUILayout.TextArea( "UltimateMobileQuickbarButtonInfo quickbarButtonInfo;", wordWrappedTextArea );
				}

				GUILayout.Space( 1 );
				EditorGUILayout.EndVertical();
			}

			if( GUILayout.Button( "Open Documentation" ) )
				UltimateMobileQuickbarReadmeEditor.OpenReadmeDocumentation();
		}

		if( EditorPrefs.GetBool( "UUI_DevelopmentMode" ) )
		{
			EditorGUILayout.Space();
			GUIStyle toolbarStyle = new GUIStyle( EditorStyles.toolbarButton ) { alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, fontSize = 11, richText = true };
			GUILayout.BeginHorizontal();
			GUILayout.Space( -10 );
			showDefaultInspector = GUILayout.Toggle( showDefaultInspector, ( showDefaultInspector ? "▼" : "►" ) + "<color=#ff0000ff>Development Inspector</color>", toolbarStyle );
			GUILayout.EndHorizontal();
			if( showDefaultInspector )
			{
				EditorGUILayout.Space();

				base.OnInspectorGUI();
			}
		}

		EditorGUILayout.Space();
		
		Repaint();
	}

	bool GetCanvasError ()
	{
		// If the selection is currently empty, then return false.
		if( Selection.activeGameObject == null )
			return false;

		// If the selection is actually the prefab within the Project window, then return no errors.
		if( AssetDatabase.Contains( Selection.activeGameObject ) )
			return false;

		// If parentCanvas is unassigned, then get a new canvas and return no errors.
		if( parentCanvas == null )
		{
			parentCanvas = GetParentCanvas();

			if( parentCanvas == null )
				return false;
		}

		// If the parentCanvas is not enabled, then return true for errors.
		if( parentCanvas.enabled == false )
			return true;

		// If the canvas' renderMode is not the needed one, then return true for errors.
		if( parentCanvas.renderMode == RenderMode.WorldSpace )
			return true;

		//// If the canvas has a CanvasScaler component and it is not the correct option.
		//if( parentCanvas.GetComponent<CanvasScaler>() && parentCanvas.GetComponent<CanvasScaler>().uiScaleMode != CanvasScaler.ScaleMode.ConstantPixelSize )
		//	return true;

		return false;
	}

	Canvas GetParentCanvas ()
	{
		if( Selection.activeGameObject == null )
			return null;

		// Store the current parent.
		Transform parent = Selection.activeGameObject.transform.parent;

		// Loop through parents as long as there is one.
		while( parent != null )
		{
			// If there is a Canvas component, return that gameObject.
			if( parent.transform.GetComponent<Canvas>() && parent.transform.GetComponent<Canvas>().enabled == true )
				return parent.transform.GetComponent<Canvas>();

			// Else, shift to the next parent.
			parent = parent.transform.parent;
		}
		if( parent == null && !AssetDatabase.Contains( Selection.activeGameObject ) )
			RequestCanvas( Selection.activeGameObject );

		return null;
	}

	void GenerateNewQuickbarSet ()
	{
		GameObject gameObjectBase = new GameObject();
		gameObjectBase.AddComponent<RectTransform>();

		serializedObject.FindProperty( "QuickbarParents" ).arraySize++;
		serializedObject.ApplyModifiedProperties();

		int parentIndex = targ.QuickbarParents.Count - 1;
		GameObject parentGameObject = Instantiate( gameObjectBase, Vector3.zero, Quaternion.identity );
		CanvasGroup cg = parentGameObject.AddComponent<CanvasGroup>();
		cg.interactable = false;
		cg.blocksRaycasts = false;
		cg.ignoreParentGroups = false;

		if( parentIndex > 0 )
			cg.alpha = 0.0f;

		parentGameObject.name = "Quickbar Set " + parentIndex.ToString( "00" );
		parentGameObject.transform.SetParent( targ.transform );
		RectTransform parentTrans = parentGameObject.GetComponent<RectTransform>();
		parentTrans.anchorMin = new Vector2( 0.0f, 0.0f );
		parentTrans.anchorMax = new Vector2( 1.0f, 1.0f );
		parentTrans.offsetMin = Vector2.zero;
		parentTrans.offsetMax = Vector2.zero;
		parentTrans.localPosition = Vector3.zero;
		parentTrans.localScale = Vector3.one;

		gameObjectBase.AddComponent<CanvasRenderer>();
		gameObjectBase.AddComponent<Image>();
		gameObjectBase.GetComponent<Image>().raycastTarget = false;
		
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].quickbar", parentIndex ) ).objectReferenceValue = targ;
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].transform", parentIndex ) ).objectReferenceValue = parentTrans;
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].canvasGroup", parentIndex ) ).objectReferenceValue = cg;
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].setDisplayTransform", parentIndex ) ).objectReferenceValue = null;
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].setDisplayImage", parentIndex ) ).objectReferenceValue = null;
		quickbarCount.intValue = targ.QuickbarParents.Count;
		serializedObject.ApplyModifiedProperties();

		Undo.RegisterCreatedObjectUndo( parentGameObject, "Create Quickbar Button Objects" );
		
		// Reset the quickbar buttons array to zero count.
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons", parentIndex ) ).arraySize = 0;
		serializedObject.ApplyModifiedProperties();
		
		// Create a new button for each buttonPerQuickbar.
		for( int i = 0; i < targ.buttonPerQuickbar; i++ )
			CreateNewButton( gameObjectBase, parentIndex );

		// Check for any Set Display objects if needed.
		CheckForSetDisplayObjects();

		// Store our references since they have been updated.
		StoreReferences();
		
		// Destroy the base game object.
		DestroyImmediate( gameObjectBase );
	}

	void RemoveQuickbarSet ()
	{
		int parentIndex = targ.QuickbarParents.Count - 1;

		if( targ.QuickbarParents[ parentIndex ].setDisplayTransform != null )
			Undo.DestroyObjectImmediate( targ.QuickbarParents[ parentIndex ].setDisplayTransform.gameObject );

		Undo.DestroyObjectImmediate( targ.QuickbarParents[ parentIndex ].transform.gameObject );
		serializedObject.FindProperty( "QuickbarParents" ).DeleteArrayElementAtIndex( parentIndex );
		quickbarCount.intValue--;
		serializedObject.ApplyModifiedProperties();

		StoreReferences();
	}

	void AddButtonPerQuickbar ()
	{
		buttonPerQuickbar.intValue++;
		serializedObject.ApplyModifiedProperties();

		GameObject gameObjectBase = new GameObject();
		gameObjectBase.AddComponent<RectTransform>();
		gameObjectBase.AddComponent<CanvasRenderer>();
		gameObjectBase.AddComponent<Image>();

		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
			CreateNewButton( gameObjectBase, i );

		DestroyImmediate( gameObjectBase );
	}

	void RemoveButtonPerQuickbar ()
	{
		buttonPerQuickbar.intValue--;
		serializedObject.ApplyModifiedProperties();

		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
		{
			Undo.DestroyObjectImmediate( targ.QuickbarParents[ i ].QuickbarButtons[ targ.QuickbarParents[ i ].QuickbarButtons.Count - 1 ].buttonTransform.gameObject );
			serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons", i ) ).arraySize--;
			serializedObject.ApplyModifiedProperties();
		}
		StoreReferences();
	}

	void CreateNewButton ( GameObject gameObjectBase, int parentIndex )
	{
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons", parentIndex ) ).arraySize++;
		serializedObject.ApplyModifiedProperties();

		int buttonIndex = targ.QuickbarParents[ parentIndex ].QuickbarButtons.Count - 1;

		// BUTTON //
		GameObject buttonImage = Instantiate( gameObjectBase, Vector3.zero, Quaternion.identity );
		buttonImage.transform.SetParent( targ.QuickbarParents[ parentIndex ].transform );
		buttonImage.name = "Quickbar Button " + buttonIndex.ToString( "00" );
		buttonImage.GetComponent<Image>().color = targ.buttonColor;
		if( targ.buttonSprite != null )
			buttonImage.GetComponent<Image>().sprite = targ.buttonSprite;
		RectTransform buttonTrans = buttonImage.GetComponent<RectTransform>();
		buttonTrans.anchorMin = new Vector2( 0.5f, 0.5f );
		buttonTrans.anchorMax = new Vector2( 0.5f, 0.5f );
		buttonTrans.pivot = new Vector2( 0.5f, 0.5f );
		buttonTrans.localScale = Vector3.one;

		// ICON //
		GameObject buttonIcon = Instantiate( gameObjectBase, Vector3.zero, Quaternion.identity );
		buttonIcon.transform.SetParent( buttonTrans );
		buttonIcon.gameObject.name = "Button Icon " + buttonIndex.ToString( "00" );
		RectTransform iconTrans = buttonIcon.GetComponent<RectTransform>();
		iconTrans.anchorMin = new Vector2( 0.0f, 0.0f );
		iconTrans.anchorMax = new Vector2( 1.0f, 1.0f );
		iconTrans.offsetMin = Vector2.zero;
		iconTrans.offsetMax = Vector2.zero;
		iconTrans.localScale = Vector3.one;

		if( tempIcon != null )
		{
			buttonIcon.GetComponent<Image>().sprite = tempIcon;
			buttonIcon.GetComponent<Image>().color = Color.white;
		}
		else if( targ.QuickbarParents.Count > 0 && targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonIcon != null && targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonIcon.sprite != null )
		{
			buttonIcon.GetComponent<Image>().sprite = targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].buttonIcon.sprite;
			buttonIcon.GetComponent<Image>().color = Color.white;
		}
		else
		{
			buttonIcon.GetComponent<Image>().sprite = null;
			buttonIcon.GetComponent<Image>().color = Color.clear;
		}

		// COOLDOWN //
		GameObject cooldownImage = Instantiate( gameObjectBase, Vector3.zero, Quaternion.identity );
		cooldownImage.transform.SetParent( buttonTrans );
		cooldownImage.gameObject.name = "Cooldown Image " + buttonIndex.ToString( "00" );

		Image imageComponent = cooldownImage.GetComponent<Image>();
		imageComponent.color = targ.cooldownColor;
		if( targ.cooldownSprite != null )
			imageComponent.sprite = targ.cooldownSprite;
		imageComponent.type = Image.Type.Filled;
		imageComponent.fillMethod = fillMethod;
		imageComponent.fillAmount = targ.QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].cooldownImage == null ? 0.0f : targ.QuickbarParents[ parentIndex ].QuickbarButtons[ buttonIndex ].cooldownImage.fillAmount;
		RectTransform cooldownTrans = cooldownImage.GetComponent<RectTransform>();
		cooldownTrans.anchorMin = new Vector2( 0.0f, 0.0f );
		cooldownTrans.anchorMax = new Vector2( 1.0f, 1.0f );
		cooldownTrans.offsetMin = Vector2.zero;
		cooldownTrans.offsetMax = Vector2.zero;
		cooldownTrans.localScale = Vector3.one;

		targ.QuickbarParents[ parentIndex ].QuickbarButtons[ targ.QuickbarParents[ parentIndex ].QuickbarButtons.Count - 1 ] = new UltimateMobileQuickbar.QuickbarButton();
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].buttonTransform", parentIndex, buttonIndex ) ).objectReferenceValue = buttonTrans;
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].cooldownImage", parentIndex, buttonIndex ) ).objectReferenceValue = cooldownImage.GetComponent<Image>();
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].buttonIcon", parentIndex, buttonIndex ) ).objectReferenceValue = buttonIcon.GetComponent<Image>();
		
		// NULL VALUES //
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].cooldownText", parentIndex, buttonIndex ) ).objectReferenceValue = null;
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].buttonOverlayImage", parentIndex, buttonIndex ) ).objectReferenceValue = null;
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].countText", parentIndex, buttonIndex ) ).objectReferenceValue = null;
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].countTextBackground", parentIndex, buttonIndex ) ).objectReferenceValue = null;
		serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].buttonIconMask", parentIndex, buttonIndex ) ).objectReferenceValue = null;
		serializedObject.ApplyModifiedProperties();

		Undo.RegisterCreatedObjectUndo( buttonImage, "Create Quickbar Button Objects" );
		Undo.RegisterCreatedObjectUndo( cooldownImage, "Create Quickbar Button Objects" );
		Undo.RegisterCreatedObjectUndo( buttonIcon, "Create Quickbar Button Objects" );
		
		CheckAllAdditionalObjects();
	}

	// OPTIONAL OBJECTS CHECK //
	void CheckAllAdditionalObjects ()
	{
		CheckForButtonCooldownTextObjects();
		CheckForButtonOverlayObjects();
		CheckForCountTextObjects();
		CheckForCountTextBackgroundObjects();
		CheckForIconMaskObjects();
		UpdateReorderChildren();
	}

	void CheckForSetDisplayObjects ()
	{
		if( targ.useSetDisplay )
		{
			if( targ.setDisplayParentTransform != null )
			{
				Undo.RecordObject( targ.setDisplayParentTransform.gameObject, "Enable Set Display" );
				targ.setDisplayParentTransform.gameObject.SetActive( true );
			}
			else if( targ.setDisplayParentTransform == null )
			{
				GameObject newGameObject = new GameObject();
				newGameObject.AddComponent<RectTransform>();

				GameObject setDisplayGameObject = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
				setDisplayGameObject.transform.SetParent( targ.transform );
				setDisplayGameObject.transform.SetAsFirstSibling();
				setDisplayGameObject.name = "Set Display Images";
				RectTransform setDisplayParentTransform = setDisplayGameObject.GetComponent<RectTransform>();
				setDisplayParentTransform.anchorMin = new Vector2( 0.0f, 0.0f );
				setDisplayParentTransform.anchorMax = new Vector2( 1.0f, 1.0f );
				setDisplayParentTransform.offsetMin = Vector2.zero;
				setDisplayParentTransform.offsetMax = Vector2.zero;
				setDisplayParentTransform.localPosition = Vector3.zero;
				setDisplayParentTransform.localScale = Vector3.one;

				serializedObject.FindProperty( "setDisplayParentTransform" ).objectReferenceValue = setDisplayParentTransform;
				serializedObject.ApplyModifiedProperties();

				Undo.RegisterCreatedObjectUndo( setDisplayGameObject, "Create Quickbar Button Objects" );
				DestroyImmediate( newGameObject );
			}

			for( int i = 0; i < targ.QuickbarParents.Count; i++ )
			{
				if( targ.QuickbarParents[ i ].setDisplayTransform == null )
				{
					GameObject newGameObject = new GameObject();
					newGameObject.AddComponent<RectTransform>();
					newGameObject.AddComponent<CanvasRenderer>();
					newGameObject.AddComponent<Image>();
					newGameObject.GetComponent<Image>().raycastTarget = false;
					newGameObject.GetComponent<Image>().color = i == 0 ? targ.setDisplaySelectedColor : targ.setDisplayDefaultColor;
					if( targ.setDisplaySprite != null )
						newGameObject.GetComponent<Image>().sprite = targ.setDisplaySprite;

					GameObject setDisplayImage = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
					setDisplayImage.transform.SetParent( targ.setDisplayParentTransform );
					setDisplayImage.name = "Set Display Image " + i.ToString( "00" );

					serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].setDisplayTransform", i ) ).objectReferenceValue = setDisplayImage.GetComponent<RectTransform>();
					serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].setDisplayImage", i ) ).objectReferenceValue = setDisplayImage.GetComponent<Image>();
					serializedObject.ApplyModifiedProperties();

					Undo.RegisterCreatedObjectUndo( setDisplayImage, "Create Quickbar Set Display" );
					DestroyImmediate( newGameObject );
				}
			}
		}
		else if( !targ.useSetDisplay && targ.setDisplayParentTransform != null )
		{
			Undo.RecordObject( targ.setDisplayParentTransform.gameObject, "Disable Set Display" );
			targ.setDisplayParentTransform.gameObject.SetActive( false );
		}
	}

	void CheckForButtonCooldownTextObjects ()
	{
		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
		{
			for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				if( !targ.useCooldownText )
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText != null )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject, "Disable Cooldown Text" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.SetActive( false );
					}
				}
				else
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText == null )
					{
						GameObject newTextObject = new GameObject();
						newTextObject.AddComponent<RectTransform>();
						newTextObject.AddComponent<CanvasRenderer>();
						newTextObject.AddComponent<Text>();

						GameObject cooldownText = Instantiate( newTextObject, Vector3.zero, Quaternion.identity );
						cooldownText.transform.SetParent( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform );
						cooldownText.gameObject.name = "Cooldown Text " + n.ToString( "00" );

						Text textComponent = cooldownText.GetComponent<Text>();
						textComponent.text = targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownText == null ? "00" : targ.QuickbarParents[ 0 ].QuickbarButtons[ 0 ].cooldownText.text;
						textComponent.alignment = TextAnchor.MiddleCenter;
						textComponent.alignByGeometry = true;
						textComponent.resizeTextForBestFit = true;
						textComponent.resizeTextMinSize = 0;
						textComponent.resizeTextMaxSize = 300;
						textComponent.color = textColor.colorValue;
						textComponent.raycastTarget = false;

						if( textFont != null )
							textComponent.font = textFont;

						if( textOutline.boolValue )
						{
							Outline textOutline = cooldownText.AddComponent<Outline>();
							textOutline.effectColor = textOutlineColor.colorValue;
						}
						
						serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].cooldownText", i, n ) ).objectReferenceValue = textComponent;
						serializedObject.ApplyModifiedProperties();

						Undo.RegisterCreatedObjectUndo( cooldownText, "Create Quickbar Button Objects" );
						DestroyImmediate( newTextObject );
					}
					else
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject, "Enable Cooldown Text" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.SetActive( true );

						if( targ.textOutline )
						{
							if( !targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.GetComponent<Outline>() )
								targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.gameObject.AddComponent<Outline>();
							else
								targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.GetComponent<Outline>().enabled = true;

							targ.QuickbarParents[ i ].QuickbarButtons[ n ].cooldownText.GetComponent<Outline>().effectColor = textOutlineColor.colorValue;
						}
					}
				}
			}
		}

		StoreChildTransforms();
	}

	void CheckForButtonOverlayObjects ()
	{
		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
		{
			for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				if( !targ.useButtonOverlay )
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage != null )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage.gameObject, "Disable Button Overlay" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage.gameObject.SetActive( false );
					}
				}
				else
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage == null )
					{
						GameObject newGameObject = new GameObject();
						newGameObject.AddComponent<RectTransform>();
						newGameObject.AddComponent<CanvasRenderer>();
						newGameObject.AddComponent<Image>();
						newGameObject.GetComponent<Image>().raycastTarget = false;
						newGameObject.GetComponent<Image>().color = targ.buttonOverlayColor;
						if( targ.buttonOverlaySprite != null )
							newGameObject.GetComponent<Image>().sprite = targ.buttonOverlaySprite;

						GameObject buttonOverlayImage = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
						buttonOverlayImage.transform.SetParent( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform );
						buttonOverlayImage.transform.SetAsLastSibling();
						buttonOverlayImage.gameObject.name = "Button Overlay " + n.ToString( "00" );

						RectTransform buttonOverlayTrans = buttonOverlayImage.GetComponent<RectTransform>();
						buttonOverlayTrans.anchorMin = new Vector2( 0.0f, 0.0f );
						buttonOverlayTrans.anchorMax = new Vector2( 1.0f, 1.0f );
						buttonOverlayTrans.offsetMin = Vector2.zero;
						buttonOverlayTrans.offsetMax = Vector2.zero;
						buttonOverlayTrans.localScale = Vector3.one;

						serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].buttonOverlayImage", i, n ) ).objectReferenceValue = buttonOverlayImage.GetComponent<Image>();
						serializedObject.ApplyModifiedProperties();

						Undo.RegisterCreatedObjectUndo( buttonOverlayImage, "Create Quickbar Button Objects" );
						DestroyImmediate( newGameObject );
					}
					else
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage.gameObject, "Enable Button Overlay" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage.gameObject.SetActive( true );

						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage, "Enable Button Overlay" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage.color = targ.buttonOverlayColor;
						if( targ.buttonOverlaySprite != null )
							targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonOverlayImage.sprite = targ.buttonOverlaySprite;
					}
				}
			}
		}

		StoreChildTransforms();
		UpdateQuickbarSprites();
	}

	void CheckForCountTextObjects ()
	{
		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
		{
			for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				if( !targ.useCountText )
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText != null )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject, "Disable Count Text" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.SetActive( false );
					}
				}
				else
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText == null )
					{
						GameObject newTextObject = new GameObject();
						newTextObject.AddComponent<RectTransform>();
						newTextObject.AddComponent<CanvasRenderer>();

						GameObject countText = Instantiate( newTextObject, Vector3.zero, Quaternion.identity );
						countText.transform.SetParent( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform );
						countText.gameObject.name = "Count Text " + n.ToString( "00" );

						Text textComponent = countText.AddComponent<Text>();
						textComponent.text = "00";
						textComponent.alignment = TextAnchor.MiddleCenter;
						textComponent.alignByGeometry = true;
						textComponent.resizeTextForBestFit = true;
						textComponent.resizeTextMinSize = 0;
						textComponent.resizeTextMaxSize = 300;
						textComponent.color = textColor.colorValue;
						textComponent.raycastTarget = false;

						if( textFont != null )
							textComponent.font = textFont;

						if( textOutline.boolValue )
						{
							Outline textOutline = countText.AddComponent<Outline>();
							textOutline.effectColor = textOutlineColor.colorValue;
						}

						serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].countText", i, n ) ).objectReferenceValue = textComponent;
						serializedObject.ApplyModifiedProperties();

						Undo.RegisterCreatedObjectUndo( countText, "Create Quickbar Button Objects" );
						DestroyImmediate( newTextObject );
					}
					else
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject, "Enable Count Text" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.SetActive( true );

						if( targ.textOutline )
						{
							if( !targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.GetComponent<Outline>() )
								targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.gameObject.AddComponent<Outline>();
							else
								targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.GetComponent<Outline>().enabled = true;

							targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.GetComponent<Outline>().effectColor = textOutlineColor.colorValue;
						}
					}
				}
			}
		}
		
		StoreChildTransforms();
	}

	void CheckForCountTextBackgroundObjects ()
	{
		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
		{
			for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				if( targ.countTextBackgroundSprite == null )
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground != null )
						Undo.DestroyObjectImmediate( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground.gameObject );
				}
				else if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground == null )
				{
					GameObject newGameObject = new GameObject();
					newGameObject.AddComponent<RectTransform>();
					newGameObject.AddComponent<CanvasRenderer>();
					newGameObject.AddComponent<Image>();
					newGameObject.GetComponent<Image>().raycastTarget = false;
					newGameObject.GetComponent<Image>().color = targ.buttonColor;
					if( targ.countTextBackgroundSprite != null )
						newGameObject.GetComponent<Image>().sprite = targ.countTextBackgroundSprite;

					GameObject countTextBackground = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
					countTextBackground.transform.SetParent( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform );
					countTextBackground.transform.SetSiblingIndex( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.transform.GetSiblingIndex() );
					countTextBackground.gameObject.name = "Count Text Background " + n.ToString( "00" );

					RectTransform countTextBackgroundTrans = countTextBackground.GetComponent<RectTransform>();
					countTextBackgroundTrans.anchorMin = new Vector2( 0.0f, 0.0f );
					countTextBackgroundTrans.anchorMax = new Vector2( 1.0f, 1.0f );
					countTextBackgroundTrans.offsetMin = Vector2.zero;
					countTextBackgroundTrans.offsetMax = Vector2.zero;
					countTextBackgroundTrans.localScale = Vector3.one;

					serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].countTextBackground", i, n ) ).objectReferenceValue = countTextBackground.GetComponent<Image>();
					serializedObject.ApplyModifiedProperties();

					Undo.RegisterCreatedObjectUndo( countTextBackground, "Create Quickbar Button Objects" );
					DestroyImmediate( newGameObject );
				}
				else
				{
					Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground, "Update Count Text Background" );
					targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground.sprite = targ.countTextBackgroundSprite;
				}
			}
		}

		StoreChildTransforms();
		UpdateQuickbarSprites();
	}

	void CheckForIconMaskObjects ()
	{
		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
		{
			for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				if( !targ.useIconMask )
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIconMask != null )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.transform, "Update Icon Parent Transform" );
						Undo.SetTransformParent( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.transform, targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform, "Update Icon Parent Transform" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.transform.SetSiblingIndex( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIconMask.transform.GetSiblingIndex() );

						RectTransform iconTransform = targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.GetComponent<RectTransform>();
						iconTransform.offsetMin = Vector2.zero;
						iconTransform.offsetMax = Vector2.zero;
						iconTransform.localScale = Vector3.one;

						Undo.DestroyObjectImmediate( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIconMask.gameObject );
					}
				}
				else
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIconMask == null )
					{
						GameObject newGameObject = new GameObject();
						newGameObject.AddComponent<RectTransform>();
						newGameObject.AddComponent<CanvasRenderer>();

						GameObject iconMaskObject = Instantiate( newGameObject, Vector3.zero, Quaternion.identity );
						Undo.RegisterCreatedObjectUndo( iconMaskObject, "Create Quickbar Button Objects" );
						iconMaskObject.transform.SetParent( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonTransform );
						iconMaskObject.gameObject.name = "Icon Mask " + n.ToString( "00" );
						iconMaskObject.transform.SetSiblingIndex( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.transform.GetSiblingIndex() );

						RectTransform iconMaskTransform = iconMaskObject.GetComponent<RectTransform>();
						iconMaskTransform.anchorMin = new Vector2( 0.0f, 0.0f );
						iconMaskTransform.anchorMax = new Vector2( 1.0f, 1.0f );
						iconMaskTransform.offsetMin = Vector2.zero;
						iconMaskTransform.offsetMax = Vector2.zero;
						iconMaskTransform.localScale = Vector3.one;

						Image iconMaskImage = iconMaskObject.AddComponent<Image>();
						iconMaskImage.raycastTarget = false;
						iconMaskImage.sprite = targ.iconMaskSprite;

						Mask iconMaskImageMask = iconMaskObject.AddComponent<Mask>();
						iconMaskImageMask.showMaskGraphic = false;

						serializedObject.FindProperty( string.Format( "QuickbarParents.Array.data[{0}].QuickbarButtons.Array.data[{1}].buttonIconMask", i, n ) ).objectReferenceValue = iconMaskImage;
						serializedObject.ApplyModifiedProperties();

						Undo.SetTransformParent( targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.transform, iconMaskObject.transform, "Create Quickbar Button Objects" );

						RectTransform iconTransform = targ.QuickbarParents[ i ].QuickbarButtons[ n ].buttonIcon.GetComponent<RectTransform>();
						iconTransform.offsetMin = Vector2.zero;
						iconTransform.offsetMax = Vector2.zero;
						iconTransform.localScale = Vector3.one;

						DestroyImmediate( newGameObject );
					}
				}
			}
		}
		StoreChildTransforms();
	}
	
	void UpdateQuickbarSprites ()
	{
		for( int i = 0; i < targ.QuickbarParents.Count; i++ )
		{
			for( int n = 0; n < targ.QuickbarParents[ i ].QuickbarButtons.Count; n++ )
			{
				if( countTextStyle )
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText != null )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText, "Update Button Style" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.enabled = false;
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.text = "00";
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.enabled = true;
					}

					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground != null )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground.gameObject, "Update Button Style" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground.gameObject.SetActive( true );
					}
				}
				else
				{
					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText != null )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText, "Update Button Style" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.enabled = false;
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.text = "";
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countText.enabled = true;
					}

					if( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground != null )
					{
						Undo.RecordObject( targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground.gameObject, "Update Button Style" );
						targ.QuickbarParents[ i ].QuickbarButtons[ n ].countTextBackground.gameObject.SetActive( false );
					}
				}
			}
		}
	}

	void OnSceneGUI ()
	{
		if( targ == null || targ.relativeTransform == null || Selection.activeGameObject == null || Application.isPlaying || Selection.objects.Length > 1 )
			return;
		
		RectTransform trans = targ.transform.GetComponent<RectTransform>();
		Vector3 center = trans.position;

		if( parentCanvas == null )
			parentCanvas = GetParentCanvas();

		if( parentCanvas == null )
			return;

		DisplayOverallAngle.frames++;
		DisplayCenterAngle.frames++;
		DisplayButtonOrbitRadius.frames++;
		DisplaySetDisplayAngle.frames++;
		DisplaySetDisplayOrbitRadius.frames++;
		DisplayInputRadius.frames++;
		DisplaySwipeTransition.frames++;
		DisplayHeadingThreshold.frames++;
		DisplayCooldownTextAnchor.frames++;
		DisplayCountTextRect.frames++;

		if( targ.QuickbarParents.Count == 0 || targ.QuickbarParents[ 0 ].transform == null )
		{
			float angle = targ.overallAngle / targ.buttonPerQuickbar;
			float angleInRadians = ( targ.centerAngle <= 0 ? -angle : angle ) * Mathf.Deg2Rad;
			float modStartAngle = 90 - ( targ.centerAngle <= 0 ? -targ.centerAngle + ( targ.overallAngle / 2 ) : -targ.centerAngle - ( targ.overallAngle / 2 ) );
			float buttonRadius = ( trans.sizeDelta.x / 10 ) * ( targ.buttonSize / 2 );
			Vector3 calculatedParentPosition = targ.relativeTransform.position - new Vector3( targ.relativeTransform.sizeDelta.x * targ.relativeTransform.pivot.x, targ.relativeTransform.sizeDelta.y * targ.relativeTransform.pivot.y ) + ( Vector3 )( targ.relativeTransform.sizeDelta / 2 );

			Handles.color = colorDefault;
			if( DisplayButtonSize.HighlightGizmo )
				Handles.color = colorValueChanged;

			for( int i = 0; i < targ.buttonPerQuickbar; i++ )
			{
				Vector3 buttonPosition = Vector3.zero;
				buttonPosition.x -= ( Mathf.Cos( ( angleInRadians * i ) - ( modStartAngle * Mathf.Deg2Rad ) - ( -angleInRadians / 2 ) ) * ( targ.relativeTransform.sizeDelta.x * targ.buttonOrbitRadius ) );
				buttonPosition.y -= ( Mathf.Sin( ( angleInRadians * i ) - ( modStartAngle * Mathf.Deg2Rad ) - ( -angleInRadians / 2 ) ) * ( targ.relativeTransform.sizeDelta.x * targ.buttonOrbitRadius ) );
				Handles.DrawWireDisc( calculatedParentPosition + buttonPosition, Selection.activeGameObject.transform.forward, buttonRadius );
			}

			ShowAngles();
			
			if( DisplayButtonOrbitRadius.HighlightGizmo )
			{
				Handles.color = colorValueChanged;

				float startAngle = ( -targ.centerAngle + ( targ.overallAngle / 2 ) ) - 90;
				float endAngle = startAngle + -targ.overallAngle;
				Quaternion rot = Quaternion.AngleAxis( endAngle, Vector3.forward );
				Vector3 lDirection = rot * -Vector3.right;
				Handles.DrawWireArc( calculatedParentPosition, Vector3.forward, lDirection, targ.overallAngle, ( targ.relativeTransform.sizeDelta.x * ( targ.buttonOrbitRadius ) ) );
			}

			SceneView.RepaintAll();
			return;
		}

		if( EditorPrefs.GetBool( "UMQ_QuickbarPositioning" ) )
		{
			Handles.color = colorDefault;

			ShowAngles();
			
			if( DisplayButtonOrbitRadius.HighlightGizmo )
			{
				Handles.color = colorValueChanged;
				Quaternion rot = Quaternion.AngleAxis( ( ( -targ.centerAngle + ( targ.overallAngle / 2 ) ) - 90 ) - targ.overallAngle, targ.transform.forward );
				Vector3 lDirection = rot * -targ.transform.right;
				Handles.DrawWireArc( center, targ.transform.forward, lDirection, targ.overallAngle, ( targ.relativeTransform.sizeDelta.x * targ.buttonOrbitRadius ) * parentCanvas.transform.localScale.x );
			}

			if( EditorPrefs.GetBool( "UMQ_SetDisplaySettings" ) && targ.useSetDisplay )
			{
				float startAngle = -targ.setDisplayAngle + 90;
				float endAngle = startAngle + ( 180 - 22.5f );

				Handles.color = colorDefault;
				if( DisplaySetDisplayAngle.HighlightGizmo )
					Handles.color = colorValueChanged;
				
				Vector3 lineEnd = center;
				lineEnd.x += ( Mathf.Cos( startAngle * Mathf.Deg2Rad ) * ( targ.relativeTransform.sizeDelta.x * ( targ.setDisplayOrbitDistance ) ) );
				lineEnd.y += ( Mathf.Sin( startAngle * Mathf.Deg2Rad ) * ( targ.relativeTransform.sizeDelta.x * ( targ.setDisplayOrbitDistance ) ) );
				Vector3 heading = lineEnd - center;
				heading = heading / heading.magnitude;
				Handles.DrawLine( center, center + ( trans.TransformDirection( heading * targ.relativeTransform.sizeDelta.x ) * ( targ.setDisplayOrbitDistance ) ) * parentCanvas.transform.localScale.x );

				Handles.color = colorDefault;
				if( DisplaySetDisplayOrbitRadius.HighlightGizmo )
					Handles.color = colorValueChanged;

				Quaternion rot = Quaternion.AngleAxis( endAngle, targ.transform.forward );
				Vector3 lDirection = rot * -targ.transform.right;
				Handles.DrawWireArc( center, targ.transform.forward, lDirection, 45, ( targ.relativeTransform.sizeDelta.x * targ.setDisplayOrbitDistance ) * parentCanvas.transform.localScale.x );
			}
		}
		
		for( int i = 0; i < targ.QuickbarParents[ 0 ].QuickbarButtons.Count; i++ )
		{
			Handles.color = colorDefault;
			
			if( EditorPrefs.GetBool( "UMQ_QuickbarSettings" ) )
			{
				if( EditorPrefs.GetBool( "UMQ_InputSettings" ) )
				{
					Handles.color = colorDefault;
					if( DisplayInputRadius.HighlightGizmo )
						Handles.color = colorValueChanged;

					Handles.DrawWireDisc( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.TransformPoint( Vector3.zero ), targ.transform.forward, ( ( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.sizeDelta.x / 2 ) * targ.quickbarButtonInputRadius ) * parentCanvas.transform.localScale.x );
					
					if( DisplaySwipeTransition.HighlightGizmo && targ.swipeTransition != UltimateMobileQuickbar.SwipeTransition.Disabled )
					{
						float handleSize = ( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.sizeDelta.x / 2 ) * parentCanvas.transform.localScale.x;
						Vector3 thisButtonPosition = targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].thisButtonPosition;
						Vector3 nextButtonPosition = targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].nextButtonPosition;
						Vector3 previousButtonPosition = targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].previousButtonPosition;

						if( targ.swipeTransition == UltimateMobileQuickbar.SwipeTransition.CounterClockwise )
						{
							nextButtonPosition = targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].previousButtonPosition;
							previousButtonPosition = targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].nextButtonPosition;
						}
						
						Vector2 difference = nextButtonPosition - thisButtonPosition;
						float sign = ( nextButtonPosition.y < thisButtonPosition.y ) ? -1.0f : 1.0f;
						float angle = Vector2.Angle( targ.transform.right, difference ) * sign;
						
						Handles.color = Color.green;
						Handles.ArrowHandleCap( 0, targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.position, targ.transform.rotation * Quaternion.Euler( -angle, 90, 0 ), handleSize, EventType.Repaint );
						
						difference = previousButtonPosition - thisButtonPosition;
						sign = ( previousButtonPosition.y < thisButtonPosition.y ) ? -1.0f : 1.0f;
						angle = Vector2.Angle( targ.transform.right, difference ) * sign;

						Handles.color = Color.red;
						Handles.ArrowHandleCap( 0, targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.position, targ.transform.rotation * Quaternion.Euler( -angle, 90, 0 ), handleSize, EventType.Repaint );
					}

					if( DisplayHeadingThreshold.HighlightGizmo )
					{
						for( int t = 0; t < 360; t += 4 )
						{
							Vector2 inputPos = targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.position;
							inputPos.x += ( Mathf.Cos( t * Mathf.Deg2Rad ) * ( ( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.sizeDelta.x / 2 ) ) );
							inputPos.y += ( Mathf.Sin( t * Mathf.Deg2Rad ) * ( ( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.sizeDelta.x / 2 ) ) );
							
							Vector2 nextButtonHeading = targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].nextButtonPosition - targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].thisButtonPosition;
							Vector2 previousButtonHeading = targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].previousButtonPosition - targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].thisButtonPosition;
							Vector2 inputHeading = ( Vector3 )inputPos - targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.position;
							nextButtonHeading = nextButtonHeading.normalized;
							inputHeading = inputHeading.normalized;
							previousButtonHeading = previousButtonHeading.normalized;

							float previousInputDot = Vector2.Dot( previousButtonHeading, inputHeading );
							float nextInputDot = Vector2.Dot( nextButtonHeading, inputHeading );

							Handles.color = colorDefault;
							if( nextInputDot > targ.swipeHeadingThreshold || previousInputDot > targ.swipeHeadingThreshold )
								Handles.color = colorValueChanged;
							
							Vector3 heading = ( Vector3 )inputPos - targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.position;
							heading = heading / heading.magnitude;
							Handles.DrawLine( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.position, targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.position + trans.TransformDirection( heading * ( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.sizeDelta / 2 ) ) * parentCanvas.transform.localScale.x );
						}
					}
				}
				
				if( EditorPrefs.GetBool( "UMQ_CooldownSettings" ) && targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText != null )
				{
					if( DisplayCooldownTextAnchor.HighlightGizmo )
					{
						Handles.color = colorValueChanged;

						targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText.text = "00";
						targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText.rectTransform.localScale = Vector3.one;

						DrawWireBox( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].cooldownText.rectTransform );
					}
				}

				if( EditorPrefs.GetBool( "UMQ_CountTextSettings" ) && targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].countText != null && countTextStyle )
				{
					if( DisplayCountTextRect.HighlightGizmo )
					{
						Handles.color = colorValueChanged;

						targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].countText.text = "00";

						DrawWireBox( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].countText.rectTransform );
					}
				}
			}

			GUIStyle style = new GUIStyle();
			style.normal.textColor = Color.white;
			style.alignment = TextAnchor.MiddleCenter;
			Handles.Label( targ.transform.TransformPoint( targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.localPosition - new Vector3( 0, targ.QuickbarParents[ 0 ].QuickbarButtons[ i ].buttonTransform.sizeDelta.y / 2, 0 ) ), i.ToString( "00" ), style );
		}
		
		SceneView.RepaintAll();
	}
	
	void ShowAngles ()
	{
		RectTransform trans = targ.transform.GetComponent<RectTransform>();
		Vector3 center = trans.position;
		float startAngle = ( -targ.centerAngle + ( targ.overallAngle / 2 ) ) - 90;
		float centerAngle = ( -targ.centerAngle ) - 90;
		float endAngle = startAngle + -targ.overallAngle;
		float gizmoRadiusModifier = 1.5f;
		Vector3 lineEnd = center;
		Vector2 relativeSizeDelta = targ.relativeTransform.sizeDelta;
		Vector3 heading = Vector3.zero;

		// CENTER ANGLE //
		Handles.color = colorDefault;
		if( DisplayCenterAngle.HighlightGizmo )
			Handles.color = colorValueChanged;

		// Draw the center angle.
		lineEnd = center;
		lineEnd.x -= ( Mathf.Cos( centerAngle * Mathf.Deg2Rad ) * ( relativeSizeDelta.x * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) );
		lineEnd.y -= ( Mathf.Sin( centerAngle * Mathf.Deg2Rad ) * ( relativeSizeDelta.x * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) );
		heading = lineEnd - center;
		heading = heading / heading.magnitude;
		Handles.DrawLine( center, center + ( trans.TransformDirection( heading * relativeSizeDelta ) * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) * parentCanvas.transform.localScale.x );
		
		// OVERALL ANGLE //
		Handles.color = colorDefault;
		if( DisplayOverallAngle.HighlightGizmo )
			Handles.color = colorValueChanged;

		// Draw the starting angle line of the overall angle.
		lineEnd = center;
		lineEnd.x -= ( Mathf.Cos( startAngle * Mathf.Deg2Rad ) * ( relativeSizeDelta.x * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) );
		lineEnd.y -= ( Mathf.Sin( startAngle * Mathf.Deg2Rad ) * ( relativeSizeDelta.x * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) );
		heading = lineEnd - center;
		heading = heading / heading.magnitude;
		Handles.DrawLine( center, center + ( trans.TransformDirection( heading * relativeSizeDelta ) * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) * parentCanvas.transform.localScale.x );
		
		// Display a line to the end of the overall angle.
		lineEnd = center;
		lineEnd.x -= ( Mathf.Cos( endAngle * Mathf.Deg2Rad ) * ( relativeSizeDelta.x * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) );
		lineEnd.y -= ( Mathf.Sin( endAngle * Mathf.Deg2Rad ) * ( relativeSizeDelta.x * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) );
		heading = lineEnd - center;
		heading = heading / heading.magnitude;
		Handles.DrawLine( center, center + ( trans.TransformDirection( heading * relativeSizeDelta ) * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) * parentCanvas.transform.localScale.x );
		
		// Draw the connecting wire arc.
		Quaternion rot = Quaternion.AngleAxis( endAngle, targ.transform.forward );
		Vector3 lDirection = rot * -targ.transform.right;
		Handles.DrawWireArc( center, targ.transform.forward, lDirection, targ.overallAngle, ( relativeSizeDelta.x * ( targ.buttonOrbitRadius * gizmoRadiusModifier ) ) * parentCanvas.transform.localScale.x );
	}

	void DrawWireBox ( RectTransform trans )
	{
		Vector3 topLeft = trans.rect.center + ( new Vector2( trans.rect.xMin, trans.rect.yMax ) );
		Vector3 topRight = trans.rect.center + ( new Vector2( trans.rect.xMax, trans.rect.yMax ) );
		Vector3 bottomLeft = trans.rect.center + ( new Vector2( trans.rect.xMin, trans.rect.yMin ) );
		Vector3 bottomRight = trans.rect.center + ( new Vector2( trans.rect.xMax, trans.rect.yMin ) );

		topLeft = trans.TransformPoint( topLeft );
		topRight = trans.TransformPoint( topRight );
		bottomRight = trans.TransformPoint( bottomRight );
		bottomLeft = trans.TransformPoint( bottomLeft );

		Handles.DrawLine( topLeft, topRight );
		Handles.DrawLine( topRight, bottomRight );
		Handles.DrawLine( bottomRight, bottomLeft );
		Handles.DrawLine( bottomLeft, topLeft );
	}

	// ---------------------------------< CANVAS CREATOR FUNCTIONS >--------------------------------- //
	private static void CreateNewCanvas ( GameObject child )
	{
		GameObject canvasObject = new GameObject( "Canvas" ) { layer = LayerMask.NameToLayer( "UI" ) };
		Canvas canvas = canvasObject.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvasObject.AddComponent<GraphicRaycaster>();
		canvasObject.AddComponent<CanvasScaler>();
		Undo.RegisterCreatedObjectUndo( canvasObject, "Create New Canvas" );
		Undo.SetTransformParent( child.transform, canvasObject.transform, "Create New Canvas" );

		CreateEventSystem();
	}

	private static void CreateEventSystem ()
	{
		Object esys = Object.FindObjectOfType<EventSystem>();
		if( esys == null )
		{
			GameObject eventSystem = new GameObject( "EventSystem" );
			esys = eventSystem.AddComponent<EventSystem>();
			eventSystem.AddComponent<StandaloneInputModule>();
			Undo.RegisterCreatedObjectUndo( eventSystem, "Create EventSystem" );
		}
	}

	public static void RequestCanvas ( GameObject child )
	{
		Canvas[] allCanvas = Object.FindObjectsOfType( typeof( Canvas ) ) as Canvas[];

		for( int i = 0; i < allCanvas.Length; i++ )
		{
			if( allCanvas[ i ].renderMode != RenderMode.WorldSpace && allCanvas[ i ].enabled )
			{
				child.transform.SetParent( allCanvas[ i ].transform, false );
				CreateEventSystem();
				return;
			}
		}
		CreateNewCanvas( child );
	}
	// -------------------------------< END CANVAS CREATOR FUNCTIONS >------------------------------- //
}