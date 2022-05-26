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
        public static void PlayerAnimFloat(string name, float index, Animator anim = null)
        {
            anim = anim ?? defaultAnim;
            anim.SetFloat(name, index);
        }
    }
    public class PlayerController : PlayerPart<Player>
    {
        public PlayerInputAction playerControls;

        private InputAction move;

        private InputAction attack;

        private InputAction jump;

        private InputAction run;

        private InputAction interact;


        protected override void Init()
        {
            base.Init();
            playerControls = new PlayerInputAction();
            move = playerControls.Player.Move;
            attack = playerControls.Player.Fire;
            jump = playerControls.Player.Jump;
            run = playerControls.Player.Run;
            interact = playerControls.Player.Interaction;
            move.performed += Move;
            attack.performed += Attack;
            jump.performed += Jump;
            run.performed += Run;
            interact.performed += Interacte;
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
            interact.Enable();
        }
        public void DIsconnectController()
        {
            move.Disable();
            attack.Disable();
            jump.Disable();
            run.Disable();
            interact.Disable();
        }
        private void Move(InputAction.CallbackContext ctx)
        {
            Player.Move.MoveRight(ctx.ReadValue<Vector2>().x);
        }
        public void Attack(InputAction.CallbackContext ctx)
        {
            int index = Keyboard.current.downArrowKey.isPressed && Player.IsJumping ? 0 : Keyboard.current.upArrowKey.isPressed ? 1 : 2;
            Player.PlayAttackAnimation(index);
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
                Player.Move.Run(false);
            }
        }

        public void Interacte(InputAction.CallbackContext ctx)
        {
            if (Player.interactiveObj != null)
            {
                Player.interactiveObj.Interacte();
            }
        }

        private void OnDisable()
        {
            DIsconnectController();
        }
    }
}
