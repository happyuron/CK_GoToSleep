using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoToSleep.Manager;

namespace GoToSleep.Object
{
    public class MainCamera : ObjectCamera<Player>
    {
        protected override void Start()
        {
            base.Start();
            target = CharacterManager.Instance.Player;
        }
    }
}
