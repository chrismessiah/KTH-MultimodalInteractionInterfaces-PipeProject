using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

	public Button yourButton;
	public Transform child;
	public Transform parent;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Instantiate(child, new Vector3(0, 0, -40), Quaternion.identity, parent);
	}
}
