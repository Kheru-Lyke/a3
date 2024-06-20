using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
	[RequireComponent(typeof(Rigidbody2D))]
    public class Moving : MonoBehaviour
    {
        protected Vector2 velocity;
		protected Rigidbody2D rigidBody;

		protected Vector3 facingDirection = Vector2.zero;
		protected Vector3 horizontalFacingDirection = Vector2.right;

		public Vector3 Facing => facingDirection;
		public Vector3 HorizontalFacing => horizontalFacingDirection;

		public Rigidbody2D Rigidbody => rigidBody;
		[SerializeField] private float checkGroundDistance;
		private bool isGrounded = false;
		public bool IsGrounded => isGrounded;

		protected virtual void Move() {
			rigidBody.velocity = velocity;

			if (velocity!= Vector2.zero) {
				facingDirection = velocity.normalized;

				if (Mathf.Abs(velocity.x) >= 0.2f) {
					horizontalFacingDirection = velocity.normalized;
					horizontalFacingDirection.y = 0f;
				}
			}

			Debug.DrawRay(transform.position, Vector2.down * checkGroundDistance, Color.red);
			Transform hit = Physics2D.Raycast(transform.position, Vector2.down, checkGroundDistance, ~(1 << 3)).transform;
			isGrounded = hit;
		}
	}
}
