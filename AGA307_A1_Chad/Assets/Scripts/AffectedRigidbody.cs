using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedRigidbody : MonoBehaviour
{
	private void OnEnable()
	{
		EventHandler.RigidbodyMove += OnRigidbodyMove;	
	}

	private void OnDisable()
	{
		EventHandler.RigidbodyMove -= OnRigidbodyMove;
	}

	void OnRigidbodyMove(GameObject stander, Vector3 deltaPosition)
	{
		if (this.gameObject != stander)
			return;

		transform.position += deltaPosition;
	}
}
