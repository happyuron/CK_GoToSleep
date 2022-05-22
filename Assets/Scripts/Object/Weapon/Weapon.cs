using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    interface IAttackType<T> where T : Weapon
    {
    }
    public class Weapon : MonoBehaviour, IAttackType<Weapon>
    {
        public WeaponInfo WeaponInformation { get; protected set; }
        protected virtual void Awake()
        {

        }

    }
}
