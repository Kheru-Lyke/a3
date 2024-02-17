using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3.Common.DRig {
    public class Bone2D : MonoBehaviour
    {
		[SerializeField] static protected float boneWidth = 0.03f;

		private void OnDrawGizmos() {
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position + transform.right * boneWidth, transform.parent.position);
			Gizmos.DrawLine(transform.position + transform.right * -boneWidth, transform.parent.position);

			Gizmos.DrawIcon(transform.position, "Bone.jpg", false);
		}
	}
}
