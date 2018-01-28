using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour {

	public bool activated;
	private Vector3 startPos, endPos;
	public bool atStart;
	public float heightChange;
	public float speed;
	private float maxDistanceDelta;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		endPos = new Vector3 (transform.position.x, transform.position.y + heightChange, transform.position.z);
		maxDistanceDelta = speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (activated) {
			if (atStart) {
				transform.position = Vector3.MoveTowards (transform.position, endPos, maxDistanceDelta);
				atStart = false;
			}
			else {
				transform.position = Vector3.MoveTowards (transform.position, startPos, maxDistanceDelta);
				atStart = true;
			}
		}
	}
}
