using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;

namespace GoToSleep.Object
{
    public class AnimatorController : MonoBehaviour
    {
        public Player player;
        private void Start()
        {
            player = CharacterManager.Instance.Player ?? FindObjectOfType<Player>();
        }

        public void HorizontalAttack()
        {
            player.Attack.Attack();
        }

    }
}
