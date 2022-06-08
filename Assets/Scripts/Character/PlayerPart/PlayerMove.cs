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


        [field: SerializeField] public bool IsJumping { get; private set; }

        public bool IsMoving { get; private set; }

        public bool IsClimbing { get; private set; }

        public float moveVelocityX;

        private int curJumpCount;

        private float wallCheck;

        private float moveSpeed => Player.MoveSpeed;

        public float speed;

        private float jumpStrength => Player.JumpStrength;

        private float runSpeed => Player.RunSpeed;

        private void Start()
        {
            speed = moveSpeed;
        }

        public void MoveRight(float valueX)
        {
            if (valueX == 0)
            {
                speed = moveSpeed;
                PlayerAnimation.PlayerAnimFloat("Blend Normal", 0);
            }
            else if (valueX > 0)
            {
                Player.spriteRenderer.flipX = false;
                PlayerAnimation.PlayerAnimFloat("Blend Normal", 1);
            }
            else if (valueX < 0)
            {
                Player.spriteRenderer.flipX = true;
                PlayerAnimation.PlayerAnimFloat("Blend Normal", 1);
            }
            IsMoving = valueX == 0 ? false : true;
            moveVelocityX = valueX;
            if (!IsClimbing)
                wallCheck = moveVelocityX;
        }

        public void Run()
        {
            if (!IsJumping && !IsClimbing)
            {
                PlayerAnimation.PlayerAnimInteger("State", (int)PlayerState.Normal);
                PlayerAnimation.PlayerAnimFloat("Blend Normal", 3);
                speed = runSpeed;
            }
        }

        public IEnumerator Dash()
        {
            float direction = Player.spriteRenderer.flipX ? -3 : 3;
            RaycastHit2D target = Physics2D.Raycast(Tr.position, new Vector2(direction, 0).normalized, 3, wallLayer);
            if (target)
            {
                Debug.Log(target.point);
                direction = target.point.x;
            }
            else
            {
                direction = Tr.position.x + direction;
            }
            while (Mathf.Abs(direction - Tr.position.x) > 0.1f)
            {
                yield return null;
                Tr.position = Vector2.MoveTowards(Tr.position, new Vector2(direction, Tr.position.y), 10 * Time.deltaTime);
            }
            Rigid.velocity = Vector2.zero;
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
                PlayerAnimation.PlayerAnimInteger("State", (int)PlayerState.Jump);
                PlayerAnimation.PlayerAnimFloat("Blend Jump", 0);

                StopAllCoroutines();
                wallCheck = moveVelocityX;
                wallCheck = CheckWall() ? 0 : moveVelocityX;
                IsJumping = true;
                IsClimbing = false;
                Rigid.gravityScale = Player.DefaultGravity;
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
                    PlayerAnimation.PlayerAnimInteger("State", (int)PlayerState.Normal);
                    IsJumping = false;
                    curJumpCount = 0;
                }
            }
            else if ((!CheckWall() || CheckGround()) && IsClimbing)
            {
                Debug.Log("GroundCheck");
                Rigid.gravityScale = Player.DefaultGravity;
                IsClimbing = false;
                IsJumping = false;
                curJumpCount = 0;
            }
        }
        private IEnumerator ClimbingWhileSeconds(float time)
        {
            yield return new WaitForSeconds(time);
            Rigid.gravityScale = 0.5f;
        }


        private RaycastHit2D CheckWall()
        {
            RaycastHit2D tmp = Physics2D.Raycast(Tr.position, new Vector2(wallCheck, 0).normalized, wallCheckDistance, wallLayer);
            return tmp;
        }

        private void FixedUpdate()
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
