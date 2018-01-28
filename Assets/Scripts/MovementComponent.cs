using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {
  public float speed;
  public float rotationSpeed;

	private Transform t;

  public string axisSuffix;


	void Start(){
		t = transform.GetChild (0);
	}

	void Update () {

		// Lateral movement
		float rotation = Input.GetAxis("Horizontal" + " " + axisSuffix) * rotationSpeed;
        //t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y + 0 + rotation*5 , t.eulerAngles.z);
        transform.Rotate(0, rotation, 0);

        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 1)){

            Debug.Log(hitInfo.collider.name);

            if (hitInfo.collider.name != "Pared")
            {
                // Forward movement
                transform.position += transform.forward * Time.deltaTime * speed;
            }
        }else
        {
            // Forward movement
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

}
