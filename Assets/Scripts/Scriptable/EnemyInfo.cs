using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Object/Enemy")]
    public class EnemyInfo : ScriptableObject
    {
        [field: SerializeField] public int EnemyIndex { get; private set; }

        [field: SerializeField] public int AttackDamage { get; private set; }

    }
}
