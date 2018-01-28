using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveTest : MonoBehaviour {

    FMOD.Studio.EventInstance Platform;
    FMOD.Studio.ParameterInstance speed;
    public float speedNumber;
    bool loop;

    // Use this for initialization
    void Awake()
    {
        speedNumber = 0;
        Platform = FMODUnity.RuntimeManager.CreateInstance("event:/PlatformMoving");
        Platform.getParameter("speed", out speed);
    }


    void Start () {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Platform, GetComponent<Transform>(), GetComponent<Rigidbody>());
        Platform.start();
	}
	
	// Update is called once per frame
	void Update () {

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
           


        if (Input.GetKeyDown("space"))
        {
            loop = true;
            Debug.Log("space key was pressed");
        }

        if (Input.GetKeyUp("space"))
        {
            loop = false;
            Debug.Log("space key was released");
        }
    }
}
