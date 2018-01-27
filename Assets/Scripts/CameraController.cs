using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;

	public Vector3 rotationOffset;

	public float fallbackMultiplier;
	public Vector3 positionOffset;

	void Update () {
		var playerRotation = player.rotation.eulerAngles;

		// Rotation
		transform.rotation = Quaternion.Euler(playerRotation + rotationOffset);

		// Position
		transform.position = player.position + player.forward * (-fallbackMultiplier) + positionOffset;
	}
}
