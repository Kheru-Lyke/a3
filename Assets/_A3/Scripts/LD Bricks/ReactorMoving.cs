using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
	[Serializable]
	[RequireComponent(typeof(Rigidbody2D))]
    public class ReactorMoving : MonoBehaviour, IReactor
    {
        [SerializeField] private List<Transform> pathPoints = new List<Transform>();
		[SerializeField] private float delayBetweenPoints = 1.5f;
		[SerializeField] private bool looping = true;
		private int currentPathIndex = 0;
		private Rigidbody2D rb;

		public event Action onDoneReacting;

		private void Start() {
			if (pathPoints.Count > 0) { 
				transform.position = pathPoints[0].position;
				transform.rotation = pathPoints[0].rotation;
				transform.localScale = pathPoints[0].localScale;
			}

			rb = GetComponent<Rigidbody2D>();
		}

		public void React() {
			if (pathPoints.Count <= 1) {
				onDoneReacting?.Invoke();
				return;
			}

			if (currentPathIndex+1 >= pathPoints.Count) {
				if (looping) currentPathIndex = -1;
				else {
					onDoneReacting?.Invoke();
					return;
				}
			}

			Transform nextPoint = pathPoints[currentPathIndex+1];

			DOTween.Sequence()
				.Append(rb.DOMove(nextPoint.position, delayBetweenPoints))
				.Join(rb.DORotate(nextPoint.rotation.eulerAngles.z, delayBetweenPoints))
				.Join(transform.DOScale(nextPoint.localScale, delayBetweenPoints))
				.AppendCallback(delegate {
					currentPathIndex++;
					onDoneReacting?.Invoke();
				});

		}
	}
}
