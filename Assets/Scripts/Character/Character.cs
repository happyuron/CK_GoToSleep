using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class Character : EveryObj
    {
        [SerializeField] private int hp;
        public int Hp
        {
            get
            {
                return hp;
            }
            private set
            {
                if (value < 0)
                    GetDamaged(value);
            }
        }
        public SpriteRenderer spriteRenderer;

        public Rigidbody2D Rigid { get; private set; }

        protected override void Init()
        {
            base.Init();
            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            Rigid = GetComponent<Rigidbody2D>();
        }

        public virtual void GetDamaged(int damage)
        {
            Debug.Log("the object got the" + damage + "damages");
            hp -= damage;
            if (hp <= 0)
                CharacterDead();
        }

        public virtual void CharacterDead()
        {

        }
    }
}
