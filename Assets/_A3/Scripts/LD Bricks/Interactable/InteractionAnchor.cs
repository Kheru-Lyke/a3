using Com.KheruSEmporium.A3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
    public class InteractionAnchor : Interactable
    {
        [SerializeField] protected bool isInteractable = true;
        [SerializeField] protected List<GameObject> linkedObjects = new List<GameObject>();
		[Space]
		[SerializeField] protected SpriteRenderer visual = default;
		[SerializeField] protected Material lockedMaterial= default;
		[SerializeField] protected Material availableMaterial= default;
        private List<IReactor> linkedReactors = new List<IReactor>();

		private int finishedReactions = 0;


		protected override void Start() {
			base.Start();

			InitializeList(); 
			visual.material = isInteractable ? availableMaterial : lockedMaterial;
		}

		protected virtual void InitializeList() {
			foreach (GameObject gameObject in linkedObjects) {
				IReactor reactor = gameObject.GetComponentInChildren<IReactor>();		//Refactoriser
				if (reactor != null) linkedReactors.Add(reactor);
			}

			foreach (IReactor reactor in linkedReactors) {
				reactor.onDoneReacting += Reactor_onDoneReacting;
			}
		}

		public void SetInteractable(bool value) {
			isInteractable = value;

			//Temporary
			visual.material = isInteractable? availableMaterial: lockedMaterial;
			if (playerInRange) animator.SetBool("PlayerInRange", isInteractable);
		}

		protected void Reactor_onDoneReacting() {
			finishedReactions++;

			if (finishedReactions >= linkedReactors.Count) SetInteractable(true);
		}

		protected override void OnPlayerInteract() {
			if (isInteractable) {
				ActOnLinked();
			}
			else CantInteract();
		}

		protected virtual void ActOnLinked() {
			SetInteractable(false);

			finishedReactions = 0;

			foreach (IReactor reactor in linkedReactors) {
				reactor.React();
			}
		}
	}
}
