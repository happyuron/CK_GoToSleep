using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace GoToSleep.Object
{
    public class PlayerAnimation
    {
        public static Animator defaultAnim;
        public static void PlayerAnimInteger(string name, int index, Animator anim = null)
        {
            anim = anim ?? defaultAnim;
            anim.SetInteger(name, index);
        }
    }
    public class PlayerController : PlayerPart<Player>
    {
        public PlayerInputAction playerControls;

        private InputAction move;

        private InputAction attack;

        private InputAction jump;



        protected override void Init()
        {
            base.Init();
            playerControls = new PlayerInputAction();
            move = playerControls.Player.Move;
            attack = playerControls.Player.Fire;
            jump = playerControls.Player.Jump;
            move.performed += Move;
            attack.performed += Attack;
            jump.performed += Jump;
        }

        private void OnEnable()
        {
            ConnectController();
        }

        public void ConnectController()
        {
            move.Enable();
            attack.Enable();
            jump.Enable();
        }
        public void DIsconnectController()
        {
            move.Disable();
            attack.Disable();
            jump.Disable();
        }
        private void Move(InputAction.CallbackContext ctx)
        {

            Player.Move.MoveRight(ctx.ReadValue<Vector2>().x);

        }
        public void Attack(InputAction.CallbackContext ctx)
        {
            Player.Attack.Attack();
        }
        public void Jump(InputAction.CallbackContext ctx)
        {
            Player.Move.Jump();
        }

        private void OnDisable()
        {
            DIsconnectController();
        }
    }
}
