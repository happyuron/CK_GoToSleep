using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;

namespace GoToSleep.Object
{
    interface IAttackType<T> where T : Weapon
    {
    }
    public class Weapon : MonoBehaviour, IAttackType<Weapon>
    {
        public WeaponInfo WeaponInformation { get; protected set; }

        protected Player Player { get; set; }
        protected virtual void Start()
        {
            Player = CharacterManager.Instance.Player;
        }
        

    }
}
