using Com.KheruSEmporium.A3.A3.Interactable;

namespace Com.KheruSEmporium.A3 {
	public class DiscardCloak : Interactable {
		protected override void OnPlayerInteract() {
			if (!player.HasCloak) {
				animator.SetTrigger("Cant");
				return;
			}

			player.DiscardCloak();
		}
	}
}
