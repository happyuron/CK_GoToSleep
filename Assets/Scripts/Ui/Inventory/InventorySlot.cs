using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoToSleep.Object;

namespace GoToSleep.UI
{
    public class InventorySlot : MonoBehaviour
    {

        [HideInInspector] public bool isFull;

        private Sprite nullSlotSprite;
        private Image image;

        private Item item;


        private void Awake()
        {
            image = GetComponent<Image>();
            nullSlotSprite = image.sprite;
            image.sprite = nullSlotSprite;
        }


        public void SetSlotImage(Item value)
        {
            item = value;
            image.sprite = value.GetItemSprite();
            isFull = true;
        }

        public void RemoveItem()
        {
            item = null;
            image.sprite = nullSlotSprite;
            isFull = false;
        }
        public Item GetItem()
        {
            return item;
        }
    }
}
