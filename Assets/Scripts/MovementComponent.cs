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
		// Lateral movement
    float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		transform.Rotate(0, rotation, 0);

		// Forward movement
		transform.position += transform.forward * Time.deltaTime * speed;
	}
}
