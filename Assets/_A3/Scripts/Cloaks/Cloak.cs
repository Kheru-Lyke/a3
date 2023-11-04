
using System;
using System.Collections;
using UnityEngine;

namespace Com.KheruSEmporium.A3.A3.Cloaks {

    [RequireComponent(typeof(Animator))]
    abstract public class Cloak : MonoBehaviour {

        [SerializeField] protected float cooldownInS = 1f;
        [SerializeField] protected CloakType type = CloakType.Stag;
        [SerializeField] protected GameObject visual = null;

		protected Animator animator;
		private bool canAct = true;
        private Transform parent = null;

        protected bool CanAct { get { return canAct; }
            set {
				animator.SetBool("active", value);
                canAct = value;
			}
        }

        public CloakType Type => type;

		protected Player player;

		private void Start() {
			animator = GetComponent<Animator>();
            parent = transform.parent;
		}

		public virtual void SetPlayer(Player player) {
            this.player = player;
        }

        public virtual void OnBeetle() { }
        public virtual void OnStag() { }
        public virtual void OnPhoenix() { }

        protected void StartCountdown() {
            CanAct = false;
            StartCoroutine(CountDown());
        }

        private IEnumerator CountDown() {
            yield return new WaitForSeconds(cooldownInS);
            CanAct = true;
        }

		public void ResetCloak() {
            transform.SetParent(parent, false);
            parent.gameObject.SetActive(true);
		}

		public void Assimilate() {
            visual.SetActive(false);
		}
	}

    [Serializable]
    public enum CloakType {
        Stag,
        Beetle,
        Phoenix
    }
}
