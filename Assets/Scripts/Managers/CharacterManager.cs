using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Object;

namespace GoToSleep.Manager
{
    public class CharacterManager : Singleton<CharacterManager>
    {
        public Player Player { get; private set; }

        protected override void Init()
        {
            base.Init();
            Player = FindObjectOfType<Player>();
        }


        public T GetPartType<T>() where T : PlayerPart<Player>
        {
            return Player.GetComponent<T>() ?? FindObjectOfType<T>() ?? Player.gameObject.AddComponent<T>();
        }

        public bool FindEnemy<T>() where T : Enemy
        {
            var tmp = FindObjectsOfType<T>();

            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i].state != EnemyState.Dead)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
