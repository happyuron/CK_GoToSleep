using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;

namespace GoToSleep.Object
{
    interface IAttackType<T> where T : Weapon
    {
        public void Attack(ref int index);
        public void DownAttack(ref int index);
        public void UponAttack(ref int index);

    }
    public class Weapon : MonoBehaviour, IAttackType<Weapon>
    {
        [field: SerializeField] public WeaponInfo WeaponInformation { get; protected set; }

        [SerializeField] protected LayerMask hitLayer;

        protected int attackCount;

        protected int uponAttackCount;

        protected int downAttackCount;


        protected Player Player { get; set; }

        protected virtual void Awake()
        {
            attackCount = WeaponInformation.AttackInfos.Length;
            uponAttackCount = WeaponInformation.UponAttackInfos.Length;
            downAttackCount = WeaponInformation.DownAttackInfos.Length;
        }

        protected virtual void Start()
        {
            Player = CharacterManager.Instance.Player;
        }

        public virtual void Attack(ref int index)
        {

        }

        public virtual void DownAttack(ref int index)
        {

        }
        public virtual void UponAttack(ref int index)
        {

        }

    }
}
