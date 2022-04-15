using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ItemCodeDescriptionAttribute))]
public class ItemSpriteDrawer : PropertyDrawer
{
    private static readonly GUIStyle s_TempStyle = new GUIStyle();

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Change the returned property height to be double to cater for the additional item code description that we will draw
        return EditorGUI.GetPropertyHeight(property);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that prefab override logic works on the entire property.

        EditorGUI.BeginProperty(position, label, property);

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            int ident = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            //create object field for the sprite
            Rect spriteRect = new Rect(position.x - 50, position.y, position.width, position.height / 3);

            property.objectReferenceValue = EditorGUI.ObjectField(spriteRect, property.name,
                property.objectReferenceValue, typeof(Sprite), false);


            spriteRect.y += EditorGUIUtility.singleLineHeight + 10;
            spriteRect.width = 120;
            spriteRect.height = 120;
            s_TempStyle.Draw(spriteRect, GUIContent.none, false, false, false, false);

            EditorGUI.indentLevel = ident;

            // If item code value has changed, then set value to new value
            if (EditorGUI.EndChangeCheck())
            {
            }

            property.serializedObject.ApplyModifiedProperties();
        }


        EditorGUI.EndProperty();
    }
}