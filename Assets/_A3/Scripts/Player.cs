using Com.KheruSEmporium.A3;
using Com.KheruSEmporium.A3.A3.Cloaks;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Damageable {
	[SerializeField] private PlayerSettings settings = null;
	[SerializeField] private PlayerVisual visual = null;
	[SerializeField] private Animator animator = null;
	
	private Cloak cloak = null;
	private List<Cloak> assimilatedCloaks = new List<Cloak>();
	public bool HasCloak => cloak != null;
	public CloakType CloakType => cloak.Type;

	private float moveSpeed = 0;
	private float MoveSpeed { get { return moveSpeed; } 
		set {
			float inputX = velocity.x / moveSpeed;

			moveSpeed = value;

			velocity.x = inputX * moveSpeed;
		}
	}


	public event Action OnPlayerInteract;

	override protected void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		moveSpeed = settings.MovementSpeed;

		//temp
		cloak?.SetPlayer(this);
		base.Start();
	}

	public void SetMoving(bool canMove) {
		MoveSpeed = canMove ? settings.MovementSpeed : 0;
	}

	public override void SetInvincible(float timeBeforeFalse = -1) {
		base.SetInvincible(timeBeforeFalse);

		visual.ShowInvincible(true);
		DOTween.Sequence().AppendInterval(timeBeforeFalse).AppendCallback(delegate () { visual.ShowInvincible(false); });
	}

	// Controls
	public InputTransmitter onMove = new InputTransmitter();
	public void OnMove(InputValue value) {
		velocity = value.Get<Vector2>() * MoveSpeed;
		onMove?.Invoke(value);
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

	private bool isStagging = false;

	public void OnStag(InputValue value) {
		bool stagging = value.Get<float>() > 0;

		if (stagging != isStagging) {

			if (stagging) isStagging = stagging;
			else DOTween.Sequence().AppendInterval(settings.JumpGraceTime).AppendCallback(delegate () { isStagging=stagging; });

		}
	}

	public void OnPhoenix(InputValue value) {
		cloak?.OnPhoenix();
		foreach (Cloak item in assimilatedCloaks) {
			item.OnPhoenix();
		}
	}

	private void UseCloaks() {
		if (isStagging) {
			cloak?.OnStag();

			foreach (Cloak item in assimilatedCloaks) {
				item.OnStag();
			}
		}
	}

	// Actions

	protected void FixedUpdate() {
		Move();
		UseCloaks();
	}

	/// <summary>
	/// Override Move to ignore Y velocity.
	/// </summary>
	protected override void Move() {
		velocity.y = rigidBody.velocity.y;

		animator.SetFloat("Speed", Mathf.Abs(velocity.x));
		if (velocity.x != 0) transform.localScale = new Vector3(velocity.x > 0 ? 1 : -1, 1, 1);
		base.Move();
	}

	protected override void CheckGround() {
		bool wasGrounded = IsGrounded;
		base.CheckGround();

		if (wasGrounded != IsGrounded) {
			MoveSpeed = IsGrounded? settings.MovementSpeed : settings.AirSpeed;
		}
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

public class InputTransmitter : UnityEvent<InputValue> { }
