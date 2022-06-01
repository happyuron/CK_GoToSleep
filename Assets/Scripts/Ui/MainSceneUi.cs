using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoToSleep.Manager;

namespace GoToSleep.UI
{
    public class MainSceneUi : MonoBehaviour
    {
        public Button startButton;


        private void Start()
        {
            startButton.onClick.AddListener(() => UiManager.Instance.LoadScene(1));
        }



    }
}
