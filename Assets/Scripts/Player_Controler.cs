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

    // Use this for initialization
    void Start () {

        cc = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

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
    }
}
