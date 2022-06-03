using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class EnemyMove : MonoBehaviour
    {
        public Rigidbody2D Rigid { get; private set; }
        public Vector3 offset;
        public Vector2 size;
        public LayerMask groundLayer;
        public float speed;
        private int direction;
        private Transform Tr;

        private IEnumerator SetDirection()
        {
            yield return new WaitForSeconds(3);
            direction = Random.Range(-1, 2);
            StartCoroutine(SetDirection());
        }

        private bool CheckGround()
        {
            Collider2D result = Physics2D.OverlapBox(Tr.position + offset, size, 0, groundLayer);

            return result;
        }


        private void Awake()
        {
            Rigid = GetComponent<Rigidbody2D>();
            Tr = GetComponent<Transform>();
        }

        private void Start()
        {
            StartCoroutine(SetDirection());
        }
        private void FixedUpdate()
        {
            if (CheckGround())
                direction *= -1;
            Rigid.velocity = new Vector2(direction * speed, Rigid.velocity.y);


        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + offset, size);
        }

    }
}
