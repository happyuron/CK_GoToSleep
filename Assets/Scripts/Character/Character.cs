using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Object;

namespace GoToSleep
{
    public class Character : EveryObj
    {
        public SpriteRenderer spriteRenderer;


        protected override void Init()
        {
            base.Init();
            if (spriteRenderer == null)
                spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }
}
