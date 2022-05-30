using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class Enemy : Character
    {
        [SerializeField] protected EnemyInfo enemyInfo;

        public int GetEnemyIndex()
        {
            return enemyInfo.EnemyIndex;
        }
        public string GetEnemyDescription()
        {
            return enemyInfo.Description;
        }

    }
}
