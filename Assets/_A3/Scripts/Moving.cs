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


		[SerializeField] private LayerMask ignoreLayers = default;

		[SerializeField] private float baseGravity = 5;
		[SerializeField] private float gravityAugment = 0.3f;
		[SerializeField] private float maxGravity = 10;

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

			CheckGround();
			AccelerateDown();
		}

		protected virtual void CheckGround() {
			Debug.DrawRay(transform.position, Vector2.down * checkGroundDistance, Color.red);
			Transform hit = Physics2D.Raycast(transform.position, Vector2.down, checkGroundDistance, ~(ignoreLayers)).transform;
			isGrounded = hit;

		}

		private void AccelerateDown() {
			if (isGrounded || rigidBody.velocity.y >= 0) rigidBody.gravityScale = baseGravity;
			else {
				if (rigidBody.gravityScale >= maxGravity) rigidBody.gravityScale = maxGravity;
				else rigidBody.gravityScale += gravityAugment * Time.fixedTime;
			}
		}
	}
}
