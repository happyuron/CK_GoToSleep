using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoToSleep.Object
{
    public class EveryObj : MonoBehaviour
    {
        public Transform Tr { get; set; }

        protected virtual void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            Tr = GetComponent<Transform>();
        }



    }

}
