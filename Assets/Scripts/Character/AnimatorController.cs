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

        public void Attack()
        {
            player.Attack.Attack();
        }
        public void UponAttack()
        {
            player.Attack.UponAttack();
        }
        public void DownAttack()
        {
            player.Attack.DownAttack();
        }

        public void StartCooltime()
        {
            player.Attack.StartCooltime();
            PlayerAnimation.PlayerAnimInteger("State", (int)PlayerState.Normal);
        }

    }
}
