using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Object;
using GoToSleep.Manager;

namespace GoToSleep.UI
{
    public class Inventory : MonoBehaviour
    {
        private InventorySlot[] slotList;

        private void Awake()
        {
            UiManager.Instance.inventory = this;
        }

        private void Start()
        {
            slotList = GetComponentsInChildren<InventorySlot>();
            UiManager.Instance.SetActiveTabUi(false);
        }


        public bool SetSlot(Item item)
        {
            InventorySlot slot = null;
            for (int i = 0; i < slotList.Length; i++)
            {
                if (!slotList[i].isFull)
                {
                    slot = slotList[i];
                    slot.SetSlotImage(item);
                    break;
                }
            }
            return slot != null ? true : false;
        }
        public Item FindItemInInventory(Item item)
        {
            for (int i = 0; i < slotList.Length; i++)
            {
                if (slotList[i].isFull && item == slotList[i].GetItem())
                    return slotList[i].GetItem();
            }
            return null;
        }

        public void RemoveItem(Item item)
        {
            for (int i = 0; i < slotList.Length; i++)
            {
                if (slotList[i].isFull && item == slotList[i].GetItem())
                {
                    slotList[i].RemoveItem();
                }
            }
        }
    }
}
