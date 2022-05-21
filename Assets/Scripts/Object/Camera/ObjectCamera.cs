using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Action();

namespace GoToSleep.Object
{
    public class ObjectCamera<T> : MonoBehaviour where T : MonoBehaviour
    {
        private float curPosZ;
        protected Action action;
        [field: SerializeField] public T target { get; protected set; }
        public Transform Tr { get; private set; }
        public bool lerp;
        public float defaultPosZ;
        public float lerpSpeed;

        protected virtual void Awake()
        {
            Init();
        }

        protected virtual void Start()
        {
            curPosZ = defaultPosZ;
            action = lerp ? MoveToTargetLerp : MoveToTarget;
        }

        protected virtual void Init()
        {
            Tr = GetComponent<Transform>();
        }

        public void ExchangeType(bool isLerp, float speed = 3)
        {
            action = isLerp ? MoveToTargetLerp : MoveToTarget;
            lerpSpeed = speed;
        }


        private void MoveToTarget()
        {
            Tr.position = new Vector3(target.transform.position.x, target.transform.position.y, curPosZ);
        }

        private void MoveToTargetLerp()
        {
            Tr.position = Vector3.Lerp(Tr.position, new Vector3(target.transform.position.x, target.transform.position.y, curPosZ), lerpSpeed * Time.deltaTime);
        }

        private void LateUpdate()
        {
            action();
        }

    }
}
