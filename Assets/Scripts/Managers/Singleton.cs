using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoToSleep.Manager
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance;

        protected virtual void Awake()
        {
            if (Instance == null)
            {

            }
        }

    }

}
