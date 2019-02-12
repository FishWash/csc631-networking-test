using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
	[SerializeField] string tagToFollow = "Player";
	[SerializeField] Vector3 offsetVector = new Vector3(0, 3f, -10f);
	[SerializeField] float lerpRatio = 0.3f;

	GameObject followTarget = null;

	void FixedUpdate() {
		followTarget = GameObject.FindGameObjectWithTag(tagToFollow);
		if (followTarget == null) {
			//Debug.Log("Searching for object tagged " + tagToFollow + "...");
		}
		else {
			Vector3 _destinationPosition = followTarget.transform.position + offsetVector;
			transform.position = Vector3.Lerp(transform.position, _destinationPosition, lerpRatio);
		}
	}
}
