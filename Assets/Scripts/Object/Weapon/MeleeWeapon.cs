using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    interface IMeleeAttack : IAttackType<Weapon>
    {
        public Collider2D[] CheckBoxOverlap(AttackInfo[] trigger, int index);
    }
    public class MeleeWeapon : Weapon, IMeleeAttack
    {
        public SpriteRenderer gizmosRenderer;

        public int GetFlip()
        {
            return gizmosRenderer.flipX ? -1 : 1;
        }

        public Collider2D[] CheckBoxOverlap(AttackInfo[] trigger, int index)
        {
            Vector3 tmp = new Vector3(trigger[index].Offset.x * GetFlip(), trigger[index].Offset.y);
            Collider2D[] collider2D = Physics2D.OverlapBoxAll(transform.position + tmp, trigger[index].Size, 0, hitLayer);
            return collider2D;
        }

        public override void Attack(ref int index)
        {
            var enemies = CheckBoxOverlap(WeaponInformation.attackInfos, index);
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i].GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetDamaged(WeaponInformation.attackInfos[index].Damage);
                }
            }
            index = index < attackCount - 1 ? index + 1 : 0;
        }

        public override void UponAttack(ref int index)
        {

        }

        public override void DownAttack(ref int index)
        {

        }

        protected virtual void OnDrawGizmos()
        {
            for (int i = 0; i < WeaponInformation.attackInfos.Length; i++)
            {
                Gizmos.color = Color.white;
                Vector3 tmp = new Vector3(WeaponInformation.attackInfos[i].Offset.x * GetFlip(), WeaponInformation.attackInfos[i].Offset.y);
                Gizmos.DrawWireCube(transform.position + tmp, WeaponInformation.attackInfos[i].Size);
            }
            for (int i = 0; i < WeaponInformation.downAttackInfos.Length; i++)
            {
                Gizmos.color = Color.black;
                Vector3 tmp = new Vector3(WeaponInformation.downAttackInfos[i].Offset.x * GetFlip(), WeaponInformation.downAttackInfos[i].Offset.y);
                Gizmos.DrawWireCube(transform.position + tmp, WeaponInformation.downAttackInfos[i].Size);
            }
            for (int i = 0; i < WeaponInformation.uponAttackInfos.Length; i++)
            {
                Gizmos.color = Color.blue;
                Vector3 tmp = new Vector3(WeaponInformation.uponAttackInfos[i].Offset.x * GetFlip(), WeaponInformation.uponAttackInfos[i].Offset.y);
                Gizmos.DrawWireCube(transform.position + tmp, WeaponInformation.uponAttackInfos[i].Size);
            }
        }

    }
}
