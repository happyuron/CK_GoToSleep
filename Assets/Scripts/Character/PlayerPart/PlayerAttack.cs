using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class PlayerAttack : PlayerPart<Player>
    {
        public Weapon weapon;

        public bool IsAttacking;

        private int curAttackCount;

        private int curUponAttackCount;

        private int curDownAttackCount;

        private float curAttackCooltime;



        private void Start()
        {
            weapon = GetComponentInChildren<Weapon>();
        }

        public void Attack()
        {
            PlayerAnimation.PlayerAnimInteger("State", (int)PlayerState.Attack);
            PlayerAnimation.PlayerAnimFloat("Blend Attack", 0);
            IsAttacking = true;
            curUponAttackCount = 0;
            curDownAttackCount = 0;
            weapon.Attack(ref curAttackCount);
        }
        public void UponAttack()
        {
            curAttackCount = 0;
            curDownAttackCount = 0;
            weapon.UponAttack(ref curUponAttackCount);
        }
        public void DownAttack()
        {
            curAttackCount = 0;
            curUponAttackCount = 0;
            weapon.DownAttack(ref curDownAttackCount);
        }
        private IEnumerator UpdateCooltime()
        {
            curAttackCooltime = weapon.WeaponInformation.AttackCooltime;
            while (curAttackCooltime > 0)
            {
                yield return null;
                curAttackCooltime -= Time.deltaTime;
            }
        }

        public float GetCoolTime()
        {
            return curAttackCooltime;
        }
        public void StartCooltime()
        {
            StartCoroutine(UpdateCooltime());
        }
    }
}
