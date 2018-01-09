using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

	public Button yourButton;
	public GameObject child;
	public Transform parent;
	private Vector3 spawnPos;

	GameObject currentBall;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		spawnPos = new Vector3(4, -35, -11);
	}

	void TaskOnClick() {
		if (currentBall) {
			Destroy (currentBall);
		}
		//child.transform.position = spawnPos; 
		currentBall = Instantiate(child, parent) as GameObject;
		currentBall.SetActive (true);
	}
}
