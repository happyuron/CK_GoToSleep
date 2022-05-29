using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoToSleep.Manager;

namespace GoToSleep.UI
{
    public class HpUi : MonoBehaviour
    {
        private Image[] hpImages;

        private List<Image> images;
        private void Awake()
        {
            hpImages = GetComponentsInChildren<Image>();
            UiManager.Instance.hpUi = this;
        }

        private void Start()
        {
            UpdateHp();
        }

        public void UpdateHp()
        {
            for (int i = 0; i < hpImages.Length; i++)
            {
                if (i < CharacterManager.Instance.Player.Hp)
                    hpImages[i].gameObject.SetActive(true);
                else
                    hpImages[i].gameObject.SetActive(false);
            }
        }
    }
}
