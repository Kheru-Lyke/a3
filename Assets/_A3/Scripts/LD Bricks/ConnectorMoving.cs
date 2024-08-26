using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Com.KheruSEmporium.A3
{
	public class ConnectorMoving : Moving, IConnector {
		[SerializeField] private float moveSpeed = 5;
		[SerializeField] private Transform startPos = default;
		[SerializeField] private float timeToReset = 1;
		[SerializeField] private bool resetPos = false;
		Player player;

		public void Connect(Player player) {
			this.player = player;
			player.onMove.AddListener(onMoveInput);
		}

		private void onMoveInput(InputValue input) {
			velocity = input.Get<Vector2>() * moveSpeed;
		}

		public void Disconnect() {
			player.onMove.RemoveListener(onMoveInput);
			velocity = Vector2.zero;

			if (resetPos) {
				DOTween.Sequence()
				.Append(transform.DOMove(startPos.position, timeToReset))
				.Join(rigidBody.DORotate(startPos.rotation.eulerAngles.z, timeToReset))
				.Join(transform.DOScale(startPos.localScale, timeToReset));
			}
		}

		private void FixedUpdate() {
			Move();
		}

		private void Start() {
			rigidBody = GetComponent<Rigidbody2D>();
		}
	}
}
