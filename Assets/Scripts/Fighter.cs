using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Fighter : MonoBehaviour {

	[SerializeField] private float moveSpeed = 2000f;
	[SerializeField] private float maxMoveSpeed = 50.0f;
	[SerializeField] private float turnAngle = 5f;

	private new Rigidbody rigidbody;

	private PhotonView photonView;

	private float xInput = 0f;
	private float yInput = 0f;

	#region UNITY

	void Awake() 
	{
		rigidbody = GetComponent<Rigidbody>();
		photonView = GetComponent<PhotonView>();
	}
	
	// Read player input
	void Update() 
	{
		if (!photonView.IsMine) return;

		xInput = Input.GetAxisRaw("Horizontal");
		yInput = Input.GetAxisRaw("Vertical");
	}

	void FixedUpdate() 
	{
		if (!photonView.IsMine) return;
		/*
		Quaternion rot = rigidbody.rotation * Quaternion.Euler(0, turnInput * turnSpeed * Time.fixedDeltaTime, 0);
		rigidbody.MoveRotation(rot);

		Vector3 force = (moveInput * moveSpeed * Time.fixedDeltaTime) * (rot * Vector3.forward);
		rigidbody.AddForce(force);
		*/

		if (xInput == 0f && yInput == 0f) return;

		Vector3 lookDirection = (new Vector3(xInput, 0, yInput)).normalized;

		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookDirection), turnAngle*Time.fixedDeltaTime);
		Vector3 force = (moveSpeed * Time.fixedDeltaTime) * lookDirection;
		rigidbody.AddForce(force);
		rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxMoveSpeed);
	}

	#endregion
}
