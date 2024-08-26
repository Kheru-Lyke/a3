using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {

	[RequireComponent(typeof(Collider2D), typeof(Animator))]
	public class Interactable : MonoBehaviour
    {
		protected Animator animator;
		protected Player player;
		protected bool playerInRange = false;

		protected virtual void Start() {
			animator = GetComponent<Animator>();
		}

		protected void OnTriggerEnter2D(Collider2D collision) {
			Player collided = collision.gameObject.GetComponent<Player>();

			if (collided) {
				player = collided;
				ShowCanInteract(true);
				player.OnPlayerInteract += OnPlayerInteract;
			}

			playerInRange = player;
		}

		protected virtual void OnPlayerInteract() {
			CantInteract();
		}

		protected void CantInteract() {
			animator.SetTrigger("Cant");
		}

		protected void OnTriggerExit2D(Collider2D collision) {
			if (!player) return;

			ShowCanInteract(false);
			player.OnPlayerInteract-= OnPlayerInteract;
		}

		protected virtual void ShowCanInteract(bool canInteract) {
			animator.SetBool("PlayerInRange", canInteract);
		}
	}
}
