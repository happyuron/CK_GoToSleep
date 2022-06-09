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
            var enemies = CheckBoxOverlap(WeaponInformation.AttackInfos, index);
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i].GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetDamaged(WeaponInformation.AttackInfos[index].Damage);
                }
            }
            index = index < attackCount - 1 ? index + 1 : 0;
        }

        public override void SkillAttack(int damage)
        {
            var enemies = CheckBoxOverlap(WeaponInformation.AttackInfos, 0);
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i].GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetDamaged(damage);
                }
            }
        }

        public override void UponAttack(ref int index)
        {
            var enemies = CheckBoxOverlap(WeaponInformation.UponAttackInfos, index);
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i].GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetDamaged(WeaponInformation.UponAttackInfos[index].Damage);
                }
            }
            index = index < attackCount - 1 ? index + 1 : 0;
        }

        public override void DownAttack(ref int index)
        {
            var enemies = CheckBoxOverlap(WeaponInformation.DownAttackInfos, index);
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemy = enemies[i].GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetDamaged(WeaponInformation.DownAttackInfos[index].Damage);
                }
            }
            index = index < attackCount - 1 ? index + 1 : 0;
        }

        protected virtual void OnDrawGizmos()
        {
            for (int i = 0; i < WeaponInformation.AttackInfos.Length; i++)
            {
                Gizmos.color = Color.white;
                Vector3 tmp = new Vector3(WeaponInformation.AttackInfos[i].Offset.x * GetFlip(), WeaponInformation.AttackInfos[i].Offset.y);
                Gizmos.DrawWireCube(transform.position + tmp, WeaponInformation.AttackInfos[i].Size);
            }
            for (int i = 0; i < WeaponInformation.DownAttackInfos.Length; i++)
            {
                Gizmos.color = Color.black;
                Vector3 tmp = new Vector3(WeaponInformation.DownAttackInfos[i].Offset.x * GetFlip(), WeaponInformation.DownAttackInfos[i].Offset.y);
                Gizmos.DrawWireCube(transform.position + tmp, WeaponInformation.DownAttackInfos[i].Size);
            }
            for (int i = 0; i < WeaponInformation.UponAttackInfos.Length; i++)
            {
                Gizmos.color = Color.blue;
                Vector3 tmp = new Vector3(WeaponInformation.UponAttackInfos[i].Offset.x * GetFlip(), WeaponInformation.UponAttackInfos[i].Offset.y);
                Gizmos.DrawWireCube(transform.position + tmp, WeaponInformation.UponAttackInfos[i].Size);
            }
        }

    }
}
