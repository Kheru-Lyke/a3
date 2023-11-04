using Com.KheruSEmporium.A3.A3.Interactable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    public class AssimilateCloak : Interactable
    {
		protected override void OnPlayerInteract() {
			if (!player.HasCloak) {
				animator.SetTrigger("Cant");
				return;
			}

			player.AssimilateCloak();
		}
	}
}
