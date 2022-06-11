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

        public float curAttackCooltime;

        private float curSkillCooltime;



        private void Start()
        {
            weapon = GetComponentInChildren<Weapon>();
        }

        public void Attack()
        {
            IsAttacking = true;
            curUponAttackCount = 0;
            curDownAttackCount = 0;
            weapon.Attack(ref curAttackCount);
        }

        public void AttackSkill()
        {
            IsAttacking = true;
            weapon.SkillAttack(weapon.WeaponInformation.AttackInfos[0].Damage * 2);
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
        private IEnumerator UpdateAttackCooltime()
        {
            curAttackCooltime = weapon.WeaponInformation.AttackCooltime;
            while (curAttackCooltime > 0)
            {
                yield return null;
                curAttackCooltime -= Time.deltaTime;
            }
        }
        private IEnumerator UpdateSkillCooltime()
        {
            curSkillCooltime = weapon.WeaponInformation.AttackCooltime;
            while (curSkillCooltime > 0)
            {
                yield return null;
                curSkillCooltime -= Time.deltaTime;
            }
        }

        public float GetAttackCoolTime()
        {
            return curAttackCooltime;
        }

        public float GetSkillCoolTime()
        {
            return curSkillCooltime;
        }
        public void StartAttackCooltime()
        {
            StartCoroutine(UpdateAttackCooltime());
        }


        public void StartSkillCooltime()
        {
            StartCoroutine(UpdateSkillCooltime());
        }
    }
}
