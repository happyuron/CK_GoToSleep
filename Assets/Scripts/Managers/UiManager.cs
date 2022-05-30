using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.UI;

namespace GoToSleep.Manager
{
    public class UiManager : Singleton<UiManager>
    {

        public Inventory inventory;

        public HpUi hpUi;

        public GameDescription gameDescription;

        public SettingUi settingUi;

        private void Start()
        {
            if (inventory == null)
                inventory = FindObjectOfType<Inventory>();
        }


        public void SetActiveTabUi(bool value)
        {
            gameDescription.gameObject.SetActive(value);
        }

        public void UpdateHp()
        {
            hpUi.UpdateHp();
        }

        public void SetDescription(int index, string text)
        {
            gameDescription.SetText(index, text);
        }

        public void AddText(int index, string text)
        {
            gameDescription.AddText(index, text);
        }

        public void SettingUiActive(bool value)
        {
            settingUi.SetActive(value);
        }
    }
}
