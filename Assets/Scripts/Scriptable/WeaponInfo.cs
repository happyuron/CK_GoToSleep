using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{

    [CreateAssetMenu(fileName = "Weapon", menuName = "Object/Weapon")]
    public class WeaponInfo : ScriptableObject
    {
        public readonly string weaponName;

        public readonly string description;

        public readonly int attackDamage;

        public readonly bool isLongDistance;

        public readonly GameObject bulletPrefeb;

        public readonly GameObject damagedEffect;
    }
}
