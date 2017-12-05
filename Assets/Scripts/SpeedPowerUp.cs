﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour {

	float speed = 20000.0f;
	string E1Str = "Entrence_1", E2Str = "Entrence_2"; // need to be unique

	GameObject E1, E2;
	Rigidbody Ball;
	Vector3 E1toE2, E2toE1, movementVector;

	static bool triggerE1 = false, triggerE2 = false;

	// Use this for initialization
	void Start () {
		E1 = GameObject.Find(E1Str);
		E2 = GameObject.Find(E2Str);
		Ball = GameObject.Find("Ball").GetComponent<Rigidbody> ();

		// Create vector E1->E2 (assuming entrence is E1)
		E1toE2 = E2.transform.position - E1.transform.position;
		E1toE2 = E1toE2.normalized;

		// Create vector E2->E1 (assuming entrence is E1)
		E2toE1 = E1.transform.position - E2.transform.position;
		E2toE1 = E2toE1.normalized;
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Ball") {

			// entered through E1
			if (gameObject.name == E1Str) {
				movementVector = E1toE2;
				triggerE1 = true;
			}

			// entered through E2
			if (gameObject.name == E2Str) {
				movementVector = E2toE1;
				triggerE2 = true;
			}

			// exited
			if (triggerE1 && triggerE2) {
				triggerE1 = false;
				triggerE2 = false;
				//movementVector = null;
			}
		}
	}

	void FixedUpdate () {
		if (triggerE1 || triggerE2) {
			print ("adding force");
			Ball.AddForce (movementVector * speed * Time.deltaTime);
		}
	}

}
