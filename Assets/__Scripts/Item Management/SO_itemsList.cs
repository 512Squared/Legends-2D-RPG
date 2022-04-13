using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "so_itemList", menuName = "Scriptable Objects/item/Item List")]
public class SO_itemsList : ScriptableObject
{
    [TableList(ShowPaging = true, NumberOfItemsPerPage = 5)] [SerializeField]
    public List<ItemDetails> itemsDetails;
}