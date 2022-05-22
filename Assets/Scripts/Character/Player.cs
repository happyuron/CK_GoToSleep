using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoToSleep.Object
{
    public enum PlayerState
    {
        Idle, Move, Jump, Attack, Dead
    }
    public class Player : Character
    {
        public PlayerMove Move { get; private set; }

        public Animator Anim { get; private set; }

        [field: SerializeField] public float MoveSpeed { get; private set; }

        [field: SerializeField] public float JumpStrength { get; private set; }

        public PlayerState CurState { get; private set; }



        protected override void Init()
        {
            base.Init();
            Move = GetComponent<PlayerMove>();
            Anim = GetComponentInChildren<Animator>();
            if (Anim != null)
            {
                PlayerAnimation.defaultAnim = Anim;
            }
        }


        public bool IsDead()
        {
            return CurState == PlayerState.Dead;
        }
        public bool IsNormalState()
        {
            return CurState == PlayerState.Idle || CurState == PlayerState.Move || CurState == PlayerState.Jump;
        }
    }

}
