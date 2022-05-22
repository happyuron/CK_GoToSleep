using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoToSleep.Object
{
    [Serializable]
    public class BoxTrigger
    {
        [field: SerializeField] public Vector3 Offset { get; private set; }

        [field: SerializeField] public Vector2 Size { get; private set; }

        [field: SerializeField] public LayerMask HitLayer { get; private set; }
    }
}
