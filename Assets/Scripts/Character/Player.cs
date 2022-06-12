using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;

namespace GoToSleep.Object
{
    public enum PlayerState
    {
        Normal, Jump, Attack, Dead
    }
    public class Player : Character
    {
        public PlayerMove Move { get; private set; }

        public PlayerAttack Attack { get; private set; }


        public Animator Anim { get; private set; }

        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float JumpStrength { get; private set; }
        [field: SerializeField] public float RunSpeed { get; private set; }
        public PlayerState CurState { get; private set; }
        public InteractiveObj interactiveObj;
        public float DefaultGravity { get; private set; }

        public bool IsJumping => Move.IsJumping;

        public bool IsClimbing => Move.IsClimbing;

        public bool IsAttacking => Attack.IsAttacking;

        public bool IsMoving => Move.IsMoving;

        public PlayerController controller;


        protected override void Init()
        {
            base.Init();
            DefaultGravity = Rigid.gravityScale;
            Move = GetComponent<PlayerMove>();
            Anim = GetComponentInChildren<Animator>();
            Attack = GetComponent<PlayerAttack>();
            controller = GetComponent<PlayerController>();
            if (Anim != null)
            {
                PlayerAnimation.defaultAnim = Anim;
            }
        }

        public void PlayAttackAnimation(int attackIndex)
        {
            Debug.Log(Attack.GetAttackCoolTime());
            if (Attack.GetAttackCoolTime() <= 0)
            {
                PlayerAnimation.PlayerAnimInteger("State", (int)PlayerState.Attack);
                PlayerAnimation.PlayerAnimFloat("Blend Attack", 0);
            }
        }

        public void PlayAttackSkillAnimation()
        {
            Debug.Log(Attack.GetSkillCoolTime());

            if (Attack.GetSkillCoolTime() <= 0)
            {
                PlayerAnimation.PlayerAnimInteger("State", (int)PlayerState.Attack);
                PlayerAnimation.PlayerAnimFloat("Blend Attack", 1);
            }
        }

        public bool IsDead()
        {
            return CurState == PlayerState.Dead;
        }
        public bool IsNormalState()
        {
            return CurState == PlayerState.Normal;
        }

        public void GetItem(Item item)
        {
            UiManager.Instance.inventory.SetSlot(item);
        }

        public override void GetDamaged(int damage)
        {
            base.GetDamaged(damage);
            UiManager.Instance.UpdateHp();
        }

        public override void CharacterDead()
        {
            CurState = PlayerState.Dead;
            Move.moveVelocityX = 0;
            controller.DIsconnectController();
            UiManager.Instance.SetupGameOverUi();
            gameObject.SetActive(false);
        }

        public override void Revive()
        {
            controller.ConnectController();
        }
    }

}
