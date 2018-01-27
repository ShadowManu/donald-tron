using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {
	public float speed;
  public float rotationSpeed;

	// Use this for initialization
	void Start () {
	}
	
	void Update () {
		// Forward movement
		var direction = transform.forward * speed;
		transform.Translate(direction);

		// Lateral movement
    float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		transform.Rotate(0, rotation, 0);
	}
}
