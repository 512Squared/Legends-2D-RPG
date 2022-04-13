using UnityEngine;
using Sirenix.OdinInspector;


[System.Serializable]
public class ItemDetails
{
    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [VerticalGroup("Data/a")]
    [HideLabel]
    [GUIColor(0.058f, 0.380f, 1f)]
    public ItemsManager.ItemType itemType;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [VerticalGroup("Data/a")]
    [HideLabel]
    [GUIColor(0.058f, 0.380f, 1f)]
    public ItemsManager.AffectType affectType;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [VerticalGroup("Data/a")]
    [HideLabel]
    [GUIColor(0.058f, 0.380f, 1f)]
    public Shop shop; // inventory, shop1, shop2, shop3

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [VerticalGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int itemCode = 1000;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [VerticalGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int valueInCoins;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [VerticalGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int amountOfEffect;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [VerticalGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int itemAttack;

    [HorizontalGroup("Data")]
    [TableColumnWidth(160)]
    [VerticalGroup("Data/a")]
    [LabelWidth(100)]
    [GUIColor(0.8f, 0.286f, 0.780f)]
    public int itemDefence;

    [HorizontalGroup("Info")]
    [TableColumnWidth(220)]
    [VerticalGroup("Info/a")]
    [LabelWidth(90)]
    [TextArea(1, 5)]
    [GUIColor(0.4f, 0.986f, 0.380f)]
    public string itemName;

    [Space]
    [HorizontalGroup("Info")]
    [TableColumnWidth(220)]
    [VerticalGroup("Info/a")]
    [LabelWidth(90)]
    [TextArea(7, 7)]
    [GUIColor(0.4f, 0.986f, 0.380f)]
    public string itemDescription;

    [Space]
    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [VerticalGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool itemSelected;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [VerticalGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isNewItem = true;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [VerticalGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool shopItem;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [VerticalGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isQuestObject;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [VerticalGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool pickUpNotice = true;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [VerticalGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isRelic;

    [HorizontalGroup("Bools")]
    [TableColumnWidth(120)]
    [VerticalGroup("Bools/a")]
    [LabelWidth(90)]
    [GUIColor(0.4f, 0.886f, 0.780f)]
    public bool isStackable;

    [HorizontalGroup("Sprite")]
    [TableColumnWidth(120)]
    [VerticalGroup("Sprite/a")]
    [HideLabel]
    [Space]
    [Space]
    [Space]
    [PreviewField(120, ObjectFieldAlignment.Center)]
    [GUIColor(0.2f, 0.286f, 0.680f)]
    public Sprite itemsImage;
}