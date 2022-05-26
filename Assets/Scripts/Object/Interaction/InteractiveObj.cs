using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class InteractiveObj : TriggerObj<Player>
    {

        protected override void Init()
        {
            base.Init();
            target = FindObjectOfType<Player>();
        }

        protected override void CheckAreaStart(Collider2D other)
        {
            if (other != null)
            {
                Debug.Log("Update");
                target.interactiveObj = this;
            }
        }
        protected override void CheckAreaExit(Collider2D other)
        {
            if (target.interactiveObj == this)
            {
                Debug.Log("Distroy");
                target.interactiveObj = null;
            }
        }

        public void Interacte()
        {
            StartInteraction();
        }

        protected virtual void StartInteraction()
        {

        }

    }
}
