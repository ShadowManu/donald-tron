using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {
  public float speed;
  public float rotationSpeed;

  public string axisSuffix;

	void Update () {

		// Lateral movement
		float rotation = Input.GetAxis("Horizontal" + " " + axisSuffix) * rotationSpeed;
		transform.Rotate(0, rotation, 0);

		// Forward movement
		transform.position += transform.forward * Time.deltaTime * speed;
	}
}
