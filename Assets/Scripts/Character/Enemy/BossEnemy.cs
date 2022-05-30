using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;


namespace GoToSleep.Object
{
    public class BossEnemy : Enemy
    {

        private void Start()
        {
            GameManager.Instance.SetGoalEnemy(this);

        }
    }
}
