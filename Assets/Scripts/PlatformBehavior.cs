using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour {

	public bool activated;
	private Vector3 startPos, endPos;
	public bool atStart;
	public float heightChange;
	public float speedPlat;
	private float maxDistanceDelta;

	FMOD.Studio.EventInstance Platform;
	FMOD.Studio.ParameterInstance speed;
	public float speedNumber;
	bool loop;

	void Awake()
	{
		speedNumber = 0;
		Platform = FMODUnity.RuntimeManager.CreateInstance("event:/PlatformMoving");
		Platform.getParameter("speed", out speed);
	}

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		endPos = new Vector3 (transform.position.x, transform.position.y + heightChange, transform.position.z);
		maxDistanceDelta = speedPlat * Time.deltaTime;

		FMODUnity.RuntimeManager.AttachInstanceToGameObject(Platform, GetComponent<Transform>(), GetComponent<Rigidbody>());
		Platform.start();
	}
	
	// Update is called once per frame
	void Update () {

		speed.setValue(speedNumber);
		
		if (activated) {
			if (atStart) {
				transform.position = Vector3.MoveTowards (transform.position, endPos, maxDistanceDelta);
				atStart = false;
				loop = false;
			}
			else {
				transform.position = Vector3.MoveTowards (transform.position, startPos, maxDistanceDelta);
				atStart = true;
				loop = true;
			}


		}
		speed.setValue(speedNumber);

		if (loop)
		{
			if (speedNumber < 50)
				speedNumber++;
		}

		if (!loop)
		{
			if (speedNumber > 0)
				speedNumber -= .5f;
		}
	}

}
