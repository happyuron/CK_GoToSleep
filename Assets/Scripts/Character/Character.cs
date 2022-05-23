using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Object;

namespace GoToSleep
{
    public class Character : EveryObj
    {
        [field: SerializeField] public int Hp { get; private set; }
        public SpriteRenderer spriteRenderer;


        protected override void Init()
        {
            base.Init();
            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void GetDamaged(int damage)
        {
            Debug.Log("the object got the" + damage + "damages");
        }
    }
}
