using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public enum EnemyState
    {
        Idle, Move, Attack, Dead
    }
    public class Enemy : Character
    {


        public bool isMoving => move.IsMoving;

        public bool isAttacking => attack.IsAttacking;
        public EnemyAttack attack;
        private EnemyMove move;

        public Animator Anim { get; private set; }

        [SerializeField] protected EnemyInfo enemyInfo;

        protected override void Init()
        {
            base.Init();
            move = GetComponent<EnemyMove>();
            Anim = GetComponentInChildren<Animator>();
            attack = GetComponent<EnemyAttack>();
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
