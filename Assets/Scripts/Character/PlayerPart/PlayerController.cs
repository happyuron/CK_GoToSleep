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

        private InputAction run;



        protected override void Init()
        {
            base.Init();
            playerControls = new PlayerInputAction();
            move = playerControls.Player.Move;
            attack = playerControls.Player.Fire;
            jump = playerControls.Player.Jump;
            run = playerControls.Player.Run;
            move.performed += Move;
            attack.performed += Attack;
            jump.performed += Jump;
            run.performed += Run;
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
            run.Enable();
        }
        public void DIsconnectController()
        {
            move.Disable();
            attack.Disable();
            jump.Disable();
            run.Disable();
        }
        private void Move(InputAction.CallbackContext ctx)
        {

            Player.Move.MoveRight(ctx.ReadValue<Vector2>().x);

        }
        public void Attack(InputAction.CallbackContext ctx)
        {
            PlayerAnimation.PlayerAnimInteger("State", (int)PlayerState.Attack);
            if (Keyboard.current.downArrowKey.isPressed && Player.IsJumping)
            {
                PlayerAnimation.PlayerAnimInteger("Blend Attack", 0);
            }
            else if (Keyboard.current.upArrowKey.isPressed)
            {
                PlayerAnimation.PlayerAnimInteger("Blend Attack", 1);
            }
            else
            {
                PlayerAnimation.PlayerAnimInteger("Blend Attack", 2);
            }

        }
        public void Jump(InputAction.CallbackContext ctx)
        {
            Player.Move.Jump();
        }

        public void Run(InputAction.CallbackContext ctx)
        {
            if (Keyboard.current.shiftKey.wasPressedThisFrame)
            {
                Player.Move.Run(true);
            }
            else if (Keyboard.current.shiftKey.wasReleasedThisFrame)
            {
                Debug.Log("ss");
                Player.Move.Run(false);
            }
        }

        private void OnDisable()
        {
            DIsconnectController();
        }
    }
}
