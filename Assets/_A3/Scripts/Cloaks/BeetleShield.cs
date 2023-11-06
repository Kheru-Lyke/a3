using Com.KheruSEmporium.A3.A3.Cloaks;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
	public class BeetleShield : Cloak {
		[SerializeField] private GameObject shield = null;

		public override void OnBeetle() {
			Instantiate(shield, player.transform);

			StartCountdown();
		}
	}
}
