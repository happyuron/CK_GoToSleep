using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace GoToSleep.Manager
{

    public class InputManager : Singleton<InputManager>
    {
        private PlayerInputAction inputActions;
        private InputAction back;

        public delegate IEnumerator Action();

        public Action action;

        protected override void Awake()
        {
            inputActions = new PlayerInputAction();
            back = inputActions.System.Back;

            back.performed += Back;
            action += Setup;
        }

        private void OnEnable()
        {
            back.Enable();
        }

        public void Back(InputAction.CallbackContext ctx)
        {
            StartCoroutine(action());
        }


        private IEnumerator Setup()
        {
            UiManager.Instance.ShowSettingUi();
            yield return null;
        }
    }
}
