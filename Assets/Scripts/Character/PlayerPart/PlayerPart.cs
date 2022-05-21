using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class PlayerPart<T> : MonoBehaviour where T : PlayerPart<T>
    {
        [HideInInspector] public Player player;

        public Rigidbody2D Rigid { get; protected set; }

        protected virtual void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            player = GetComponent<Player>();
            Rigid = GetComponent<Rigidbody2D>();
            if (player == null)
            {
                player = FindObjectOfType<Player>();
            }
        }
    }
}
