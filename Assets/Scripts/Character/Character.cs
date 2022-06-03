using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class Character : EveryObj
    {
        [SerializeField] private int hp;

        [SerializeField] private float invincibleTime;

        public bool IsInvincible { get; private set; }
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
            if (IsInvincible)
                return;
            hp -= damage;
            StartCoroutine(DamagedCoroutine());
            if (hp <= 0)
                CharacterDead();
        }

        private IEnumerator DamagedCoroutine()
        {
            IsInvincible = true;

            // 캐릭터가 공격당할시 깜빡거리는 효과
            float time = 0;
            float start = 1;
            float end = 0;
            Color fadeColor = spriteRenderer.color;
            int count = 0;
            while (count < 2)
            {
                yield return null;
                time += Time.deltaTime / (invincibleTime / 2);
                fadeColor.g = Mathf.Lerp(start, end, time);
                fadeColor.b = Mathf.Lerp(start, end, time);
                spriteRenderer.color = fadeColor;
                if (spriteRenderer.color.g == end && spriteRenderer.color.b == end)
                {
                    start += end;
                    end = start - end;
                    start -= end;
                    time = 0;
                    count++;
                }
            }

            IsInvincible = false;
        }

        public virtual void CharacterDead()
        {

        }
    }
}
