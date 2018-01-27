using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {
	public float speed;
    public float rotationSpeed;
	public string axisSuffix;
    public Vector3 oldPosition;

	// Use this for initialization
	void Start () {
	}
	
	void Update () {
        oldPosition = transform.position;

        // Lateral movement
        float rotation = Input.GetAxis("Horizontal" + " " + axisSuffix) * rotationSpeed;
		transform.Rotate(0, rotation, 0);

		// Forward movement
		transform.position += transform.forward * Time.deltaTime * speed;
	}
}
