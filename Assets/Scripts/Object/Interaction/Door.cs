using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;

namespace GoToSleep.Object
{
    public class Door : InteractiveObj
    {
        public Item key;
        protected override void StartInteraction()
        {
            if (UiManager.Instance.FindItemInInventory(key))
            {
                Debug.Log("문이 열림");
            }
        }
    }
}
