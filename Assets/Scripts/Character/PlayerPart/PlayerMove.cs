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

        public bool IsJumping { get; private set; }

        public bool IsMoving { get; private set; }

        public bool IsClimbing { get; private set; }
        private int curJumpCount;

        private float moveVelocityX;

        private float wallCheck;

        private float moveSpeed => Player.MoveSpeed;

        private float speed;

        private float jumpStrength => Player.JumpStrength;

        private float runSpeed => Player.RunSpeed;


        public void MoveRight(float valueX)
        {
            speed = moveSpeed;
            IsMoving = valueX == 0 ? false : true;
            if (valueX > 0)
                Player.spriteRenderer.flipX = false;
            else if (valueX < 0)
                Player.spriteRenderer.flipX = true;
            moveVelocityX = valueX;
            if (!IsClimbing)
                wallCheck = moveVelocityX;
        }

        public void Run(bool value)
        {
            if (IsMoving && !IsJumping)
            {
                PlayerAnimation.PlayerAnimInteger("State", (int)PlayerState.Normal);
                PlayerAnimation.PlayerAnimInteger("Blend Normal", 3);
                speed = value ? runSpeed : moveSpeed;
            }
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
                IsJumping = true;
                IsClimbing = false;
                Rigid.gravityScale = 1;
                curJumpCount++;
                Rigid.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            }
        }

        private void FallingCheck()
        {
            if (IsJumping)
            {
                if (CheckWall())
                {
                    IsMoving = false;
                    IsClimbing = true;
                    Rigid.gravityScale = 0;
                    StartCoroutine(ClimbingWhileSeconds(2));
                    Rigid.velocity = Vector2.zero;
                    IsJumping = false;
                    curJumpCount--;
                }
                else if (CheckGround() && Rigid.velocity.y <= 0)
                {
                    IsJumping = false;
                    curJumpCount = 0;
                }
            }
            else if ((!CheckWall() || CheckGround()) && IsClimbing)
            {
                Debug.Log("GroundCheck");
                Rigid.gravityScale = 1;
                IsClimbing = false;
                IsJumping = false;
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
            if (!IsClimbing)
                Rigid.velocity = new Vector2(moveVelocityX * speed, Rigid.velocity.y);
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
