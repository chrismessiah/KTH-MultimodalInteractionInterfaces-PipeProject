using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OnDetection : MonoBehaviour, ITrackableEventHandler {
	public Transform ground;
	public GameObject spawn;

	GameObject currentPipe;
	bool done = false;

	private TrackableBehaviour mTrackableBehaviour;

	void Start()
	{
		currentPipe = gameObject.transform.GetChild(0).gameObject;
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}


	// Update is called once per frame
	void Update () {}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{ 
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			if (!done) {
				OnTrackingFound ();
				done = true;
			}
		}
	}

	private void OnTrackingFound()
	{
		Vector3 pos = currentPipe.transform.position;
		print (pos);
		//Destroy (currentPipe);
		//pos = new Vector3(0, -15, -3);
		spawn.transform.position = pos - new Vector3(1, 35, 42);
		currentPipe = Instantiate (spawn, ground) as GameObject;


	}
}
