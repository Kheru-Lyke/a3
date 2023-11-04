using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    public class Damageable : Moving
    {
        [SerializeField] private float maxHealth = 10;
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

        public virtual void ChangeHealthBy(float value) {
            Health -= value;
        }

        protected virtual void Die() {
			OnDeath?.Invoke();

            Destroy(gameObject);
		}
    }
}
