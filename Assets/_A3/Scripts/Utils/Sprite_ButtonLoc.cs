using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Com.KheruSEmporium.A3 {
	[RequireComponent(typeof(Image))]
	public class Sprite_ButtonLoc : MonoBehaviour {
		private Image visual;

		[SerializeField] private ButtonLocalisation settings = default;
		[SerializeField] private Control control = default;
		private PlayerInput inputs;

		public void SetControl(Control control) {
			this.control = control;
		}

		private void Start() {
			visual = GetComponent<Image>();

			inputs = FindObjectOfType<PlayerInput>();

			inputs.onControlsChanged += UpdateVisual;
			UpdateVisual();
		}

		public void UpdateVisual(PlayerInput controls = null) {
			if (controls == null) controls = inputs;

			Enum.TryParse<ControllerType>(controls.currentControlScheme, true, out ControllerType type);

			if (settings.ButtonList.TryGetValue(control, out ControlschemeSprite_SerializableDictionary controlSprites)) {
				if (controlSprites.TryGetValue(type, out Sprite sprite)) {
					visual.sprite = sprite;
				}
				else Debug.LogError("No sprite under the " + type + " option of " + control + " in the Settings asset");
			}
			else Debug.LogError("No such control in the Settings asset: " + control);
		}
	}

	public enum ControllerType {
		Keyboard,
		PS4,
		Xbox
	}

	public enum Control {
		GamepadUp,
		GamepadDown,
		GamepadRight,
		GamepadLeft,
		Start,
		Select,
		JoystickL,
		JoystickR
	}
}
