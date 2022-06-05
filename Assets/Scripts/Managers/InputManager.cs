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
            base.Awake();
            inputActions = new PlayerInputAction();
            back = inputActions.System.Back;

            back.performed += Back;
            action += SetupPopup;
        }

        private void OnEnable()
        {
            back.Enable();
        }

        public void Back(InputAction.CallbackContext ctx)
        {
            StartCoroutine(action());
        }


        public IEnumerator SetupSetting()
        {
            UiManager.Instance.SettingUiActive(true);
            action += HideSetting;
            yield return null;
        }
        public IEnumerator HideSetting()
        {
            UiManager.Instance.SettingUiActive(false);
            action -= HideSetting;
            yield return null;
        }
        public IEnumerator SetupPopup()
        {
            UiManager.Instance.PopUpUiActive(true);
            action += HidePopup;
            yield return null;
        }
        public IEnumerator HidePopup()
        {
            UiManager.Instance.PopUpUiActive(false);
            action -= HidePopup;
            yield return null;
        }
        public void AddCloseSystem()
        {
            action -= HideSetting;
        }
    }
}
