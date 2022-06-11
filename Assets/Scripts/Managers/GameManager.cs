using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Object;

namespace GoToSleep.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private BossEnemy goal;

        public void SetGoalEnemy(BossEnemy boss)
        {
            if (goal == null)
            {
                goal = boss;
            }
            else
            {
                goal = goal.GetEnemyIndex() <= boss.GetEnemyIndex() ? goal : boss;
            }
            UiManager.Instance.AddText(boss.GetEnemyIndex(), boss.GetEnemyDescription());
            UiManager.Instance.SetDescription(goal.GetEnemyIndex(), goal.GetEnemyDescription());
        }
        public void GameClear()
        {
            UiManager.Instance.SetGameClearUi(true);
        }

        public void QuitGame()
        {
            Application.Quit();
        }


        private void OnApplicationQuit()
        {

        }
    }
}
