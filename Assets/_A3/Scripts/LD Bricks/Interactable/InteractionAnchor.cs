using Com.KheruSEmporium.A3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
    public class InteractionAnchor : Interactable
    {
        [SerializeField] private bool isInteractable = true;
        [SerializeField] private List<GameObject> linkedObjects = new List<GameObject>();
		[Space]
		[SerializeField] private SpriteRenderer visual = default;
		[SerializeField] private Material lockedMaterial= default;
		[SerializeField] private Material availableMaterial= default;
        private List<IReactor> linkedReactors = new List<IReactor>();

		private int finishedReactions = 0;


		protected override void Start() {
			base.Start();

			foreach (GameObject gameObject in linkedObjects) {
				IReactor reactor = gameObject.GetComponentInChildren<IReactor>();
				if (reactor != null) linkedReactors.Add(reactor);
			}

			foreach (IReactor reactor in linkedReactors) {
				reactor.onDoneReacting += Reactor_onDoneReacting;
			}

			SetInteractable(isInteractable);
		}

		public void SetInteractable(bool value) {
			isInteractable = value;

			//Temporary
			visual.material = isInteractable? availableMaterial: lockedMaterial;
			animator.SetBool("PlayerInRange", isInteractable);
		}

		private void Reactor_onDoneReacting() {
			finishedReactions++;

			if (finishedReactions >= linkedReactors.Count) SetInteractable(true);
		}

		protected override void OnPlayerInteract() {
			if (isInteractable) {
				SetInteractable(false);
				finishedReactions = 0;

				foreach (IReactor reactor in linkedReactors) {
					reactor.React();
				}
			}
			else CantInteract();
		}
	}
}
