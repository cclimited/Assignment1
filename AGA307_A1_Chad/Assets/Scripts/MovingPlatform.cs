using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	Vector3 deltaPosition;
	Vector3 posCurrentFrame = Vector3.zero;
	Vector3 posLastFrame = Vector3.zero;

	private void FixedUpdate()
	{
		posCurrentFrame = transform.position;
		deltaPosition = posCurrentFrame - posLastFrame;
		posLastFrame = posCurrentFrame;
	}


	private void OnCollisionStay(Collision collision)
	{
		EventHandler.OnRigidbodyMove(collision.collider.gameObject, deltaPosition);
	}

}
