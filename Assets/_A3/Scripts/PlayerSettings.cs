using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "A3/Settings")]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private float movementSpeed = 1.0f;

        public float MovementSpeed => movementSpeed;
    }
}
