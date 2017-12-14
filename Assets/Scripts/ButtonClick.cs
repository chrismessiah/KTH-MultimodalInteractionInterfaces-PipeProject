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
		currentBall = Instantiate(child, new Vector3(0, 0, 5), Quaternion.identity, parent) as GameObject;
	}
}
