using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using GoToSleep.Manager;

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

        private InputAction interact;

        private InputAction dash;

        private InputAction showUi;

        private InputAction run;

        private bool isOneTap;


        protected override void Init()
        {
            base.Init();
            playerControls = new PlayerInputAction();
            move = playerControls.Player.Move;
            attack = playerControls.Player.Fire;
            jump = playerControls.Player.Jump;
            interact = playerControls.Player.Interaction;
            dash = playerControls.Player.Dash;
            showUi = playerControls.Player.ShowUi;
            run = playerControls.Player.Run;
            move.performed += Move;
            attack.performed += Attack;
            jump.performed += Jump;
            interact.performed += Interacte;
            dash.performed += Dash;
            showUi.performed += ShowUi;
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
            interact.Enable();
            dash.Enable();
            showUi.Enable();
            run.Enable();
        }
        public void DIsconnectController()
        {
            move.Disable();
            attack.Disable();
            jump.Disable();
            interact.Disable();
            dash.Disable();
            showUi.Disable();
            run.Disable();

        }
        private void Move(InputAction.CallbackContext ctx)
        {
            if (ctx.interaction is PressInteraction)
            {
                Player.Move.MoveRight(ctx.ReadValue<Vector2>().x);
            }
        }

        private void Run(InputAction.CallbackContext ctx)
        {
            if (ctx.interaction is TapInteraction)
                Player.Move.Run();
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
        public void Interacte(InputAction.CallbackContext ctx)
        {
            if (Player.interactiveObj != null)
            {
                Player.interactiveObj.Interacte();
            }
        }

        public void Dash(InputAction.CallbackContext ctx)
        {
            StartCoroutine(Player.Move.Dash());
        }

        public void ShowUi(InputAction.CallbackContext ctx)
        {
            Debug.Log(ctx.control.IsPressed());
            UiManager.Instance.SetActiveTabUi(ctx.control.IsPressed());
        }
        private void OnDisable()
        {
            DIsconnectController();
        }
    }
}
