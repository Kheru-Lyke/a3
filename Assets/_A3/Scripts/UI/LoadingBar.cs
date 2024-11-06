using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.KheruSEmporium.A3 {
    public class LoadingBar : MonoBehaviour
    {
        private Slider bar;

		private void Start() {
			bar = GetComponentInChildren<Slider>();
		}

		private void Update() {
			bar.value = GameManager.Instance.LoadProgress;
		}
	}
}
