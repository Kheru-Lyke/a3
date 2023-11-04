using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3.A3.Interactable {

	[RequireComponent(typeof(Collider2D), typeof(Animator))]
	public class Interactable : MonoBehaviour
    {
		protected Animator animator;
		protected Player player;

		private void Start() {
			animator = GetComponent<Animator>();
		}

		protected void OnTriggerEnter2D(Collider2D collision) {
			player = collision.gameObject.GetComponent<Player>();
			if (player) { 
				ShowCanInteract(true);
				player.OnPlayerInteract += OnPlayerInteract;
			}
		}

		protected virtual void OnPlayerInteract() {
			animator.SetTrigger("Cant");
		}

		protected void OnTriggerExit2D(Collider2D collision) {
			ShowCanInteract(false);
			player.OnPlayerInteract-= OnPlayerInteract;
		}

		protected void ShowCanInteract(bool canInteract) {
			animator.SetBool("PlayerInRange", canInteract);
		}
	}
}
