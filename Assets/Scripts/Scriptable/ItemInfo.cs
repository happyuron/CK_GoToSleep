using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoToSleep.Object
{

    [CreateAssetMenu(fileName = "Item", menuName = "Object/Item")]
    public class ItemInfo : ScriptableObject
    {
        [field: SerializeField] public int ItemIndex { get; private set; }

        [field: SerializeField] public string ItemName { get; private set; }

        [field: SerializeField] public string Description { get; private set; }

    }
}
