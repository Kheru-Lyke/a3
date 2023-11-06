using Com.KheruSEmporium.A3.A3.Cloaks;
using Com.KheruSEmporium.A3.A3.Interactable;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
	public class Tutorial : Interactable {
		[SerializeField] private Sprite_ButtonLoc button;

		protected override void ShowCanInteract(bool canInteract) {
			if (!player.HasCloak) return;

			base.ShowCanInteract(canInteract);

			Debug.Log(player.CloakType);
			
			switch(player.CloakType) {

				case CloakType.Phoenix:
					button.SetControl(Control.GamepadRight);
					break;
				case CloakType.Beetle:
					button.SetControl(Control.GamepadDown);
					break;
				case CloakType.Stag:
					button.SetControl(Control.GamepadLeft);
					break;
			}

			button.UpdateVisual();
		}
	}
}
