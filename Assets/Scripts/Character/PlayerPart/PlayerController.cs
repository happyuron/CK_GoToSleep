using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace GoToSleep.Object
{
    public class PlayerController : PlayerPart<PlayerController>
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
            move.Enable();
            jump.Enable();
            attack.Enable();
        }

        private void Move(InputAction.CallbackContext ctx)
        {
            Player.Move.MoveRight(ctx.ReadValue<Vector2>().x);
        }
        public void Attack(InputAction.CallbackContext ctx)
        {
        }
        public void Jump(InputAction.CallbackContext ctx)
        {
            Debug.Log("Jump");
            Player.Move.Jump();
        }

        private void OnDisable()
        {
            attack.Disable();
            move.Disable();
            jump.Disable();
        }
    }
}
