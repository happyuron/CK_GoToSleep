using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    [System.Serializable]
    public struct AutoMove
    {
        public bool end;
        public Transform moveTo;
        public float waitTime;
        public PlayerState state;
        public string animName;
        public float animState;
        public PlayerState endState;
        public string endAnimName;
        public float endAnimState;
    }
    public class PlayerAutoMove : MonoBehaviour
    {
        public float moveSpeed;
        public AutoMove[] moves;



        private int index;

        private void Start()
        {
            StartCoroutine(MoveTo());
        }

        private IEnumerator MoveTo()
        {
            while (true)
            {
                if (index >= moves.Length)
                    break;
                yield return new WaitForSeconds(moves[index].waitTime);
                PlayerAnimation.PlayerAnimInteger("State", (int)moves[index].state);
                PlayerAnimation.PlayerAnimFloat(moves[index].animName, moves[index].animState);
                if (moves[index].moveTo != null)
                {
                    while (Vector3.Distance(transform.position, moves[index].moveTo.position) > 0.5f)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, moves[index].moveTo.position, moveSpeed * Time.deltaTime);
                        yield return null;
                    }

                }
                if (moves[index].end)
                {
                    PlayerAnimation.PlayerAnimInteger("State", (int)moves[index].endState);
                    PlayerAnimation.PlayerAnimFloat(moves[index].endAnimName, moves[index].endAnimState);
                }
                index++;
            }
        }


    }
}
