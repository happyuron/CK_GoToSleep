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



        protected override void Init()
        {
            base.Init();
            playerControls = new PlayerInputAction();
            move = playerControls.Player.Move;
            attack = playerControls.Player.Fire;
            move.performed += Move;
            attack.performed += Attack;
        }

        private void OnEnable()
        {
            move.Enable();
        }

        private void Move(InputAction.CallbackContext ctx)
        {
            player.move.MoveRight(ctx.ReadValue<Vector2>().x);
        }
        public void Attack(InputAction.CallbackContext ctx)
        {
            Debug.Log("Move");
        }

        private void OnDisable()
        {
            move.Disable();
        }
        public void DebugLog()
        {
            Debug.Log("Hello");
        }
    }
}
