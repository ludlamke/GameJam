using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform p1, p2;
	public float minSizeY = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SetCameraPos ();
		SetCameraSize ();
	}

	void SetCameraPos()
	{
		Vector3 middle = (p1.position + p2.position) * 0.5f;
		transform.position = new Vector3 (middle.x, middle.y, transform.position.z);
	}

	void SetCameraSize()
	{
		float minSizeX = minSizeY * Screen.width / Screen.height;

		float width = Mathf.Abs (p1.position.x - p2.position.x) * 0.5f;
		float height = Mathf.Abs (p1.position.y - p2.position.y) * 0.5f;

		float camSizeX = Mathf.Max (width, minSizeX);
		GetComponent<Camera> ().orthographicSize = Mathf.Max (height, camSizeX * Screen.height / Screen.width, minSizeY);

	}

}
