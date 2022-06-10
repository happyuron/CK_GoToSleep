using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;

namespace GoToSleep.Object
{
    public class Door : InteractiveObj
    {
        public float fadeSpeed;
        public Item key;
        private SpriteRenderer spriteRenderer;

        protected override void Init()
        {
            base.Init();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        protected override void StartInteraction()
        {
            if (UiManager.Instance.FindItemInInventory(key))
            {
                StartCoroutine(FadeOut());
                UiManager.Instance.RemoveItem(key);
            }
        }

        private IEnumerator FadeOut()
        {
            while (spriteRenderer.color.a > 0)
            {
                yield return null;
                spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a - Time.deltaTime * fadeSpeed);
            }

            gameObject.SetActive(false);
        }
    }
}
