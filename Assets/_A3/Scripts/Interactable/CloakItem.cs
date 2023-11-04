using Com.KheruSEmporium.A3.A3.Cloaks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3.A3.Interactable {
    public class CloakItem : Interactable
    {
		[SerializeField] protected Cloak cloak = null;

		protected override void OnPlayerInteract() {
			if (player.HasCloak) {
				animator.SetTrigger("Cant");
				return;
			}

			player.SetCloak(cloak);
			gameObject.SetActive(false);
		}
	}
}
