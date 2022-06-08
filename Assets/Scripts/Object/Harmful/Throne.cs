using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class Throne : TriggerObj<Player>
    {
        private bool isChecked;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Player>())
            {
                target.GetDamaged(1);
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        protected override void CheckAreaStart(Collider2D other)
        {
            gameObject.layer = LayerMask.NameToLayer("Enemy");
            isChecked = true;

        }


        private void Update()
        {
            if (isChecked)
                Tr.position += Vector3.down * Time.deltaTime * 10;
        }

    }
}
