using System;
using UnityEngine;


    public class Item : MonoBehaviour
    {
        [SerializeField]
        private int itemCode;

        private SpriteRenderer _spriteRenderer;

        public int ItemCode { get => itemCode; set => itemCode = value; }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if (ItemCode != 0)
            {
                Init(ItemCode);
            }
        }
        
        public void Init(int itemCodeParam)
        {
            if (itemCodeParam == 0)
            {
                return;
            }

            ItemCode = itemCodeParam;

            ItemDetails itemDetails = Inventory.Instance.GetItemDetails(ItemCode);
        }
    }
