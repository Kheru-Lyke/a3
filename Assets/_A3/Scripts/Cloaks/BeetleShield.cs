using Com.KheruSEmporium.A3.A3.Cloaks;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
	public class BeetleShield : Cloak {
		[SerializeField] private float invincibleTime = 0.5f;

		public override void OnBeetle() {
			player.SetInvincible(invincibleTime);

			StartCountdown();
		}
	}
}
