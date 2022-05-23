using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class PlayerAttack : PlayerPart<Player>
    {
        public Weapon weapon;

        public int curAttackCount;

        public int curUponAttackCount;

        public int curDownAttackCount;


        private void Start()
        {
            weapon = GetComponentInChildren<Weapon>();
        }

        public void Attack()
        {
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
    }
}
