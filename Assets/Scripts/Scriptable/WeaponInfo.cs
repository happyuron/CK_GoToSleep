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
        [field: SerializeField] public string WeaponName { get; private set; }

        [field: SerializeField] public string Description { get; private set; }

        [field: SerializeField] public int AttackDamage { get; private set; }

        [field: SerializeField] public float AttackCooltime { get; private set; }

        [field: SerializeField] public GameObject DamageEffect { get; private set; }

        [field: SerializeField] public AttackInfo[] AttackInfos { get; private set; }

        [field: SerializeField] public AttackInfo[] UponAttackInfos { get; private set; }

        [field: SerializeField] public AttackInfo[] DownAttackInfos { get; private set; }
    }
}
