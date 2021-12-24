/* UltimateMobileQuickbarReadmeEditor.cs */
/* Written by Kaz Crowe */
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[InitializeOnLoad]
[CustomEditor( typeof( UltimateMobileQuickbarReadme ) )]
public class UltimateMobileQuickbarReadmeEditor : Editor
{
	static UltimateMobileQuickbarReadme readme;

	// LAYOUT STYLES //
	const string Indent = "    ";
	int sectionSpace = 20;
	int itemHeaderSpace = 10;
	int paragraphSpace = 5;
	GUIStyle titleStyle = new GUIStyle();
	GUIStyle sectionHeaderStyle = new GUIStyle();
	GUIStyle itemHeaderStyle = new GUIStyle();
	GUIStyle paragraphStyle = new GUIStyle();
	GUIStyle versionStyle = new GUIStyle();

	// PAGE INFORMATION //
	class PageInformation
	{
		public string pageName = "";
		public Vector2 scrollPosition = Vector2.zero;
		public delegate void TargetMethod ();
		public TargetMethod targetMethod;
	}
	static PageInformation mainMenu = new PageInformation() { pageName = "Product Manual" };
	static PageInformation gettingStarted = new PageInformation() { pageName = "Getting Started" };
	static PageInformation overview = new PageInformation() { pageName = "Overview" };
	static PageInformation documentation = new PageInformation() { pageName = "Documentation" };
	static PageInformation documentation_UMQ = new PageInformation() { pageName = "Documentation" };
	static PageInformation documentation_UMQBI = new PageInformation() { pageName = "Documentation" };
	static PageInformation versionHistory = new PageInformation() { pageName = "Version History" };
	static PageInformation importantChange = new PageInformation() { pageName = "Important Change" };
	static PageInformation thankYou = new PageInformation() { pageName = "Thank You!" };
	static PageInformation settings = new PageInformation() { pageName = "Settings" };
	static List<PageInformation> pageHistory = new List<PageInformation>();
	static PageInformation currentPage = new PageInformation();
	
	// OVERVIEW //
	bool showQuickbarPositioning = false, showQuickbarSettings = false;
	bool showScriptReference = false;

	// DOCUMENTATION //
	class DocumentationInfo
	{
		public string functionName = "";
		public bool showMore = false;
		public string[] parameter;
		public string returnType = "";
		public string description = "";
		public string codeExample = "";
	}
	DocumentationInfo[] UltimateMobileQuickbar_StaticFunctions = new DocumentationInfo[]
	{
		// GetUltimateMobileQuickbar
		new DocumentationInfo()
		{
			functionName = "GetUltimateMobileQuickbar()",
			returnType = "UltimateMobileQuickbar",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
			},
			description = "This function will return the Ultimate Mobile Quickbar component that has been registered with the <i>quickbarName</i> parameter.",
			codeExample = "UltimateMobileQuickbar itemQuickbar = UltimateMobileQuickbar.GetUltimateMobileQuickbar( \"Player\" );"
		},
		// UpdateQuickbarPositioning
		new DocumentationInfo()
		{
			functionName = "UpdateQuickbarPositioning()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
			},
			description = "Updates the positioning of the quickbar on the screen with the current options.",
			codeExample = "UltimateMobileQuickbar.UpdateQuickbarPositioning( \"Player\" );"
		},
		// EnableQuickbar
		new DocumentationInfo()
		{
			functionName = "EnableQuickbar()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
			},
			description = "Enables the quickbar in the scene.",
			codeExample = "UltimateMobileQuickbar.EnableQuickbar( \"Player\" );"
		},
		// DisableQuickbar
		new DocumentationInfo()
		{
			functionName = "DisableQuickbar()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
			},
			description = "Disables the quickbar in the scene.",
			codeExample = "UltimateMobileQuickbar.DisableQuickbar( \"Player\" );"
		},
		// ChangeToQuickbarSet
		new DocumentationInfo()
		{
			functionName = "ChangeToQuickbarSet()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
				"int quickbarIndex - The index of the targeted quickbar.",
				"bool instantTransition = false - Optional parameter to determine whether the change should be instant or transition over time.",
			},
			description = "Changes to the targeted quickbar set on the targeted Ultimate Mobile Quickbar.",
			codeExample = "UltimateMobileQuickbar.ChangeToQuickbarSet( \"Player\", 1, true );"
		},
		// CycleQuickbarSets
		new DocumentationInfo()
		{
			functionName = "CycleQuickbarSets()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
				"bool instantTransition = false - Optional parameter to determine whether the change should be instant or transition over time.",
			},
			description = "Cycles from the current quickbar set to the next on the targeted Ultimate Mobile Quickbar.",
			codeExample = "UltimateMobileQuickbar.CycleQuickbarSets( \"Player\", true );"
		},
		// AddNewQuickbarSet
		new DocumentationInfo()
		{
			functionName = "AddNewQuickbarSet()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
			},
			description = "Adds a new quickbar set to the targeted Ultimate Mobile Quickbar.",
			codeExample = "UltimateMobileQuickbar.AddNewQuickbarSet( \"Player\" );"
		},
		// RemoveEmptyQuickbarSets
		new DocumentationInfo()
		{
			functionName = "RemoveEmptyQuickbarSets()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
			},
			description = "Removes any extra quickbar sets from the targeted Ultimate Mobile Quickbar.",
			codeExample = "UltimateMobileQuickbar.RemoveEmptyQuickbarSets( \"Player\" );"
		},
		// ClearQuickbar
		new DocumentationInfo()
		{
			functionName = "ClearQuickbar()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
			},
			description = "Removes information from each button and removes excess quickbar sets from the targeted Ultimate Mobile Quickbar.",
			codeExample = "UltimateMobileQuickbar.ClearQuickbar( \"Player\" );"
		},
		// RegisterToQuickbar
		new DocumentationInfo()
		{
			functionName = "RegisterToQuickbar()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
				"Action(+2 Overloads: <int>, <string>) ButtonCallback - The action callback to be called when the button is interacted with.",
				"UltimateMobileQuickbarButtonInfo newButtonInfo - The button information to apply to the button.",
				"bool focus = false - Determines if the quickbar should focus on the newly added button information.",
			},
			description = "Registers information to the quickbar at the next available button. The function provided as the ButtonCallback will be called when the button is interacted with.",
			codeExample = "UltimateMobileQuickbar.RegisterToQuickbar( \"Player\", MyCustomCallback, myButtonInfo, true );"
		},
		// RegisterToQuickbar
		new DocumentationInfo()
		{
			functionName = "RegisterToQuickbar()",
			parameter = new string[]
			{
				"string quickbarName - The registered name of the targeted Ultimate Mobile Quickbar.",
				"Action(+2 Overloads: <int>, <string>) ButtonCallback - The action callback to be called when the button is interacted with.",
				"UltimateMobileQuickbarButtonInfo newButtonInfo - The button information to apply to the button.",
				"int parentIndex - The index of the parent quickbar that contains the button that you want to add this information to.",
				"int buttonIndex - The index of the button in the quickbar that you want to add this information to.",
				"bool focus = false - Determines if the quickbar should focus on the newly added button information.",
			},
			description = "Registers information to the quickbar at the next provided indexes. The function provided as the ButtonCallback will be called when the button is interacted with.",
			codeExample = "UltimateMobileQuickbar.RegisterToQuickbar( \"Player\", MyCustomCallback, myButtonInfo, 0, 0, true );"
		},
	};
	DocumentationInfo[] UltimateMobileQuickbar_PublicFunctions = new DocumentationInfo[]
	{
		// UpdateQuickbarPositioning
		new DocumentationInfo()
		{
			functionName = "UpdateQuickbarPositioning()",
			description = "Updates the positioning of the quickbar on the screen with the current options.",
			codeExample = "mobileQuickbar.UpdateQuickbarPositioning();"
		},
		// EnableQuickbar
		new DocumentationInfo()
		{
			functionName = "EnableQuickbar()",
			description = "Enables the quickbar in the scene.",
			codeExample = "mobileQuickbar.EnableQuickbar();"
		},
		// DisableQuickbar
		new DocumentationInfo()
		{
			functionName = "DisableQuickbar()",
			description = "Disables the quickbar in the scene.",
			codeExample = "mobileQuickbar.DisableQuickbar();"
		},
		// ChangeToQuickbarSet
		new DocumentationInfo()
		{
			functionName = "ChangeToQuickbarSet()",
			parameter = new string[]
			{
				"int quickbarIndex - The index of the targeted quickbar.",
				"bool instantTransition = false - Optional parameter to determine whether the change should be instant or transition over time.",
			},
			description = "Changes to the targeted quickbar set.",
			codeExample = "mobileQuickbar.ChangeToQuickbarSet( 1, true );"
		},
		// CycleQuickbarSets
		new DocumentationInfo()
		{
			functionName = "CycleQuickbarSets()",
			parameter = new string[]
			{
				"bool instantTransition = false - Optional parameter to determine whether the change should be instant or transition over time.",
			},
			description = "Cycles from the current quickbar set to the next.",
			codeExample = "mobileQuickbar.CycleQuickbarSets( true );"
		},
		// AddNewQuickbarSet
		new DocumentationInfo()
		{
			functionName = "AddNewQuickbarSet()",
			description = "Adds a new quickbar set to this quickbar.",
			codeExample = "mobileQuickbar.AddNewQuickbarSet();"
		},
		// RemoveEmptyQuickbarSets
		new DocumentationInfo()
		{
			functionName = "RemoveEmptyQuickbarSets()",
			description = "Removes any extra quickbar sets from the quickbar.",
			codeExample = "mobileQuickbar.RemoveEmptyQuickbarSets();"
		},
		// ClearQuickbar
		new DocumentationInfo()
		{
			functionName = "ClearQuickbar()",
			description = "Removes information from each button and removes excess quickbar sets.",
			codeExample = "mobileQuickbar.ClearQuickbar();"
		},
		// RegisterToQuickbar
		new DocumentationInfo()
		{
			functionName = "RegisterToQuickbar()",
			parameter = new string[]
			{
				"Action(+2 Overloads: <int>, <string>) ButtonCallback - The action callback to be called when the button is interacted with.",
				"UltimateMobileQuickbarButtonInfo newButtonInfo - The button information to apply to the button.",
				"bool focus = false - Determines if the quickbar should focus on the newly added button information.",
			},
			description = "Registers information to the quickbar at the next available button. The function provided as the ButtonCallback will be called when the button is interacted with.",
			codeExample = "mobileQuickbar.RegisterToQuickbar( MyCustomCallback, myButtonInfo, true );"
		},
		// RegisterToQuickbar
		new DocumentationInfo()
		{
			functionName = "RegisterToQuickbar()",
			parameter = new string[]
			{
				"Action(+2 Overloads: <int>, <string>) ButtonCallback - The action callback to be called when the button is interacted with.",
				"UltimateMobileQuickbarButtonInfo newButtonInfo - The button information to apply to the button.",
				"int parentIndex - The index of the parent quickbar that contains the button that you want to add this information to.",
				"int buttonIndex - The index of the button in the quickbar that you want to add this information to.",
				"bool focus = false - Determines if the quickbar should focus on the newly added button information.",
			},
			description = "Registers information to the quickbar at the next provided indexes. The function provided as the ButtonCallback will be called when the button is interacted with.",
			codeExample = "mobileQuickbar.RegisterToQuickbar( MyCustomCallback, myButtonInfo, 0, 0, true );"
		},
	};
	DocumentationInfo[] UltimateMobileQuickbarButtonInfo_PublicFunctions = new DocumentationInfo[]
	{
		// UpdateIcon
		new DocumentationInfo()
		{
			functionName = "UpdateIcon()",
			parameter = new string[]
			{
				"Sprite newIcon - The new icon sprite to apply to the button.",
			},
			description = "Updates the icon of the quickbar button.",
			codeExample = "buttonInfo.UpdateIcon( myNewIcon );"
		},
		// UpdateCooldown
		new DocumentationInfo()
		{
			functionName = "UpdateCooldown()",
			parameter = new string[]
			{
				"float current - The current value of the cooldown.",
				"float max - The max value of the cooldown.",
			},
			description = "Updates the cooldown of the button.",
			codeExample = "buttonInfo.UpdateCooldown( currentCooldownTime, maxCooldownTime );"
		},
		// UpdateCount
		new DocumentationInfo()
		{
			functionName = "UpdateCount()",
			parameter = new string[]
			{
				"int currentCount - The current count to display on the button.",
			},
			description = "Updates the registered quickbar button with the current count to display.",
			codeExample = "buttonInfo.UpdateCount( myCount );"
		},
		// ExistsOnQuickbar
		new DocumentationInfo()
		{
			functionName = "ExistsOnQuickbar()",
			returnType = "bool",
			description = "Returns the existence of this information on a Ultimate Mobile Quickbar.",
			codeExample = "if( buttonInfo.ExistsOnQuickbar() )\n{\n" + Indent + "// The buttonInfo is assigned to a quickbar, do something here...\n}"
		},
		// RemoveFromQuickbar
		new DocumentationInfo()
		{
			functionName = "RemoveFromQuickbar()",
			description = "Removes this information from the button on the quickbar.",
			codeExample = "buttonInfo.RemoveFromQuickbar();"
		},
	};

	// END PAGE COMMENTS //
	class EndPageComment
	{
		public string comment = "";
		public string url = "";
	}
	EndPageComment[] EndPageComments = new EndPageComment[]
	{
		// Leave Review //
		new EndPageComment()
		{
			comment = "Enjoying the Ultimate Mobile Quickbar? Leave us a review on the <b><color=blue>Unity Asset Store</color></b>!",
			url = "https://assetstore.unity.com/packages/slug/170899"
		},
		// Ultimate Joystick //
		new EndPageComment()
		{
			comment = "Looking for a mobile joystick for your game? Check out the <b><color=blue>Ultimate Joystick</color></b>!",
			url = "https://www.tankandhealerstudio.com/ultimate-joystick.html"
		},
		// Ultimate Button //
		new EndPageComment()
		{
			comment = "Are you in need of an action button for your mobile game? Check out the <b><color=blue>Ultimate Button</color></b>!",
			url = "https://www.tankandhealerstudio.com/ultimate-button.html"
		},
		// Ultimate Touchpad //
		new EndPageComment()
		{
			comment = "Need a touchpad for smooth camera movement in your game? Check out the <b><color=blue>Ultimate Touchpad</color></b>!",
			url = "https://www.tankandhealerstudio.com/ultimate-touchpad.html"
		},
		// Ultimate Status Bar //
		new EndPageComment()
		{
			comment = "In need for a health bar for your project? Check out the <b><color=blue>Ultimate Status Bar</color></b>!",
			url = "https://www.tankandhealerstudio.com/ultimate-status-bar.html"
		},
		// Ultimate Radial Menu //
		new EndPageComment()
		{
			comment = "Do you need a radial menu for your game? Check out the <b><color=blue>Ultimate Radial Menu</color></b>!",
			url = "https://www.tankandhealerstudio.com/ultimate-radial-menu.html"
		},
		// Other Products //
		new EndPageComment()
		{
			comment = "Check out our <b><color=blue>other products</color></b>!",
			url = "https://www.tankandhealerstudio.com/assets.html"
		},
	};
	int randomComment = 0;
	

	static UltimateMobileQuickbarReadmeEditor ()
	{
		EditorApplication.update += WaitForCompile;
	}

	static void WaitForCompile ()
	{
		if( EditorApplication.isCompiling )
			return;

		EditorApplication.update -= WaitForCompile;
		
		// If this is the first time that the user has downloaded this asset...
		if( !EditorPrefs.HasKey( "UltimateMobileQuickbarVersion" ) )
		{
			EditorPrefs.SetInt( "UltimateMobileQuickbarVersion", UltimateMobileQuickbarReadme.ImportantChange );

			SelectReadmeFile();

			if( readme != null )
				NavigateForward( thankYou );
		}
		// Else if the version has been updated and there are important changes to display to the user...
		else if( EditorPrefs.GetInt( "UltimateMobileQuickbarVersion" ) < UltimateMobileQuickbarReadme.ImportantChange )
		{
			EditorPrefs.SetInt( "UltimateMobileQuickbarVersion", UltimateMobileQuickbarReadme.ImportantChange );

			SelectReadmeFile();

			if( readme != null )
				NavigateForward( importantChange );
		}
	}

	void OnEnable ()
	{
		if( !pageHistory.Contains( mainMenu ) )
			pageHistory.Insert( 0, mainMenu );

		mainMenu.targetMethod = MainPage;
		gettingStarted.targetMethod = GettingStarted;
		overview.targetMethod = Overview;
		documentation.targetMethod = Documentation;
		documentation_UMQBI.targetMethod = Documentation_UltimateMobileQuickbarButtonInfo;
		documentation_UMQ.targetMethod = Documentation_UltimateMobileQuickbar;
		versionHistory.targetMethod = VersionHistory;
		importantChange.targetMethod = ImportantChange;
		thankYou.targetMethod = ThankYou;
		settings.targetMethod = Settings;

		if( pageHistory.Count == 1 )
			currentPage = mainMenu;

		randomComment = Random.Range( 0, EndPageComments.Length );

		readme = ( UltimateMobileQuickbarReadme )target;

		if( !EditorPrefs.HasKey( "UMQ_ColorHexSetup" ) )
		{
			EditorPrefs.SetBool( "UMQ_ColorHexSetup", true );
			ResetColors();
		}

		ColorUtility.TryParseHtmlString( EditorPrefs.GetString( "UMQ_ColorDefaultHex" ), out readme.colorDefault );
		ColorUtility.TryParseHtmlString( EditorPrefs.GetString( "UMQ_ColorValueChangedHex" ), out readme.colorValueChanged );
		
		Undo.undoRedoPerformed += UndoRedoCallback;
	}

	void OnDisable ()
	{
		Undo.undoRedoPerformed -= UndoRedoCallback;
	}

	void UndoRedoCallback ()
	{
		if( currentPage != settings )
			return;

		EditorPrefs.SetString( "UMQ_ColorDefaultHex", "#" + ColorUtility.ToHtmlStringRGBA( readme.colorDefault ) );
		EditorPrefs.SetString( "UMQ_ColorValueChangedHex", "#" + ColorUtility.ToHtmlStringRGBA( readme.colorValueChanged ) );
	}

	protected override void OnHeaderGUI ()
	{
		UltimateMobileQuickbarReadme readme = ( UltimateMobileQuickbarReadme )target;

		float iconWidth = Mathf.Min( EditorGUIUtility.currentViewWidth, 350f );

		Vector2 ratio = new Vector2( readme.icon.width, readme.icon.height ) / ( readme.icon.width > readme.icon.height ? readme.icon.width : readme.icon.height );

		GUILayout.BeginHorizontal( "In BigTitle" );
		{
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical();
			GUILayout.Label( readme.icon, GUILayout.Width( iconWidth * ratio.x ), GUILayout.Height( iconWidth * ratio.y ) );
			GUILayout.Space( -20 );
			if( GUILayout.Button( readme.versionHistory[ 0 ].versionNumber, versionStyle ) && !pageHistory.Contains( versionHistory ) )
				NavigateForward( versionHistory );
			var rect = GUILayoutUtility.GetLastRect();
			if( currentPage != versionHistory )
				EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );
			GUILayout.EndVertical();
			GUILayout.FlexibleSpace();
		}
		GUILayout.EndHorizontal();
	}

	public override void OnInspectorGUI ()
	{
		serializedObject.Update();

		paragraphStyle = new GUIStyle( EditorStyles.label ) { wordWrap = true, richText = true, fontSize = 12 };
		itemHeaderStyle = new GUIStyle( paragraphStyle ) { fontSize = 12, fontStyle = FontStyle.Bold };
		sectionHeaderStyle = new GUIStyle( paragraphStyle ) { fontSize = 14, fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleCenter };
		titleStyle = new GUIStyle( paragraphStyle ) { fontSize = 16, fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleCenter };
		versionStyle = new GUIStyle( paragraphStyle ) { alignment = TextAnchor.MiddleCenter, fontSize = 10 };

		paragraphStyle.active.textColor = paragraphStyle.normal.textColor;
		
		// SETTINGS BUTTON //
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if( GUILayout.Button( readme.settings, versionStyle, GUILayout.Width( 24 ), GUILayout.Height( 24 ) ) && !pageHistory.Contains( settings ) )
			NavigateForward( settings );
		var rect = GUILayoutUtility.GetLastRect();
		if( currentPage != settings )
			EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );
		GUILayout.EndHorizontal();
		GUILayout.Space( -24 );
		GUILayout.EndVertical();

		// BACK BUTTON //
		EditorGUILayout.BeginHorizontal();
		EditorGUI.BeginDisabledGroup( pageHistory.Count <= 1 );
		if( GUILayout.Button( "◄", titleStyle, GUILayout.Width( 24 ) ) )
			NavigateBack();
		if( pageHistory.Count > 1 )
		{
			rect = GUILayoutUtility.GetLastRect();
			EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );
		}
		EditorGUI.EndDisabledGroup();
		GUILayout.Space( -24 );

		// PAGE TITLE //
		GUILayout.FlexibleSpace();
		EditorGUILayout.LabelField( currentPage.pageName, titleStyle );
		GUILayout.FlexibleSpace();
		EditorGUILayout.EndHorizontal();

		// DISPLAY PAGE //
		if( currentPage.targetMethod != null )
			currentPage.targetMethod();

		Repaint();
	}

	void StartPage ( PageInformation pageInfo )
	{
		pageInfo.scrollPosition = EditorGUILayout.BeginScrollView( pageInfo.scrollPosition, false, false );
		GUILayout.Space( 15 );
	}

	void EndPage ()
	{
		EditorGUILayout.EndScrollView();
	}

	static void NavigateBack ()
	{
		pageHistory.RemoveAt( pageHistory.Count - 1 );
		currentPage = pageHistory[ pageHistory.Count - 1 ];
		GUI.FocusControl( "" );
	}

	static void NavigateForward ( PageInformation menu )
	{
		pageHistory.Add( menu );
		currentPage = menu;
		GUI.FocusControl( "" );
	}

	void MainPage ()
	{
		EditorGUILayout.LabelField( "We hope that you are enjoying using the Ultimate Mobile Quickbar in your project! Here is a list of helpful resources for this asset:", paragraphStyle );

		EditorGUILayout.Space();

		// GETTING STARTED //
		if( GUILayout.Button( "  • Read the <b><color=blue>Getting Started</color></b> section of this README!", paragraphStyle ) )
			NavigateForward( gettingStarted );
		var rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		EditorGUILayout.Space();

		// OVERVIEW //
		if( GUILayout.Button( "  • To learn more about the options on the inspector, read the <b><color=blue>Overview</color></b> section.", paragraphStyle ) )
			NavigateForward( overview );
		rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );
		
		EditorGUILayout.Space();

		// DOCUMENTATION //
		if( GUILayout.Button( "  • Check out the <b><color=blue>Documentation</color></b> section to learn more about each script and function.", paragraphStyle ) )
			NavigateForward( documentation );
		rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		EditorGUILayout.Space();

		// VIDEO TUTORIALS //
		if( GUILayout.Button( "  • Watch our <b><color=blue>Video Tutorials</color></b> on the Ultimate Mobile Quickbar.", paragraphStyle ) )
		{
			Debug.Log( "Ultimate Mobile Quickbar\nOpening YouTube Tutorials" );
			Application.OpenURL( "https://www.youtube.com/playlist?list=PL7crd9xMJ9TkyUkCWwyr6KELO3mv34vpk" );
		}
		rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		EditorGUILayout.Space();

		// CONTACT US //
		if( GUILayout.Button( "  • <b><color=blue>Contact Us</color></b> directly with your issue! We'll try to help you out as much as we can.", paragraphStyle ) )
		{
			Debug.Log( "Ultimate Mobile Quickbar\nOpening Online Contact Form" );
			Application.OpenURL( "https://www.tankandhealerstudio.com/contact-us.html" );
		}
		rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		EditorGUILayout.Space();

		// CONCLUSION //
		EditorGUILayout.LabelField( "Now you have the tools you need to get the Ultimate Mobile Quickbar working in your project. Now get out there and make your awesome game!", paragraphStyle );

		EditorGUILayout.Space();

		EditorGUILayout.LabelField( "Happy Game Making,\n" + Indent + "Tank & Healer Studio", paragraphStyle );

		GUILayout.Space( sectionSpace );

		GUILayout.FlexibleSpace();

		// ENDPAGE COMMENTS //
		EditorGUILayout.LabelField( EndPageComments[ randomComment ].comment, paragraphStyle );
		rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );
		if( Event.current.type == EventType.MouseDown && rect.Contains( Event.current.mousePosition ) )
			Application.OpenURL( EndPageComments[ randomComment ].url );
	}

	void GettingStarted ()
	{
		StartPage( gettingStarted );

		// VIDEO INTRODUCTION //
		EditorGUILayout.LabelField( "Video Introduction", sectionHeaderStyle );

		if( GUILayout.Button( Indent + "To begin, please watch the <b><color=blue>Introduction Video</color></b> from our website for the Ultimate Mobile Quickbar. This video will explain how to get started using the Ultimate Mobile Quickbar and help you understand how to implement it into your project.", paragraphStyle ) )
		{
			Debug.Log( "Ultimate Mobile Quickbar\nOpening Online Video Tutorials" );
			Application.OpenURL( "https://www.tankandhealerstudio.com/ultimate-mobile-quickbar_documentation_video-tutorials.html" );
		}
		var rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		GUILayout.Space( sectionSpace );

		// WRITTEN INTRODUCTION //
		EditorGUILayout.LabelField( "Written Introduction", sectionHeaderStyle );
		EditorGUILayout.LabelField( Indent + "The Ultimate Mobile Quickbar has been built from the ground up with being easy to use and customize to make it work the way that you want. However, that being said, the Ultimate Mobile Quickbar asset can be a bit tricky to understand how to use at first.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "To begin we'll look at how to simply create an Ultimate Mobile Quickbar in your scene. After that we will go over how to reference the Ultimate Mobile Quickbar in your custom scripts. Let's begin!", paragraphStyle );

		GUILayout.Space( sectionSpace );

		// HOW TO CREATE //
		EditorGUILayout.LabelField( "How To Create", sectionHeaderStyle );
		EditorGUILayout.LabelField( Indent + "To create an Ultimate Mobile Quickbar in your scene, simply find the Ultimate Mobile Quickbar prefab that you would like to add and drag the prefab into the scene. The Ultimate Mobile Quickbar prefab will automatically find or create a canvas in your scene for you.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Prefabs can be found at: Assets/Ultimate Mobile Quickbar/Prefabs.", paragraphStyle );

		GUILayout.Space( sectionSpace );

		// HOW TO REFERENCE //
		EditorGUILayout.LabelField( "How To Reference", sectionHeaderStyle );
		EditorGUILayout.LabelField( Indent + "To understand how to use the Ultimate Mobile Quickbar into your scripts, first let us talk about how it actually works to see how we can best implement the quickbar. We will be going over the <b>Callback System</b> that the quickbar uses as well as a certain class that you will be using to send information to the quickbar. Below are the topics mentioned.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Callback System", itemHeaderStyle );
		EditorGUILayout.LabelField( "The Callback System simply sends information to your scripts about which button has been interacted with. When you get to implementing the code, you will see a parameter named: ButtonCallback. This is where you will pass your function that you want the button to call when being interacted with.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "For example, let's say you want to use the quickbar to use items. Likely in your item script you have a function named: UseItem(), or something similar. When subscribing to the quickbar, you will want to pass your UseItem function as the ButtonCallback parameter. Then, when the user clicks on the quickbar button the Ultimate Mobile Quickbar will call your UseItem function.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "UltimateMobileQuickbarButtonInfo Class", itemHeaderStyle );
		EditorGUILayout.LabelField( "The UltimateMobileQuickbarButtonInfo class is public and will be used inside of your own custom scripts. It is used just like any other variable inside of your own scripts, but has a custom property drawer so that the information is a little easier to work with.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "This class is what you will send to the Ultimate Mobile Quickbar to update the important information it needs. After sending in your UltimateMobileQuickbarButtonInfo to the quickbar, it will then have access to a few functions that you can use to keep information updated, without referencing back to the Ultimate Mobile Quickbar.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "For instance, let's continue on the example above with using the quickbar for your items. In your item class, you will want to have a public UltimateMobileQuickbarButtonInfo variable. Here is an example of a item class that could be similar to yours:", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Example Code:", itemHeaderStyle );
		EditorGUILayout.TextArea( "[System.Serializable]\npublic class Item\n{\n" + Indent + "public string name;\n" + Indent + "public Sprite icon;\n" + Indent + "public int count = 10;\n" + Indent + "public UltimateMobileQuickbarButtonInfo buttonInfo;\n\n" + Indent + "public void UseItem ()\n" + Indent + "{\n" + Indent + Indent + "Debug.Log( \"Used item: \" + name );\n" + Indent + "}\n}\npublic Item[] items;", GUI.skin.GetStyle( "TextArea" ) );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Below is some example code in a Start() function to help demonstrate how to register this information to the quickbar:", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Example Code:", itemHeaderStyle );
		EditorGUILayout.TextArea( "void Start ()\n{\n" + Indent + "for( int i = 0; i < items.Length; i++ )\n" + Indent + "{\n" + Indent + Indent + "// Assign the buttonInfo icon to being this items icon.\n" + Indent + Indent + "items[ i ].buttonInfo.icon = items[ i ].icon;\n\n" + Indent + Indent + "// Register this information to the quickbar that has been assigned the name: Items in the Script Reference section.\n" + Indent + Indent + "UltimateMobileQuickbar.RegisterToQuickbar( \"Items\", items[ i ].UseItem, items[ i ].buttonInfo );\n" + Indent + "}\n}", GUI.skin.GetStyle( "TextArea" ) );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "After this code, the quickbar will add this information to the first available button, and will call the UseItem() function when being interacted with.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "We are not done though! The UltimateMobileQuickbarButtonInfo class has so much more functionality than first meets the eye. After passing in the buttonInfo to the quickbar, it has actually been authorized control over the button that it has been assigned to, giving you access to more useful functions to keep the button updated.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Let's discuss one more example of how to update the quickbar using this class. In the same scenario, inside your Start() function right after you register the information to the quickbar, you can now update the count text of the button by simply using the buttonInfo class. Let's see how:", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Example Code:", itemHeaderStyle );
		EditorGUILayout.TextArea( "void Start ()\n{\n" + Indent + "for( int i = 0; i < items.Length; i++ )\n" + Indent + "{\n" + Indent + Indent + "// Assign the buttonInfo icon to being this items icon.\n" + Indent + Indent + "items[ i ].buttonInfo.icon = items[ i ].icon;\n\n" + Indent + Indent + "// Register this information to the quickbar that has been assigned the name: Items in the Script Reference section.\n" + Indent + Indent + "UltimateMobileQuickbar.RegisterToQuickbar( \"Items\", items[ i ].UseItem, items[ i ].buttonInfo );\n\n" + Indent + Indent + "// After the buttonInfo has been registered, call the UpdateCount to update the count text of the quickbar button.\n" + Indent + Indent + "items[ i ].buttonInfo.UpdateCount( items[ i ].count );\n" + Indent + "}\n}", GUI.skin.GetStyle( "TextArea" ) );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Now the quickbar will correctly display how many of this item there is to be used. Now let's change the UseItem() function to display how many of an item we have left. Also, we can remove the button from the quickbar once the item count has depleted.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Example Code:", itemHeaderStyle );
		EditorGUILayout.TextArea( "[System.Serializable]\npublic class Item\n{\n" + Indent + "public string name;\n" + Indent + "public Sprite icon;\n" + Indent + "public int count = 10;\n" + Indent + "public UltimateMobileQuickbarButtonInfo buttonInfo;\n\n" + Indent + "public void UseItem ()\n" + Indent + "{\n" + Indent + Indent + "// Reduce the count by 1.\n" + Indent + Indent + "count--;\n\n" + Indent + Indent + "// Update the count text of the quickbar button.\n" + Indent + Indent + "buttonInfo.UpdateCount( count );\n" + Indent + Indent + "\n" + Indent + Indent + "Debug.Log( \"Used item: \" + name );\n" + Indent + Indent + "\n" + Indent + Indent + "// If the count is depleted, then remove this item from the quickbar.\n" + Indent + Indent + "if( count <= 0 )\n" + Indent + Indent + Indent + "buttonInfo.RemoveFromQuickbar();\n" + Indent + "}\n}\npublic Item[] items;", GUI.skin.GetStyle( "TextArea" ) );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "As you can see, the buttonInfo can now be used to update information about the button that it has been assigned.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		if( GUILayout.Button( "For a full list of the functions available, please see the <b><color=blue>Documentation</color></b> section.", paragraphStyle ) )
			NavigateForward( documentation );
		rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		EndPage();
	}

	void Overview ()
	{
		StartPage( overview );
		
		EditorGUILayout.LabelField( "Summary", sectionHeaderStyle );
		EditorGUILayout.LabelField( Indent + "The <i>Ultimate Mobile Quickbar</i> is used to display skills or items to your players and provide them with information about the current cooldown time and item count. It also handles multiple quickbar sets and transitioning between them.", paragraphStyle );

		GUILayout.Space( sectionSpace );

		EditorGUILayout.LabelField( "Inspector", sectionHeaderStyle );
		EditorGUILayout.LabelField( Indent + "The display below is mimicking the Ultimate Mobile Quickbar inspector. Expand each section to learn what each one is designed for.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		// QUICKBAR POSITIONING //
		GUIStyle toolbarStyle = new GUIStyle( EditorStyles.toolbarButton ) { alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, fontSize = 11 };
		
		GUILayout.BeginHorizontal();
		showQuickbarPositioning = GUILayout.Toggle( showQuickbarPositioning, ( showQuickbarPositioning ? "▼" : "►" ) + "Quickbar Positioning", toolbarStyle );
		GUILayout.EndHorizontal();
		if( showQuickbarPositioning )
		{
			GUILayout.Space( paragraphSpace );
			EditorGUILayout.LabelField( "This section handles the positioning of the Ultimate Mobile Quickbar relative to another transform on the screen. It handles how many buttons there are per quickbar set, and has options for displaying the current quickbar set to the player visually.", paragraphStyle );
		}

		EditorGUILayout.Space();

		// QUICKBAR SETTINGS //
		GUILayout.BeginHorizontal();
		showQuickbarSettings = GUILayout.Toggle( showQuickbarSettings, ( showQuickbarSettings ? "▼" : "►" ) + "Quickbar Settings", toolbarStyle );
		GUILayout.EndHorizontal();
		if( showQuickbarSettings )
		{
			GUILayout.Space( paragraphSpace );
			EditorGUILayout.LabelField( "This section has options for how the quickbar buttons appear visually to the player. There are many optional settings for things like: cooldown text, icon mask, count text background sprite, and more! It also handles the child hierarchy of the buttons which allows you to determine which images appear above or below other images.", paragraphStyle );
		}
		
		EditorGUILayout.Space();

		// SCRIPT REFERENCE //
		GUILayout.BeginHorizontal();
		showScriptReference = GUILayout.Toggle( showScriptReference, ( showScriptReference ? "▼" : "►" ) + "Script Reference", toolbarStyle );
		GUILayout.EndHorizontal();
		if( showScriptReference )
		{
			GUILayout.Space( paragraphSpace );
			EditorGUILayout.LabelField( "In this section you will be able to setup the reference to this Ultimate Mobile Quickbar, and you will be provided with code examples to be able to copy and paste into your own scripts.", paragraphStyle );
		}

		GUILayout.Space( sectionSpace );

		EditorGUILayout.LabelField( "Tooltips", sectionHeaderStyle );
		EditorGUILayout.LabelField( Indent + "To learn more about each option on this component, please select the Ultimate Mobile Quickbar in your scene and hover over each property to read the provided tooltip.", paragraphStyle );

		EndPage();
	}
	
	void Documentation ()
	{
		StartPage( documentation );

		EditorGUILayout.LabelField( "Introduction", sectionHeaderStyle );
		EditorGUILayout.LabelField( Indent + "Welcome to the Documentation section. This section will go over the various functions that you have available. Please click on the class to learn more about each function.", paragraphStyle );
		
		GUILayout.Space( sectionSpace );

		// UltimateMobileQuickbar.cs
		if( GUILayout.Button( "UltimateMobileQuickbar.cs", itemHeaderStyle ) )
		{
			NavigateForward( documentation_UMQ );
			GUI.FocusControl( "" );
		}
		var rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		// UltimateMobileQuickbarButtonInfo.cs
		if( GUILayout.Button( "UltimateMobileQuickbarButtonInfo.cs", itemHeaderStyle ) )
		{
			NavigateForward( documentation_UMQBI );
			GUI.FocusControl( "" );
		}
		rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		EndPage();
	}
	
	void Documentation_UltimateMobileQuickbar ()
	{
		StartPage( documentation_UMQ );

		// STATIC FUNCTIONS //
		EditorGUILayout.LabelField( "Static Functions", sectionHeaderStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( Indent + "The following functions can be referenced from your scripts without the need for an assigned local Ultimate Mobile Quickbar variable. However, each function must have the targeted Ultimate Mobile Quickbar name in order to find the correct Ultimate Mobile Quickbar in the scene. Each example code provided uses the name <i>Player</i> as the Mobile Quickbar name.", paragraphStyle );

		Vector2 ratio = new Vector2( readme.scriptReference.width, readme.scriptReference.height ) / ( readme.scriptReference.width > readme.scriptReference.height ? readme.scriptReference.width : readme.scriptReference.height );

		float imageWidth = readme.scriptReference.width > Screen.width - 50 ? Screen.width - 50 : readme.scriptReference.width;

		EditorGUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label( readme.scriptReference, GUILayout.Width( imageWidth * ratio.x ), GUILayout.Height( imageWidth ) );
		GUILayout.FlexibleSpace();
		EditorGUILayout.EndHorizontal();

		GUILayout.Space( paragraphSpace );

		for( int i = 0; i < UltimateMobileQuickbar_StaticFunctions.Length; i++ )
			ShowDocumentation( UltimateMobileQuickbar_StaticFunctions[ i ] );

		GUILayout.Space( sectionSpace );

		// PUBLIC FUNCTIONS //
		EditorGUILayout.LabelField( "Public Functions", sectionHeaderStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( Indent + "All of the following public functions are only available from a reference to the Ultimate Mobile Quickbar class. Each example provided relies on having a Ultimate Mobile Quickbar variable named 'quickbar' stored inside your script. When using any of the example code provided, make sure that you have a Ultimate Mobile Quickbar variable like the one below:", paragraphStyle );

		EditorGUILayout.TextArea( "// Place this in your public variables and assign it in the inspector. //\npublic UltimateMobileQuickbar mobileQuickbar;", GUI.skin.textArea );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "Please click on the function name to learn more.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		for( int i = 0; i < UltimateMobileQuickbar_PublicFunctions.Length; i++ )
			ShowDocumentation( UltimateMobileQuickbar_PublicFunctions[ i ] );

		EndPage();
	}

	void Documentation_UltimateMobileQuickbarButtonInfo ()
	{
		StartPage( documentation_UMQBI );

		/* //// --------------------------- < PUBLIC FUNCTIONS > --------------------------- \\\\ */
		EditorGUILayout.LabelField( "Public Functions", sectionHeaderStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( Indent + "All of the following public functions are only available from a reference to an UltimateMobileQuickbarButtonInfo class:", paragraphStyle );

		EditorGUILayout.TextArea( "// Place these with your variables.\npublic UltimateMobileQuickbarButtonInfo buttonInfo;", GUI.skin.textArea );

		EditorGUILayout.LabelField( Indent + "The examples provided rely on having an UltimateMobileQuickbarButtonInfo variable named 'buttonInfo' stored inside your script. Please click on the function name to learn more.", paragraphStyle );
		
		GUILayout.Space( paragraphSpace );

		for( int i = 0; i < UltimateMobileQuickbarButtonInfo_PublicFunctions.Length; i++ )
			ShowDocumentation( UltimateMobileQuickbarButtonInfo_PublicFunctions[ i ] );

		GUILayout.Space( itemHeaderSpace );

		EndPage();
	}
	
	void VersionHistory ()
	{
		StartPage( versionHistory );

		for( int i = 0; i < readme.versionHistory.Length; i++ )
		{
			EditorGUILayout.LabelField( "Version " + readme.versionHistory[ i ].versionNumber, itemHeaderStyle );

			for( int n = 0; n < readme.versionHistory[ i ].changes.Length; n++ )
				EditorGUILayout.LabelField( "  • " + readme.versionHistory[ i ].changes[ n ] + ".", paragraphStyle );

			if( i < ( readme.versionHistory.Length - 1 ) )
				GUILayout.Space( itemHeaderSpace );
		}

		EndPage();
	}

	void ImportantChange ()
	{
		StartPage( importantChange );

		EditorGUILayout.LabelField( "There have not been any important updates yet.", paragraphStyle );

		EditorGUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if( GUILayout.Button( "Continue", GUILayout.Width( Screen.width / 2 ) ) )
			NavigateBack();

		var rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		GUILayout.FlexibleSpace();
		EditorGUILayout.EndHorizontal();

		EndPage();
	}

	void ThankYou ()
	{
		StartPage( thankYou );

		EditorGUILayout.LabelField( "The two of us at Tank & Healer Studio would like to thank you for purchasing the Ultimate Mobile Quickbar asset package from the Unity Asset Store.", paragraphStyle );

		GUILayout.Space( paragraphSpace );

		EditorGUILayout.LabelField( "We hope that the Ultimate Mobile Quickbar will be a great help to you in the development of your game. After clicking the <i>Continue</i> button below, you will be presented with information to assist you in getting to know the Ultimate Mobile Quickbar and getting it implementing into your project.", paragraphStyle );

		EditorGUILayout.Space();

		EditorGUILayout.LabelField( "You can access this information at any time by clicking on the <b>README</b> file inside the Ultimate Mobile Quickbar folder.", paragraphStyle );

		EditorGUILayout.Space();

		EditorGUILayout.LabelField( "Again, thank you for downloading the Ultimate Mobile Quickbar. We hope that your project is a success!", paragraphStyle );

		EditorGUILayout.Space();

		EditorGUILayout.LabelField( "Happy Game Making,\n" + Indent + "Tank & Healer Studio", paragraphStyle );

		GUILayout.Space( 15 );

		EditorGUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if( GUILayout.Button( "Continue", GUILayout.Width( Screen.width / 2 ) ) )
			NavigateBack();

		var rect2 = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect2, MouseCursor.Link );

		GUILayout.FlexibleSpace();
		EditorGUILayout.EndHorizontal();

		EndPage();
	}

	void Settings ()
	{
		StartPage( settings );

		EditorGUILayout.LabelField( "Gizmo Colors", sectionHeaderStyle );
		EditorGUI.BeginChangeCheck();
		EditorGUILayout.PropertyField( serializedObject.FindProperty( "colorDefault" ), new GUIContent( "Default" ) );
		if( EditorGUI.EndChangeCheck() )
		{
			serializedObject.ApplyModifiedProperties();
			EditorPrefs.SetString( "UMQ_ColorDefaultHex", "#" + ColorUtility.ToHtmlStringRGBA( readme.colorDefault ) );
		}

		EditorGUI.BeginChangeCheck();
		EditorGUILayout.PropertyField( serializedObject.FindProperty( "colorValueChanged" ), new GUIContent( "Value Changed" ) );
		if( EditorGUI.EndChangeCheck() )
		{
			serializedObject.ApplyModifiedProperties();
			EditorPrefs.SetString( "UMQ_ColorValueChangedHex", "#" + ColorUtility.ToHtmlStringRGBA( readme.colorValueChanged ) );
		}

		EditorGUILayout.Space();

		EditorGUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if( GUILayout.Button( "Reset", GUILayout.Width( EditorGUIUtility.currentViewWidth / 2 ) ) )
		{
			if( EditorUtility.DisplayDialog( "Reset Gizmo Color", "Are you sure that you want to reset the gizmo colors back to default?", "Yes", "No" ) )
				ResetColors();
		}
		GUILayout.FlexibleSpace();
		EditorGUILayout.EndHorizontal();

		if( EditorPrefs.GetBool( "UUI_DevelopmentMode" ) )
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField( "Development Mode", sectionHeaderStyle );
			base.OnInspectorGUI();
			EditorGUILayout.Space();
		}

		GUILayout.FlexibleSpace();

		GUILayout.Space( sectionSpace );

		EditorGUI.BeginChangeCheck();
		GUILayout.Toggle( EditorPrefs.GetBool( "UUI_DevelopmentMode" ), ( EditorPrefs.GetBool( "UUI_DevelopmentMode" ) ? "Disable" : "Enable" ) + " Development Mode", EditorStyles.radioButton );
		if( EditorGUI.EndChangeCheck() )
		{
			if( EditorPrefs.GetBool( "UUI_DevelopmentMode" ) == false )
			{
				if( EditorUtility.DisplayDialog( "Enable Development Mode", "Are you sure you want to enable development mode for the Ultimate Mobile Quickbar? This mode will allow you to see the default inspector for the Ultimate Mobile Quickbar which is useful when adding variables to this script without having to edit the custom editor script.", "Enable", "Cancel" ) )
				{
					EditorPrefs.SetBool( "UUI_DevelopmentMode", !EditorPrefs.GetBool( "UUI_DevelopmentMode" ) );
				}
			}
			else
				EditorPrefs.SetBool( "UUI_DevelopmentMode", !EditorPrefs.GetBool( "UUI_DevelopmentMode" ) );
		}

		EndPage();
	}

	void ResetColors ()
	{
		Color colorValueChanged = serializedObject.FindProperty( "colorValueChanged" ).colorValue;
		ColorUtility.TryParseHtmlString( "#d200ff", out colorValueChanged );

		serializedObject.FindProperty( "colorDefault" ).colorValue = new Color( 1.0f, 1.0f, 1.0f, 0.5f );
		serializedObject.FindProperty( "colorValueChanged" ).colorValue = colorValueChanged;
		serializedObject.ApplyModifiedProperties();

		EditorPrefs.SetString( "UMQ_ColorDefaultHex", "#" + ColorUtility.ToHtmlStringRGBA( new Color( 1.0f, 1.0f, 1.0f, 0.5f ) ) );
		EditorPrefs.SetString( "UMQ_ColorValueChangedHex", "#" + ColorUtility.ToHtmlStringRGBA( colorValueChanged ) );
	}

	void ShowDocumentation ( DocumentationInfo info )
	{
		GUILayout.Space( paragraphSpace );

		if( GUILayout.Button( info.functionName, itemHeaderStyle ) )
		{
			info.showMore = !info.showMore;
			GUI.FocusControl( "" );
		}
		var rect = GUILayoutUtility.GetLastRect();
		EditorGUIUtility.AddCursorRect( rect, MouseCursor.Link );

		if( info.showMore )
		{
			EditorGUILayout.LabelField( Indent + "<i>Description:</i> " + info.description, paragraphStyle );

			if( info.parameter != null )
			{
				for( int i = 0; i < info.parameter.Length; i++ )
					EditorGUILayout.LabelField( Indent + "<i>Parameter:</i> " + info.parameter[ i ], paragraphStyle );
			}
			if( info.returnType != string.Empty )
				EditorGUILayout.LabelField( Indent + "<i>Return type:</i> " + info.returnType, paragraphStyle );

			if( info.codeExample != string.Empty )
				EditorGUILayout.TextArea( info.codeExample, GUI.skin.textArea );

			GUILayout.Space( paragraphSpace );
		}
	}
	
	public static void OpenReadmeDocumentation ()
	{
		SelectReadmeFile();

		if( !pageHistory.Contains( documentation ) )
			NavigateForward( documentation );

		if( !pageHistory.Contains( documentation_UMQ ) )
			NavigateForward( documentation_UMQ );
	}

	[MenuItem( "Window/Tank and Healer Studio/Ultimate Mobile Quickbar", false, 6 )]
	public static void SelectReadmeFile ()
	{
		var ids = AssetDatabase.FindAssets( "README t:UltimateMobileQuickbarReadme" );
		if( ids.Length == 1 )
		{
			var readmeObject = AssetDatabase.LoadMainAssetAtPath( AssetDatabase.GUIDToAssetPath( ids[ 0 ] ) );
			Selection.objects = new Object[] { readmeObject };
			readme = ( UltimateMobileQuickbarReadme )readmeObject;
		}
		else
			Debug.LogError( "There is no README object in the Ultimate Mobile Quickbar folder." );
	}
}