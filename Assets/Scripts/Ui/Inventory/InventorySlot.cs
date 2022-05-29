using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoToSleep.UI
{
    public class InventorySlot : MonoBehaviour
    {
        public Sprite nullSlotSprite;

        [HideInInspector] public bool isFull;

        private Image image;


        private void Awake()
        {
            image = GetComponent<Image>();
            image.sprite = nullSlotSprite;
        }


        public void SetSlotImage(Sprite itemSprite)
        {
            image.sprite = itemSprite;
            isFull = true;
        }

        public void RemoveItem()
        {
            image.sprite = nullSlotSprite;
            isFull = false;
        }
    }
}
