using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class TriggerObj<T> : EveryObj where T : MonoBehaviour
    {
        [SerializeField] private Transform childrenTr;
        [SerializeField] private Vector2 size;
        [SerializeField] private LayerMask hitLayer;

        public T target;

        private bool isOnce;

        protected override void Awake()
        {
            base.Awake();
            target = FindObjectOfType<T>();
        }

        private void CheckArea()
        {
            var obj = Physics2D.OverlapBox(childrenTr.position, size, 0, hitLayer);
            if (obj != null && !isOnce)
            {
                isOnce = true;
                CheckAreaStart(obj);
            }
            else if (obj != null && isOnce)
            {
                CheckAreaStay(obj);
            }
            else if (obj == null && isOnce)
            {
                isOnce = false;
                CheckAreaExit(obj);
            }
        }

        protected virtual void CheckAreaStart(Collider2D other)
        {

        }
        protected virtual void CheckAreaStay(Collider2D other)
        {

        }
        protected virtual void CheckAreaExit(Collider2D other)
        {

        }

        protected virtual void FixedUpdate()
        {
            CheckArea();
        }
        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(childrenTr.position, size);
        }

    }
}
