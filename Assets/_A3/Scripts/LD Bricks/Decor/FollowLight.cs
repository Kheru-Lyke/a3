using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
    public class FollowLight : MonoBehaviour
    {
		[SerializeField] private Transform target = null;

		private void Update() {
			if (target != null) transform.LookAt(target);
		}
	}
}
