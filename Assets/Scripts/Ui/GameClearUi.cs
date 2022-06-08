using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoToSleep.Manager;

namespace GoToSleep.UI
{
    public class GameClearUi : MonoBehaviour
    {
        public Button toMenu;
        public Button quitGame;

        private void Start()
        {
            UiManager.Instance.gameClearUi = this;
            toMenu.onClick.AddListener(() =>
            {
                UiManager.Instance.LoadScene(0);
                gameObject.SetActive(false);
            });
            quitGame.onClick.AddListener(() => GameManager.Instance.QuitGame());
            SetActive(false);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}
