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

        public EnemyState state;

        public bool isMoving => move.IsMoving;

        public bool isAttacking => attack.IsAttacking;

        public bool IsDead { get; private set; }

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

        public override void CharacterDead()
        {
            state = EnemyState.Dead;
            IsDead = true;
            Rigid.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer("NonHitLayer");
            Anim.SetInteger("State", (int)EnemyState.Dead);
        }





    }
}
