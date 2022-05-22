using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class PlayerMove : PlayerPart<Player>
    {
        public Vector3 offset;
        public Vector2 size;

        public LayerMask groundLayer;

        public LayerMask wallLayer;

        public int jumpCount;

        public float wallCheckDistance;

        private int curJumpCount;

        private float moveVelocityX;

        private float wallCheck;

        private float moveSpeed => Player.MoveSpeed;

        private float jumpStrength => Player.JumpStrength;

        private bool isJumping;

        private bool isMoving;

        private bool isClimbing;

        public void MoveRight(float valueX)
        {
            isMoving = valueX == 0 ? false : true;
            moveVelocityX = valueX;
            if (!isClimbing)
                wallCheck = moveVelocityX;
        }

        private bool CheckGround()
        {
            Collider2D result = Physics2D.OverlapBox(Tr.position + offset, size, 0, groundLayer);

            return result;
        }

        public void Jump()
        {
            if (curJumpCount < jumpCount)
            {
                StopAllCoroutines();
                wallCheck = moveVelocityX;
                wallCheck = CheckWall() ? 0 : moveVelocityX;
                isJumping = true;
                isClimbing = false;
                Rigid.gravityScale = 1;
                curJumpCount++;
                Rigid.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            }
        }

        private void FallingCheck()
        {
            if (isJumping)
            {
                if (CheckWall())
                {
                    isMoving = false;
                    isClimbing = true;
                    Rigid.gravityScale = 0;
                    StartCoroutine(ClimbingWhileSeconds(2));
                    Rigid.velocity = Vector2.zero;
                    isJumping = false;
                    curJumpCount--;
                }
                else if (CheckGround() && Rigid.velocity.y <= 0)
                {
                    isJumping = false;
                    curJumpCount = 0;
                }
            }
            else if ((!CheckWall() || CheckGround()) && isClimbing)
            {
                Debug.Log("GroundCheck");
                Rigid.gravityScale = 1;
                isClimbing = false;
                isJumping = false;
                curJumpCount = 0;
            }
        }
        private IEnumerator ClimbingWhileSeconds(float time)
        {
            yield return new WaitForSeconds(time);
            Rigid.gravityScale = .5f;
        }


        private RaycastHit2D CheckWall()
        {
            RaycastHit2D tmp = Physics2D.Raycast(Tr.position, new Vector2(wallCheck, 0).normalized, wallCheckDistance, wallLayer);
            return tmp;
        }

        private void Update()
        {
            if (!isClimbing)
                Rigid.velocity = new Vector2(moveVelocityX * moveSpeed, Rigid.velocity.y);
            FallingCheck();

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + offset, size);
            Gizmos.DrawLine(transform.position, transform.position + new Vector3(wallCheck, 0, 0).normalized * wallCheckDistance);
        }

    }
}
