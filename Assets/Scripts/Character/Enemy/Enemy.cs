using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class Enemy : Character
    {
        [SerializeField] protected EnemyInfo enemyInfo;

        private EnemyMove move;


        protected override void Awake()
        {
            base.Awake();
            move = GetComponent<EnemyMove>();

        }

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
