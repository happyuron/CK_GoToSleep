using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoToSleep.Manager;
using TMPro;

namespace GoToSleep.UI
{
    public class SettingUi : MonoBehaviour
    {
        public Slider mainSoundBar;

        public Slider soundEffectBar;

        public TextMeshProUGUI mainSound;

        public TextMeshProUGUI soundEffect;

        public Button closeButton;

        private void Awake()
        {
            mainSoundBar.onValueChanged.AddListener(_ =>
            {
                SoundManager.Instance.MainSoundVolume = mainSoundBar.value;
                mainSound.text = GetPercentage(mainSoundBar.value);
            });
            soundEffectBar.onValueChanged.AddListener(_ =>
            {
                SoundManager.Instance.SoundEffectVolume = soundEffectBar.value;
                soundEffect.text = GetPercentage(soundEffectBar.value);
            });
            closeButton.onClick.AddListener(() =>
            {
                SetActive(false);
                InputManager.Instance.AddCloseSystem();
            });
        }

        private void Start()
        {
            mainSound.text = GetPercentage(mainSoundBar.value);
            soundEffect.text = GetPercentage(soundEffectBar.value);
            UiManager.Instance.settingUi = this;
            SetActive(false);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public string GetPercentage(float value)
        {
            value *= 100;

            return ((int)value).ToString() + "%";
        }
    }
}
