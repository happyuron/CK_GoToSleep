using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoToSleep.Object
{
    public class Player : Character
    {
        public PlayerMove move;

        protected override void Init()
        {
            base.Init();
            move = GetComponent<PlayerMove>();
        }
    }

}
