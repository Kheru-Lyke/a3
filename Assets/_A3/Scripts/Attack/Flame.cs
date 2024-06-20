using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
	[RequireComponent(typeof(Collider2D))]
	public class Flame : HasLifetime {
		[SerializeField] private float speed = 5f;
		[SerializeField] private Vector3 direction = Vector2.right;

		[Space]
		[SerializeField] private float damage = 1f;

		private string ignoreTag = "None";


		private void Update() {
			transform.position += direction.normalized * (speed * Time.deltaTime);
		}

		public void SetDirection(Vector3 direction) {
			this.direction = direction;
		}

		public void SetIgnoreTag(string ignoreTag) {
			this.ignoreTag = ignoreTag;
		}

		private void OnTriggerEnter2D(Collider2D other) {

			if (other.gameObject.tag != ignoreTag) {
				other.GetComponentInChildren<Damageable>()?.ChangeHealthBy(damage);
				DestroyThis();
			}
		}

	}
}
