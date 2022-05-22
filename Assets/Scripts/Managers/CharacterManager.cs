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
    }
}
