using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class Item : TriggerObj<Player>
    {
        public ItemInfo info;

        private SpriteRenderer spriteRenderer;

        protected override void Init()
        {
            base.Init();
            spriteRenderer = GetComponent<SpriteRenderer>() ?? GetComponentInChildren<SpriteRenderer>();
        }

        protected override void CheckAreaStart(Collider2D other)
        {
            if (other != null)
            {
                Debug.Log("EE");
                other.GetComponent<Player>().GetItem(this);
                Destroy(gameObject);
            }
        }

        public Sprite GetItemSprite()
        {
            return spriteRenderer.sprite;
        }

    }
}
