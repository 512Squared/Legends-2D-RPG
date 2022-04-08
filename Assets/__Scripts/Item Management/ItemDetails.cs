using UnityEngine;
using Sirenix.OdinInspector;


[System.Serializable]
    public class ItemDetails 
    {
        [HorizontalGroup("Info"), TableColumnWidth(200)]
        [VerticalGroup("Info/a"), LabelWidth(90)]
        [TextArea(1,5)]
        [GUIColor(0.4f, 0.986f, 0.380f)]
        public string itemName;
        [HorizontalGroup("Info"), TableColumnWidth(200)]
        [VerticalGroup("Info/a"), LabelWidth(90)]
        [TextArea(7,7)]
        [GUIColor(0.4f, 0.986f, 0.380f)]
        public string itemDescription;



        [HorizontalGroup("Bools"), TableColumnWidth(120)]
        [VerticalGroup("Bools/a"), LabelWidth(90)]
        [GUIColor(0.4f, 0.886f, 0.780f)]
        public bool itemSelected;

        [HorizontalGroup("Bools"), TableColumnWidth(120)]
        [VerticalGroup("Bools/a"), LabelWidth(90)]
        [GUIColor(0.4f, 0.886f, 0.780f)]
        public bool isNewItem = true;

        [HorizontalGroup("Bools"), TableColumnWidth(120)]
        [VerticalGroup("Bools/a"), LabelWidth(90)]
        [GUIColor(0.4f, 0.886f, 0.780f)]
        public bool shopItem;

        [HorizontalGroup("Bools"), TableColumnWidth(120)]
        [VerticalGroup("Bools/a"), LabelWidth(90)]
        [GUIColor(0.4f, 0.886f, 0.780f)]
        public bool pickUpNotice = true;

        [HorizontalGroup("Bools"), TableColumnWidth(120)]
        [VerticalGroup("Bools/a"), LabelWidth(90)]
        [GUIColor(0.4f, 0.886f, 0.780f)]
        public bool isQuestObject;

        [HorizontalGroup("Bools"), TableColumnWidth(120)]
        [VerticalGroup("Bools/a"), LabelWidth(90)]
        [GUIColor(0.4f, 0.886f, 0.780f)]
        public bool isStackable;

        [InfoBox(
            "ALL RELICS ARE QUEST ITEMS. IF YOU TICK THIS BOX, MAKE SURE THE ITEM HAS A QUEST COMPONENT ATTACHED AND THAT 'ITEM IS RELIC' IS TICKED THERE TOO. A RELIC BOX FROM THE RELICS UI PANEL IN THE HIERARCHY MUST ALSO BE ATTACHED TO THE QUEST COMPONENT IF IT IS TO WORK CORRECTLY. ALSO, THE BUTTON ON THE UI PANEL NEEDS THE EXACT SAME ITEM NAME.",
            InfoMessageType.Warning, "isRelic")]
        [HorizontalGroup("Bools"), TableColumnWidth(120)]
        [VerticalGroup("Bools/a"), LabelWidth(90)]
        [GUIColor(0.4f, 0.886f, 0.780f)]
        public bool isRelic;

        [HorizontalGroup("Values"), TableColumnWidth(140)]
        [VerticalGroup("Values/a"), LabelWidth(100)]
        [GUIColor(0.8f, 0.286f, 0.780f)]
        public int itemCode;

        [HorizontalGroup("Values"), TableColumnWidth(140)]
        [VerticalGroup("Values/a"), LabelWidth(100)]
        [GUIColor(0.8f, 0.286f, 0.780f)]
        public int valueInCoins;

        [HorizontalGroup("Values"), TableColumnWidth(140)]
        [VerticalGroup("Values/a"), LabelWidth(100)]
        [GUIColor(0.8f, 0.286f, 0.780f)]
        public int amountOfEffect;

        [HorizontalGroup("Values"), TableColumnWidth(140)]
        [VerticalGroup("Values/a"), LabelWidth(100)]
        [GUIColor(0.8f, 0.286f, 0.780f)]
        public int itemAttack;

        [HorizontalGroup("Values"), TableColumnWidth(140)]
        [VerticalGroup("Values/a"), LabelWidth(100)]
        [GUIColor(0.8f, 0.286f, 0.780f)]
        public int itemDefence;

        [HorizontalGroup("Values"), TableColumnWidth(140)]
        [VerticalGroup("Values/a"), LabelWidth(100)]
        [GUIColor(0.8f, 0.286f, 0.780f)]
        public int amount;

        [HorizontalGroup("Types"), TableColumnWidth(90)]
        [VerticalGroup("Types/a"), HideLabel]
        [GUIColor(0.2f, 0.286f, 0.780f)]
        public ItemsManager.ItemType itemType;
        [HorizontalGroup("Types"), TableColumnWidth(90)]
        [VerticalGroup("Types/a"), HideLabel]
        [GUIColor(0.2f, 0.286f, 0.780f)]
        public ItemsManager.Shop shop; // inventory, shop1, shop2, shop3
        [HorizontalGroup("Types"), TableColumnWidth(90)]
        [VerticalGroup("Types/a"), HideLabel]
        [GUIColor(0.2f, 0.286f, 0.780f)]
        public ItemsManager.AffectType affectType;
        [HorizontalGroup("Types"), TableColumnWidth(90)]
        [VerticalGroup("Types/a"), HideLabel]
        [GUIColor(0.2f, 0.286f, 0.780f)]
        public Sprite itemsImage;
    }