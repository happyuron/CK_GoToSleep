using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoToSleep.Manager;

namespace GoToSleep.UI
{
    public class PopUpUi : MonoBehaviour
    {
        public Button toSetting;

        public Button quitGame;


        private void Awake()
        {
            toSetting.onClick.AddListener(() =>
            {
                UiManager.Instance.SettingUiActive(true);
                UiManager.Instance.PopUpUiActive(false);
            });

            quitGame.onClick.AddListener(() => GameManager.Instance.QuitGame());
        }

        private void Start()
        {
            SetActive(false);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
