using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.UI;
using GoToSleep.Object;

namespace GoToSleep.Manager
{
    public class UiManager : Singleton<UiManager>
    {

        public Inventory inventory;

        public HpUi hpUi;

        public GameDescription gameDescription;

        public PopUpUi popUpUi;

        public SettingUi settingUi;

        public LoadingScene loading;
        public void SetActiveTabUi(bool value)
        {
            gameDescription.gameObject.SetActive(value);
        }

        public Item FindItemInInventory(Item item)
        {
            return inventory.FindItemInInventory(item);
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
            if (value)
            {
                InputManager.Instance.action -= InputManager.Instance.HidePopup;
                InputManager.Instance.action += InputManager.Instance.HideSetting;
            }

        }

        public void PopUpUiActive(bool value)
        {
            popUpUi.SetActive(value);
        }

        public void LoadScene(int index)
        {
            loading.LoadScene(index);
        }
    }
}
