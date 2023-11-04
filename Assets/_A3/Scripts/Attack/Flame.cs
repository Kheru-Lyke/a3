using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

namespace Com.KheruSEmporium.A3 {
	[RequireComponent(typeof(Collider2D))]
	public class Flame : MonoBehaviour {
		[SerializeField] private float speed = 5f;
		[SerializeField] private Vector3 direction = Vector2.right;

		[Space]
		[SerializeField] private float damage = 1f;
		[SerializeField] private float maxLifetime = 5f;
		[SerializeField] private float dieTime = 1;

		private string ignoreTag = "None";

		private void Start() {
			StartCoroutine(Cull());
		}

		private IEnumerator Cull() {
			yield return new WaitForSeconds(maxLifetime);

			DestroyAttack();
		}

		private void Update() {
			transform.position += direction * (speed * Time.deltaTime);
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
				DestroyAttack();
			}
		}

		public void DestroyAttack() {
			StopAllCoroutines();

			transform.DOScale(0, dieTime).SetEase(Ease.OutCubic).OnComplete(delegate { Destroy(this.gameObject); });
		}
	}
}
