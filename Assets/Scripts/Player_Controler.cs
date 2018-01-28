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
    public GameObject player2;
    public Vector3 Cord;
    //public float ydistance;
    public LayerMask pla;
    public Animator anim;
    public bool stop;
    // public bool genm;
    // Use this for initialization
    void Start () {

        cc = GetComponent<CharacterController>();
        
        
    }
	
	// Update is called once per frame
	void Update () {

        
        if (!pluged && gender == "mail" && otherPlayer.pluged == true)
        {

                    
          /*  Cord = new Vector3(player2.transform.position.x - transform.position.x, player2.transform.position.y - transform.position.y, player2.transform.position.z);
           
            Ray ray = new Ray(transform.position, Cord);
            RaycastHit hit;
       
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                
                    loosCord = true;
                


            }
            else
            {
                loosCord = false;
            }
            Debug.DrawRay(ray.origin, Cord, Color.red); */

            yreset = moveValosity.y;

            moveValosity = (transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed);
            Debug.Log("" + moveValosity);
            moveValosity = moveValosity.normalized * playerSpeed;

            moveValosity.y = yreset;

            if(moveValosity.x > 0)
            {
                transform.GetChild(0).rotation = Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z);
            }
            else if(moveValosity.x < 0)
            {
                transform.GetChild(0).rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
            }

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

        // ydistance = Mathf.Abs(transform.position.y) - Mathf.Abs(player2.transform.position.y);

        //  if(ydistance < 0)
        // {
        // ydistance = Mathf.Abs(ydistance);
        //  }
        anim.SetFloat("speed", Mathf.Abs(moveValosity.x));
        anim.SetBool("jump", cc.isGrounded);

        Cord = new Vector3(player2.transform.position.x - transform.position.x, player2.transform.position.y - transform.position.y, player2.transform.position.z - transform.position.z);

        Ray ray = new Ray(transform.position, Cord);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, pla))
        {
            if(hit.collider.tag == "Player")
            {
            loosCord = true;
              //print("" + hit.distance);
            }
            
        }
        else 
        {
            loosCord = false;
        }

        
        
        if(gender == "mail")
        {
            Debug.DrawRay(ray.origin, Cord, Color.red);
        }

        if (gender == "femail")
        {
            Debug.DrawRay(ray.origin, Cord, Color.blue);
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
