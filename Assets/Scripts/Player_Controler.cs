using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour {

    public float playerSpeed;
    public float jumpHight;
    public Vector3 moveValosity;
    public CharacterController cc;
    public float gravty;
    private float yreset;
    public bool pluged;
    public string gender;
    public Player_Controler otherPlayer;
    private bool canPlug;
    public float maxDistance;
    public bool loosCord;
   // public bool genm;
    // Use this for initialization
    void Start () {

        cc = GetComponent<CharacterController>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if(!pluged && gender == "mail" && otherPlayer.pluged == true)
        {
            yreset = moveValosity.y;

            moveValosity = (transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed);

            moveValosity = moveValosity.normalized * playerSpeed;

            moveValosity.y = yreset;

            if (cc.isGrounded)
            {
                moveValosity.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    moveValosity.y = jumpHight;
                }
            }

            moveValosity.y = moveValosity.y + (Physics.gravity.y * gravty * Time.deltaTime);
            cc.Move(moveValosity * Time.deltaTime);

            if(Input.GetButtonDown("Fire1") && canPlug)
            {
                pluged = true;
                otherPlayer.pluged = false;
            }


        }

        if (!pluged && gender == "femail" && otherPlayer.pluged == true)
        {
            yreset = moveValosity.y;

            moveValosity = (transform.right * Input.GetAxisRaw("Fehorizontal") * playerSpeed);

            moveValosity = moveValosity.normalized * playerSpeed;

            moveValosity.y = yreset;

            if (cc.isGrounded)
            {
                moveValosity.y = 0f;
                if (Input.GetButtonDown("Fejump"))
                {
                    moveValosity.y = jumpHight;
                }
            }

            moveValosity.y = moveValosity.y + (Physics.gravity.y * gravty * Time.deltaTime);
            cc.Move(moveValosity * Time.deltaTime);

            if (Input.GetButtonDown("Fefire1") && canPlug)
            {
                pluged = true;
                otherPlayer.pluged = false;
            }
        }

        if(Physics.Raycast(transform.position, otherPlayer.transform.position, maxDistance))
        {
            loosCord = true;
        }
        else
        {
            loosCord = false;
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {

        

        if (gender == "mail" && other.tag == "mailplug")
        {

            // pluged = true;
            // otherPlayer.pluged = false;
            canPlug = true;
            
        }

       
            
        if (gender == "femail" && other.tag == "femailplug" )
        {
            //pluged = true;
            // otherPlayer.pluged = false;
            canPlug = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (gender == "mail" && other.tag == "mailplug")
        {

            // pluged = true;
            // otherPlayer.pluged = false;
            canPlug = false;

        }



        if (gender == "femail" && other.tag == "femailplug")
        {
            //pluged = true;
            // otherPlayer.pluged = false;
            canPlug = false;
        }
    }
}
