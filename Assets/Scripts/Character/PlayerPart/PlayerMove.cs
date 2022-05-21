using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class PlayerMove : PlayerPart<PlayerMove>
    {
        private float moveVelocityX;


        public void MoveRight(float valueX)
        {
            moveVelocityX = valueX;
        }

        private void Update()
        {
            Rigid.velocity = new Vector2(moveVelocityX, Rigid.velocity.y);
        }

    }
}
