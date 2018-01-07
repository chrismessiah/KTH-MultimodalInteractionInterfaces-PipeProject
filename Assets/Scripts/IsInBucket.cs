using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsInBucket : MonoBehaviour {

	public Text winText;
	public Button resetButton;
	public GameObject selectedBall;

	// Use this for initialization
	void Start () {
		winText.text = "";
		Button btn = resetButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		resetButton.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Create text that says you win and a button to reset appears and the time pauses on collision
	//With the surface in the bucket.
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "ball") {
			selectedBall = col.gameObject;
			Time.timeScale = 0;
			winText.text = "You Win! :D";
			resetButton.gameObject.SetActive (true);
		}
	}


	//When pressed reset button delete ball,text and reset button and restart time.
	//This should make it so that everything is reset again.
	void TaskOnClick() {
		Destroy (selectedBall);
		winText.text = "";
		Time.timeScale = 1;
		resetButton.gameObject.SetActive (false);
	}


}