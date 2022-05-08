using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "so_itemList", menuName = "Scriptable Objects/Item/Item List")]
public class SoItemsList : ScriptableObject
{
    [TableList(ShowPaging = true, NumberOfItemsPerPage = 5)] [SerializeField]
    public List<ItemDetails> itemsDetails;
}