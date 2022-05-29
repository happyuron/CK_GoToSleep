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


        private void Start()
        {
            slotList = GetComponentsInChildren<InventorySlot>();
            Debug.Log(slotList.Length);
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
    }
}
