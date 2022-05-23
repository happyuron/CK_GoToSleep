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
            weapon.Attack(ref curAttackCount);
        }
    }
}
