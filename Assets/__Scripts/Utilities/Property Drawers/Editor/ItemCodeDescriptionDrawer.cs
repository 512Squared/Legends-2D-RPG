
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ItemCodeDescriptionAttribute))]
public class ItemCodeDescriptionDrawer : PropertyDrawer
{
    private const float ImageHeight = 100;
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Change the returned property height to be double to cater for the additional item code description that we will draw
        
        return EditorGUI.GetPropertyHeight(property) + ImageHeight + 50;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that prefab override logic works on the entire property.

        EditorGUI.BeginProperty(position, label, property);

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            EditorGUI.BeginChangeCheck(); // Start of check for changed values
           
            var newValue = EditorGUI.IntField(new Rect(position.x, position.y, position.width, position.height - ImageHeight - 50), label, property.intValue);

            // Draw item name
            EditorGUI.LabelField(new Rect(position.x, position.y + 20, position.width, position.height - ImageHeight - 50), "Item Name", GetItemDescription(property.intValue));
            // Draw Item image
            GUI.DrawTexture(new Rect(position.x, position.y + 40, position.width, position.height - 50),  GetItemImage(property.intValue).texture, ScaleMode.ScaleToFit);
            
            // If item code value has changed, then set value to new value
            if (EditorGUI.EndChangeCheck())
            {
                property.intValue = newValue;
            }

        }

        EditorGUI.EndProperty();
    }

    private static string GetItemDescription(int itemCode)
    {
        SO_itemsList so_itemList = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Items/so_itemList.asset",typeof(SO_itemsList)) as SO_itemsList;

        List<ItemDetails> itemDetailsList = so_itemList!.itemsDetails; 
        
        if (itemCode > itemDetailsList.Count + 1000 || itemCode < 1001) return "ITEM CODE OUT OF RANGE - PLEASE try again!";
        
        ItemDetails itemDetail = itemDetailsList.Find(x => x.itemCode == itemCode);
        if (itemDetail == null) return "ERROR - is the item code in SO_itemsList correct?";
        return string.IsNullOrEmpty(itemDetail.itemName) ? "ERROR - Item exists but needs DATA!" : itemDetail.itemName;
    }
    
    private static Sprite GetItemImage(int itemCode)
    {
        SO_itemsList so_itemList = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Items/so_itemList.asset",typeof(SO_itemsList)) as SO_itemsList;
        
        Sprite error = AssetDatabase.LoadAssetAtPath("Assets/Sprites/UI/error.png",typeof(Sprite)) as Sprite;
        
        List<ItemDetails> itemDetailsList = so_itemList!.itemsDetails;
        if (itemCode > itemDetailsList.Count + 1000 || itemCode <= 1000) return error; 
        
        ItemDetails itemDetail = itemDetailsList.Find(x => x.itemCode == itemCode);
        if (itemDetail == null) return error;
        return itemDetail.itemsImage != null ? itemDetail.itemsImage : error;
    }
    

}


