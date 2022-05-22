using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class PlayerAttack : PlayerPart<Player>
    {
        public Weapon weapon;


        private void Start()
        {
            weapon = GetComponentInChildren<Weapon>();
        }

        public void WeaponUpdate()
        {

        }
    }
}
