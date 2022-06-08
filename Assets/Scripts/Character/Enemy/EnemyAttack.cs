using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class EnemyAttack : MonoBehaviour
    {
        public bool IsAttacking;
        public float attackCoolTime;
        [SerializeField] private BoxTrigger attackRange;
        public bool canAttack;
        private Transform Tr;
        private Enemy enemy;

        private void Awake()
        {
            enemy = GetComponent<Enemy>();
            Tr = GetComponent<Transform>();
            canAttack = true;
        }

        public Player CheckAttackRange()
        {
            int direction = enemy.spriteRenderer.flipX ? -1 : 1;
            Collider2D other = Physics2D.OverlapBox((Tr.position + new Vector3(direction * attackRange.offset.x, attackRange.offset.y)), attackRange.size, 0, attackRange.checkLayer);
            Player tmp = null;
            if (other.GetComponent<Player>())
            {
                tmp = other.GetComponent<Player>();
                if (tmp.IsDead())
                    tmp = null;
            }

            return tmp;
        }

        public void StartCoolTimeCoroutine()
        {
            StartCoroutine(StartCoolTime());
        }

        private IEnumerator StartCoolTime()
        {
            enemy.Anim.SetInteger("State", (int)EnemyState.Move);
            yield return new WaitForSeconds(attackCoolTime);
            canAttack = true;

        }
        private void FixedUpdate()
        {
            if (!enemy.IsDead)
                if (CheckAttackRange() && canAttack)
                {
                    canAttack = false;
                    IsAttacking = true;
                    enemy.Anim.SetInteger("State", (int)EnemyState.Attack);
                }
        }


        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube((transform.position + new Vector3(attackRange.offset.x, attackRange.offset.y)), attackRange.size);
        }


    }
}
