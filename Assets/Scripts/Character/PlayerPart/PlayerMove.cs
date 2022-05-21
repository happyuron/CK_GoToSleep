using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class PlayerMove : PlayerPart<PlayerMove>
    {
        public Vector3 offset;
        public Vector2 size;

        public LayerMask hitLayer;
        private float moveVelocityX;

        private float moveSpeed => Player.MoveSpeed;

        private float jumpStrength => Player.JumpStrength;

        private bool isJumping;
        private bool isMoving;


        public void MoveRight(float valueX)
        {
            moveVelocityX = valueX;
        }

        private bool CheckGround()
        {
            Collider2D result = Physics2D.OverlapBox(Tr.position + offset, size, 0, hitLayer);

            return result;
        }

        public void Jump()
        {
            if (!isJumping)
            {
                Rigid.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
                isJumping = true;
            }
        }

        public void FallingCheck()
        {
            if (isJumping && Rigid.velocity.y <= 0)
            {
                if (CheckGround())
                {
                    isJumping = false;
                }
            }
        }

        private void Update()
        {
            Rigid.velocity = new Vector2(moveVelocityX * moveSpeed, Rigid.velocity.y);
            FallingCheck();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + offset, size);
        }

    }
}
