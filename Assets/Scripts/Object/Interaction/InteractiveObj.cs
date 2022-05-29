using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class InteractiveObj : TriggerObj<Player>
    {

        protected override void CheckAreaStart(Collider2D other)
        {
            if (other != null)
            {
                target.interactiveObj = this;
            }
        }
        protected override void CheckAreaExit(Collider2D other)
        {
            if (target.interactiveObj == this)
            {
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
