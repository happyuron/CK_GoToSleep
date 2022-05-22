using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{
    public class PlayerAttack : PlayerPart<Player>
    {
        public WeaponInfo weapon;

        [field: SerializeField] public SpriteRenderer Renderer { get; private set; }


        public void WeaponUpdate()
        {
            
        }
    }
}
