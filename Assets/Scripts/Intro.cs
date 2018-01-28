using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

    public float timer;
    public float aGameByTimer;
    public float namesTimer;
    public float introEndTimer;
    public float specialThanksTimer;
    public bool aGameByActive;
    public bool nameActive;
    public bool specialThanksActive;
    public bool introDone;
    public bool titleScreen;

    public GameObject aGameBy;
    public GameObject mike;
    public GameObject kevin;
    public GameObject david;
    public GameObject hernani;
    public GameObject lucas;
    public GameObject bill;
    public GameObject intro;
    public GameObject specialThanks;
    public GameObject brooks;
    public GameObject title;

    public Image introImage;

    // Use this for initialization
    void Start () {
        timer = 0;
        aGameByActive = true;
        nameActive = true;
        specialThanksActive = true;
        introDone = false;
        titleScreen = true;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        //Makes the words "A Game By" pop up for a brief moment
        if(aGameByTimer <= timer && aGameByActive)
        {
            aGameBy.SetActive(true);
            if(aGameByTimer + 1.5 < timer)
            {
                aGameByActive = false;
                aGameBy.SetActive(false);
            }
        }

        //Displays names in order
        if (namesTimer <= timer && nameActive)
        {
            mike.SetActive(true);
            if(namesTimer + 1 < timer)
            {
                kevin.SetActive(true);
            }
            if(namesTimer + 2 < timer)
            {
                david.SetActive(true);
            }
            if(namesTimer + 3 < timer)
            {
                hernani.SetActive(true);
            }
            if(namesTimer + 4 < timer)
            {
                lucas.SetActive(true);
            }
            if(namesTimer + 5 < timer)
            {
                bill.SetActive(true);
            }
            if (namesTimer + 6.5 < timer)
            {
                nameActive = false;
                mike.SetActive(false);
            }
        }

        if (specialThanksTimer <= timer && specialThanksActive)
        {
            specialThanks.SetActive(true);
            if (specialThanksTimer + 1 < timer)
            {
                brooks.SetActive(true);
            }
            if (specialThanksTimer + 2.5 < timer)
            {
                specialThanksActive = false;
                specialThanks.SetActive(false);
            }
        }


        //When timer reaches End time, black fades away, game starts
        if (introEndTimer < timer)
        {
            introImage.CrossFadeAlpha(0, 1.5f, false);
        }
        if(introEndTimer + 6 < timer)
        {
            introDone = true;
            intro.SetActive(false);
        }


        if (introDone && titleScreen)
        {
            title.SetActive(true);
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                titleScreen = false;
                title.SetActive(false);
            }
        }


    }
}
