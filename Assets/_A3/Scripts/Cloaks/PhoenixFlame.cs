using Com.KheruSEmporium.A3.A3.Cloaks;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    public class PhoenixFlame : Cloak
    {
		[SerializeField] private GameObject flameAttack = null;
		[SerializeField] private float spawnDistance = 1;

		public override void OnPhoenix() {
			if (!CanAct) return;

			Flame attack = GameObject.Instantiate(flameAttack, transform.position + player.HorizontalFacing * spawnDistance, Quaternion.identity)
				.GetComponent<Flame>();

			attack.SetDirection(player.HorizontalFacing);
			attack.SetIgnoreTag("Player");

			StartCountdown();
		}
	}
}
