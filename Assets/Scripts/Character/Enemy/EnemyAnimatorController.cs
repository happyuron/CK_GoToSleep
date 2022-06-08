using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class EnemyAnimatorController : MonoBehaviour
    {
        private Enemy enemy;

        private void Awake()
        {
            enemy = GetComponentInParent<Enemy>();
        }
        protected virtual void Attack()
        {
            enemy.attack.StartCoolTimeCoroutine();
            Player player = enemy.attack.CheckAttackRange();
            if (player != null)
            {
                player.GetDamaged(1);
            }
        }

        protected virtual void AttackEnd()
        {
            enemy.attack.IsAttacking = false;
        }

        protected virtual void Dead()
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
