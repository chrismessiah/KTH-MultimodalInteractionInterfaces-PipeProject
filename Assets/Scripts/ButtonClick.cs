using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

	public Button yourButton;
	public GameObject child;
	public Transform parent;

	GameObject currentBall;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick() {
		if (currentBall) {
			Destroy (currentBall);
		}
		Vector3 pos = new Vector3(0, -25, -6);
		child.transform.position = pos;
		currentBall = Instantiate (child, parent) as GameObject;
	}
}
