/* UltimateMobileQuickbarInfoPropertyDrawer.cs */
/* Written by Kaz Crowe */
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer( typeof( UltimateMobileQuickbarButtonInfo ) )]
public class UltimateMobileQuickbarButtonInfoPropertyDrawer : PropertyDrawer
{
	public override float GetPropertyHeight ( SerializedProperty property, GUIContent label )
	{
		int lineCount = 1;
		int endSpacingModifier = 0;
		if( EditorPrefs.GetBool( "UMQ_ButtonInfoProperty" ) )
		{
			endSpacingModifier = 4;
			lineCount = 4;
		}
		
		return EditorGUIUtility.singleLineHeight * lineCount + ( ( lineCount * 2 ) + endSpacingModifier );
	}

	public override void OnGUI ( Rect position, SerializedProperty property, GUIContent label )
	{
		EditorGUI.BeginProperty( position, label, property );

		int i = 0;
		
		GUIStyle toolbarStyle = new GUIStyle( EditorStyles.toolbarButton ) { alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, fontSize = 11, stretchWidth = false };
		EditorPrefs.SetBool( "UMQ_ButtonInfoProperty", GUI.Toggle( GetNewPositionRect( EditorGUI.IndentedRect( position ), i++ ), EditorPrefs.GetBool( "UMQ_ButtonInfoProperty" ), ( EditorPrefs.GetBool( "UMQ_ButtonInfoProperty" ) ? "▼" : "►" ) + label.text, toolbarStyle ) );

		position.y += 2;

		if( EditorPrefs.GetBool( "UMQ_ButtonInfoProperty" ) )
		{
			EditorGUI.indentLevel++;
			EditorGUI.PropertyField( GetNewPositionRect( position, i++ ), property.FindPropertyRelative( "key" ), new GUIContent( "Key", "The string key associated with this element." ) );
			EditorGUI.PropertyField( GetNewPositionRect( position, i++ ), property.FindPropertyRelative( "id" ), new GUIContent( "ID", "The integer ID associated with this element." ) );
			EditorGUI.PropertyField( GetNewPositionRect( position, i++ ), property.FindPropertyRelative( "icon" ) );
			EditorGUI.indentLevel--;
		}
		EditorGUI.EndProperty();
	}

	Rect GetNewPositionRect ( Rect position, int i )
	{
		return new Rect( position.x, position.y + ( 18 * i ), position.width, 16 );
	}
}