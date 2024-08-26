using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "A3/Settings")]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private float movementSpeed = 1.0f;
		[SerializeField] private float jumpGraceTime = 0.3f;
		[SerializeField] private float airSpeed = 8;

		public float MovementSpeed => movementSpeed;

		public float JumpGraceTime => jumpGraceTime;

		public float AirSpeed => airSpeed;
	}
}
