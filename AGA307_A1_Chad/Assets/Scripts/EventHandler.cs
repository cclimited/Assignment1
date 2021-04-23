using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
	public delegate void RigidbodyMoveHandler(GameObject stander, Vector3 deltaMovement);
	public static event RigidbodyMoveHandler RigidbodyMove;
	public static void OnRigidbodyMove(GameObject stander, Vector3 deltaMovement) => RigidbodyMove?.Invoke(stander, deltaMovement);
}
