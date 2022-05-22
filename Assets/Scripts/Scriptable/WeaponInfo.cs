using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{

    [CreateAssetMenu(fileName = "Weapon", menuName = "Object/Weapon")]
    public class WeaponInfo : ScriptableObject
    {
        [field: SerializeField] public string WeaponName;

        [field: SerializeField] public string Description;

        [field: SerializeField] public int AttackDamage;

        [field: SerializeField] public bool IsLongDistance;

        [field: SerializeField] public GameObject BulletPrefeb;

        [field: SerializeField] public GameObject DamageEffect;
    }
}
