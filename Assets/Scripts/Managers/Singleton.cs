using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoToSleep.Manager
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance;

        public bool dontDestroyOnLoad;

        protected virtual void Awake()
        {
            Init();
            if (FindObjectsOfType<T>().Length > 1)
                Destroy(gameObject);

            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }

        }

        protected virtual void Init()
        {
            if (Instance == null)
            {
                Instance = gameObject.GetComponent<T>();
            }

        }

    }

}
