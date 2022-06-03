using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;

namespace GoToSleep.Object
{
    [System.Serializable]
    public class BoxTrigger
    {
        public Vector3 offset;
        public Vector2 size;
        public LayerMask checkLayer;
    }
    public class EnemyMove : TriggerObj<Player>
    {
        public Rigidbody2D Rigid { get; private set; }

        public BoxTrigger groundTrigger;


        public Enemy enemy;

        public Player player;


        public float speed;

        public bool detectOn;
        private int direction;

        private IEnumerator SetDirection()
        {
            yield return new WaitForSeconds(3);
            direction = Random.Range(-1, 2);
            enemy.spriteRenderer.flipX = direction > 0 ? true : direction < 0 ? false : enemy.spriteRenderer.flipX;
            StartCoroutine(SetDirection());
        }

        private bool CheckGround()
        {
            Collider2D result = Physics2D.OverlapBox(Tr.position + groundTrigger.offset, groundTrigger.size, 0, groundTrigger.checkLayer);

            return result;
        }

        protected override void CheckAreaStart(Collider2D other)
        {
            detectOn = true;
            StopAllCoroutines();
        }

        protected override void CheckAreaExit(Collider2D other)
        {
            detectOn = false;
            StartCoroutine(SetDirection());
        }

        protected override void Awake()
        {
            base.Awake();
            Rigid = GetComponent<Rigidbody2D>();
            enemy = GetComponent<Enemy>();
        }

        private void Start()
        {
            player = CharacterManager.Instance.Player;
            StartCoroutine(SetDirection());

        }
        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            if (CheckGround())
                direction *= -1;
            if (!detectOn)
                Rigid.velocity = new Vector2(direction * speed, Rigid.velocity.y);
            else
            {
                direction = Tr.position.x > player.Tr.position.x ? -1 : 1;
                Rigid.velocity = new Vector2(direction * speed, Rigid.velocity.y);
            }
        }

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            Gizmos.color = Color.red;

            Gizmos.DrawWireCube(transform.position + groundTrigger.offset, groundTrigger.size);
        }

    }
}
