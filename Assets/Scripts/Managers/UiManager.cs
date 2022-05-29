using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.UI;

namespace GoToSleep.Manager
{
    public class UiManager : Singleton<UiManager>
    {
        public GameObject tabUi;

        public Inventory inventory;

        private void Start()
        {
            if (inventory == null)
                inventory = FindObjectOfType<Inventory>();
        }


        public void SetActiveTabUi(bool value)
        {
            tabUi.SetActive(value);
        }
    }
}
