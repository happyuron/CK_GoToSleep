using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Object;

namespace GoToSleep.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        Enemy goal;


        protected override void Awake()
        {
            base.Awake();

        }

    }
}
