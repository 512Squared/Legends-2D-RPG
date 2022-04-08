using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "so_itemList", menuName = "Scriptable Objects/item/Item List")]
public class SO_itemsList : ScriptableObject
{
    [TableList]
    [SerializeField] public List<ItemDetails> itemDetail;
    
}
