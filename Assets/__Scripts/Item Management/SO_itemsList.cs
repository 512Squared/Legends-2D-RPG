using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "so_itemList", menuName = "Scriptable Objects/Item/Item List")]
public class SO_itemsList : ScriptableObject
{
    [TableList(ShowPaging = true, NumberOfItemsPerPage = 4)] [SerializeField]
    public List<ItemDetails> itemsDetails;
}