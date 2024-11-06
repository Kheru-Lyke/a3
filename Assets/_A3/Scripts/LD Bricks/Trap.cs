using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.KheruSEmporium.A3
{
    public class Trap : MonoBehaviour
    {
		[SerializeField] protected int damage = 1;

		private void OnTriggerEnter2D(Collider2D collision) {
			Damageable hit = collision.GetComponentInChildren<Damageable>();

			if (hit != null) {
				hit.ChangeHealthBy(-damage);
			}
		}
	}
}
