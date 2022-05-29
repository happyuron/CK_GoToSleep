using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.UI
{
    public class Inventory : MonoBehaviour
    {
        private InventorySlot[] slotList;


        private void Start()
        {
            slotList = GetComponentsInChildren<InventorySlot>();
        }
    }
}
