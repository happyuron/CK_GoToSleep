using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoToSleep.Object
{
    public class Player : Character
    {
        public PlayerMove Move { get; private set; }

        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float JumpStrength { get; private set; }



        protected override void Init()
        {
            base.Init();
            Move = GetComponent<PlayerMove>();
        }
    }

}
