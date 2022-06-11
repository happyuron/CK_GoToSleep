using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class Throne : TriggerObj<Player>
    {
        private bool isChecked;

        public BoxTrigger trigger;

        protected override void CheckAreaStart(Collider2D other)
        {
            gameObject.layer = LayerMask.NameToLayer("Enemy");
            isChecked = true;

        }

        private void CheckObjects()
        {
            var tmp = Physics2D.OverlapBox(trigger.offset + Tr.position, trigger.size, 0, trigger.checkLayer);
            if (tmp != null)
            {
                if (tmp.gameObject.GetComponent<Player>())
                    tmp.gameObject.GetComponent<Player>().GetDamaged(1);
                gameObject.SetActive(false);
            }

        }

        private void Update()
        {
            if (isChecked)
            {
                Tr.position += Vector3.down * Time.deltaTime * 10;
                CheckObjects();
            }
        }


        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + trigger.offset, trigger.size);
        }
    }
}
