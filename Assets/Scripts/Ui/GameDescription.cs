using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GoToSleep.UI
{
    public class GameDescription : MonoBehaviour
    {
        public TextMeshProUGUI text;

        public string[] description;

        private Dictionary<int, string> goalText;


        public void SetText(int bossIndex, string value)
        {
            goalText.Add(bossIndex, value);
        }

        public string GetText(int bossIndex)
        {
            return goalText[bossIndex] ?? null;
        }

    }
}
