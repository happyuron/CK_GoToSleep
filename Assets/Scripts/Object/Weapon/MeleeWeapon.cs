using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    interface IMeleeAttack : IAttackType<Weapon>
    {
        public Collider2D[] CheckBoxOverlap(BoxTrigger trigger);
    }
    public class MeleeWeapon : Weapon, IMeleeAttack
    {
        public BoxTrigger horizontalTrigger;

        public BoxTrigger upsideTrigger;
        public Collider2D[] CheckBoxOverlap(BoxTrigger trigger)
        {
            Vector3 tmp = new Vector3(trigger.Offset.x * Player.GetFlip(), trigger.Offset.y);
            Collider2D[] collider2D = Physics2D.OverlapBoxAll(transform.position + tmp, trigger.Size, 0, trigger.HitLayer);
            return collider2D;
        }


        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 tmp = new Vector3(horizontalTrigger.Offset.x * Player.GetFlip(), horizontalTrigger.Offset.y);
            Gizmos.DrawWireCube(transform.position + tmp, horizontalTrigger.Size);
            tmp = new Vector3(upsideTrigger.Offset.x * Player.GetFlip(), upsideTrigger.Offset.y);
            Gizmos.DrawWireCube(transform.position + tmp, upsideTrigger.Size);
        }

    }
}
