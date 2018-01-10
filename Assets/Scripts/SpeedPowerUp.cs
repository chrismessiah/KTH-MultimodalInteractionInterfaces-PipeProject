using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour {
	float speed = 30000.0f;
	float normalize_constant = 40.0f;

	GameObject parent, E1, E2;
	Rigidbody ball_rb;
	Vector3 E1toE2, E2toE1, movementVector;

	static bool triggerE1 = false, triggerE2 = false;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter (Collider col) {
			parent = gameObject.transform.parent.gameObject;
			E1 = parent.transform.GetChild(0).gameObject;
			E2 = parent.transform.GetChild(1).gameObject;

			ball_rb = col.gameObject.GetComponent<Rigidbody> ();

			// entered through E1
			if (gameObject.name == E1.name) {
				movementVector = (E2.transform.position - E1.transform.position).normalized;
				triggerE1 = true;
			}

			// entered through E2
			if (gameObject.name == E2.name) {
				movementVector = (E1.transform.position - E2.transform.position).normalized;
				triggerE2 = true;
			}

			// exited
			if (triggerE1 && triggerE2) {
				triggerE1 = false;
				triggerE2 = false;
			}
	}

	void FixedUpdate () {
		if (ball_rb && (triggerE1 || triggerE2)) {
			ball_rb.AddForce (movementVector * speed * Time.deltaTime);
		}
	}

}
