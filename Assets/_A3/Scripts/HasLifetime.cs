using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    public class HasLifetime : MonoBehaviour
    {

		[SerializeField] protected float maxLifetime = 5f;
		[SerializeField] protected float dieTime = 1;


		private void Start() {
			StartCoroutine(Cull());
		}

		private IEnumerator Cull() {
			yield return new WaitForSeconds(maxLifetime);

			DestroyThis();
		}


		public void DestroyThis() {
			StopAllCoroutines();

			transform.DOScale(0, dieTime).SetEase(Ease.OutCubic).OnComplete(delegate { Destroy(this.gameObject); });
		}
	}
}
