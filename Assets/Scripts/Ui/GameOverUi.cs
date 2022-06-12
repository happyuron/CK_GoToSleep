using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoToSleep.Manager;

namespace GoToSleep.UI
{
    public class GameOverUi : MonoBehaviour
    {
        public Button restart;

        public Button toMenu;

        private void Start()
        {
            restart.onClick.AddListener(() =>
            {
                UiManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
                SetActive(false);
            });
            toMenu.onClick.AddListener(() =>
            {
                UiManager.Instance.LoadScene(0);
                SetActive(false);
            });
            SetActive(false);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
