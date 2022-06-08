using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;

namespace GoToSleep.Object
{
    public class Door : InteractiveObj
    {
        public Item key;
        private Collider2D box;

        protected override void Awake()
        {
            base.Awake();
        }
        protected override void Init()
        {
            base.Init();
            box = GetComponent<Collider2D>();
        }
        protected override void StartInteraction()
        {
            if (UiManager.Instance.FindItemInInventory(key))
            {
                box.enabled = false;
            }
        }
    }
}
