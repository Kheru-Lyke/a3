using Com.KheruSEmporium.A3.A3.Cloaks;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    public class StagJump : Cloak
    {
		[SerializeField] protected float jumpStrenght = 5;

		public override void OnStag() {
			if (player.IsGrounded) player.Rigidbody.AddForce(new Vector2(0, jumpStrenght), ForceMode2D.Impulse);
		}
	}
}
