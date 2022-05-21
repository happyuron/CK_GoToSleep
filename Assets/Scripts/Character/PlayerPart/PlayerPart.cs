using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class PlayerPart<T> : MonoBehaviour where T : PlayerPart<T>
    {
        public Player Player { get; private set; }

        public Transform Tr { get; private set; }

        public Rigidbody2D Rigid { get; protected set; }

        protected virtual void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            Player = GetComponent<Player>();
            Rigid = GetComponent<Rigidbody2D>();
            Tr = GetComponent<Transform>();
            if (Player == null)
            {
                Player = FindObjectOfType<Player>();
            }
        }
    }
}
