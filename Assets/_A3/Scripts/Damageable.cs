using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    public class Damageable : Moving
    {
        [SerializeField] private float maxHealth = 10;
        [SerializeField] private bool isInvincible = false;
        private float health;
        public event Action OnDeath;

		private void Start() {
            health = maxHealth;
		}

		protected float Health { get { return health; }
            set {
				health = value;

				if (health <= 0) Die();
                else if (health > maxHealth) health= maxHealth;
            }
        }

        public virtual void SetInvincible(float timeBeforeFalse = -1) {
            isInvincible = true;

            if (timeBeforeFalse > 0)
            DOTween.Sequence().AppendInterval(timeBeforeFalse).AppendCallback(delegate () { isInvincible = false; });
        }

        public virtual void ChangeHealthBy(float value) {
            if (!isInvincible) Health -= value;
        }

        protected virtual void Die() {
            velocity = Vector2.zero;
			OnDeath?.Invoke();

            Destroy(gameObject);
		}
    }
}
