using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class Item : EveryObj
    {
        public ItemInfo info;

        private SpriteRenderer spriteRenderer;

        protected override void Init()
        {
            base.Init();
            spriteRenderer = GetComponent<SpriteRenderer>() ?? GetComponentInChildren<SpriteRenderer>();
        }


    }
}
