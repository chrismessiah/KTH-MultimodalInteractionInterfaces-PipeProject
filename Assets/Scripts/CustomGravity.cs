using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour {

	public float speed = 800.0f;
	Vector3 movementVector = new Vector3 (0.0f, 0.0f, -1.0f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		GetComponent<Rigidbody> ().AddForce (movementVector * speed * Time.deltaTime);
	}
}
