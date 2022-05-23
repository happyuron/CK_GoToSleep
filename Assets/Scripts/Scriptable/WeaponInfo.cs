using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    [System.Serializable]
    public class AttackInfo
    {
        [field: SerializeField] public Vector3 Offset;
        [field: SerializeField] public Vector2 Size;

        [field: SerializeField] public int Damage { get; private set; }

    }

    [CreateAssetMenu(fileName = "Weapon", menuName = "Object/Weapon")]
    public class WeaponInfo : ScriptableObject
    {
        [field: SerializeField] public string WeaponName;

        [field: SerializeField] public string Description;

        [field: SerializeField] public int AttackDamage;

        [field: SerializeField] public GameObject DamageEffect;

        public AttackInfo[] attackInfos;

        public AttackInfo[] uponAttackInfos;

        public AttackInfo[] downAttackInfos;
    }
}
