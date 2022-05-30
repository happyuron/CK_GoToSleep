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

        public Slider effectSoundBar;

        public TextMeshProUGUI text;

        private void Awake()
        {
            mainSoundBar.onValueChanged.AddListener(_ => SoundManager.Instance.MainSoundVolume = mainSoundBar.value);
            effectSoundBar.onValueChanged.AddListener(_ => SoundManager.Instance.EffectSoundVolume = effectSoundBar.value);
        }
    }
}
