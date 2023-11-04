using Com.KheruSEmporium.A3;
using Com.KheruSEmporium.A3.A3.Cloaks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Damageable {
	[SerializeField] private PlayerSettings settings = null;
	[SerializeField] private PlayerVisual visual = null;
	
	private Cloak cloak = null;
	private List<Cloak> assimilatedCloaks = new List<Cloak>();
	public bool HasCloak => cloak != null;

	private bool isGrounded = false;
	public bool IsGrounded => isGrounded;

	public event Action OnPlayerInteract;

	private void Start() {
		rigidBody = GetComponent<Rigidbody2D>();

		//temp
		cloak?.SetPlayer(this);
	}

	// Controls
	public void OnMove(InputValue value) {
		velocity = value.Get<Vector2>() * settings.MovementSpeed;
	}

	public void OnInteract(InputValue value) {
		OnPlayerInteract?.Invoke();
	}

	public void OnBeetle(InputValue value) {
		cloak?.OnBeetle();
		foreach (Cloak item in assimilatedCloaks) {
			item.OnBeetle();
		}
	}

	public void OnStag(InputValue value) {
		cloak?.OnStag();
		foreach (Cloak item in assimilatedCloaks) {
			item.OnStag();
		}
	}

	public void OnPhoenix(InputValue value) {
		cloak?.OnPhoenix();
		foreach (Cloak item in assimilatedCloaks) {
			item.OnPhoenix();
		}
	}

	// Actions

	protected void FixedUpdate() {
		Move();

		Transform hit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, ~(1 << 3)).transform;
		isGrounded = hit;
	}

	/// <summary>
	/// Override Move to ignore Y velocity.
	/// </summary>
	protected override void Move() {
		velocity.y = rigidBody.velocity.y;
		base.Move();
	}

	public void SetCloak(Cloak cloak) {
		this.cloak = cloak;

		if (cloak != null) {
			cloak.SetPlayer(this);

			cloak.gameObject.transform.SetParent(transform, false) ;
		}
	}

	public void DiscardCloak() {
		if (!HasCloak) return;

		cloak.ResetCloak();
		SetCloak(null);
	}

	public void AssimilateCloak() {
		if (!HasCloak) return;

		assimilatedCloaks.Add(cloak);
		cloak.Assimilate();
		SetCloak(null);

		visual.SetVisual(assimilatedCloaks);
	}
}
