using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class WaveList : MonoBehaviour
{
    [Serializable]
    public class Wave
    {
        public int waveCount;
        public string[] enemies;
        // Additional field for storing the currently selected enemy index
        public int selectedEnemy;
        public int[] enemyLVL;
        public float[] delay;

#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(Wave))]
        private class WavePropertyDrawer : PropertyDrawer
        {
            // This will be generated during the OnGUI call
            // Maybe not the cleanest way but it works for now ;)
            private float height;
            private string[] availableEnemies;

            // This method is required so other property drawers (like the Wave[] waves)
            // know how much space to reserve for drawing this property
            public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            {
                return height + EditorGUIUtility.singleLineHeight;
            }

            // Draw the property inside the given rect
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                // reset the height
                height = 0;

                // Using BeginProperty / EndProperty on the parent property means that    
                // prefab override logic works on the entire property.
                EditorGUI.BeginProperty(position, label, property);
                {
                    // Get the rect for where to draw the label/foldout
                    var labelRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
                    position.y += EditorGUIUtility.singleLineHeight;
                    height += EditorGUIUtility.singleLineHeight;

                    // Draw the foldout
                    property.isExpanded = EditorGUI.Foldout(labelRect, property.isExpanded, property.displayName);
                    if (property.isExpanded)
                    {
                        // indent children for better readability
                        EditorGUI.indentLevel++;
                        {
                            // Get serialized Properties
                            var serializedWaveCount = property.FindPropertyRelative(nameof(waveCount));
                            var serializedEnemies = property.FindPropertyRelative(nameof(enemies));
                            var serializedSelectedEnemy = property.FindPropertyRelative(nameof(selectedEnemy));
                            var serializedEnemyLVL = property.FindPropertyRelative(nameof(enemyLVL));
                            var serializedDelay = property.FindPropertyRelative(nameof(delay));

                            // Calculate rects
                            var waveCountHeight = EditorGUI.GetPropertyHeight(serializedWaveCount);
                            var waveCountRect = new Rect(position.x, position.y, position.width, waveCountHeight);
                            position.y += waveCountHeight;
                            height += waveCountHeight;

                            var enemiesHeight = EditorGUI.GetPropertyHeight(serializedEnemies, true);
                            var enemiesRect = new Rect(position.x, position.y, position.width, enemiesHeight);
                            position.y += enemiesHeight;
                            height += enemiesHeight;

                            var selectedEnemyRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
                            position.y += EditorGUIUtility.singleLineHeight;
                            height += EditorGUIUtility.singleLineHeight;

                            var enemeiesLevelHeight = EditorGUI.GetPropertyHeight(serializedEnemyLVL, true);
                            var enemeiesLVLRect = new Rect(position.x, position.y, position.width, enemeiesLevelHeight);
                            position.y += enemeiesLevelHeight;
                            height += enemeiesLevelHeight;

                            var delayHeight = EditorGUI.GetPropertyHeight(serializedDelay, true);
                            var delayRect = new Rect(position.x, position.y, position.width, delayHeight);
                            position.y += delayHeight;
                            height += delayHeight;

                            // Draw Fields
                            availableEnemies = new string[serializedEnemies.arraySize];
                            for (var i = 0; i < serializedEnemies.arraySize; i++)
                            {
                                availableEnemies[i] = serializedEnemies.GetArrayElementAtIndex(i).stringValue;
                            }

                            EditorGUI.PropertyField(waveCountRect, serializedWaveCount);
                            EditorGUI.PropertyField(enemiesRect, serializedEnemies, true);
                            if (serializedEnemies.arraySize == 0)
                            {
                                serializedSelectedEnemy.intValue = -1;
                            }

                            serializedSelectedEnemy.intValue = EditorGUI.Popup(selectedEnemyRect, serializedSelectedEnemy.displayName, serializedSelectedEnemy.intValue, availableEnemies);
                            EditorGUI.PropertyField(enemeiesLVLRect, serializedEnemyLVL, true);
                            EditorGUI.PropertyField(delayRect, serializedDelay, true);
                        }
                        EditorGUI.indentLevel--;
                    }
                }
                EditorGUI.EndProperty();
            }
        }
#endif
    }

    public Wave[] waves;
}