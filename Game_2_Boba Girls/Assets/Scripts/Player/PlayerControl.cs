using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float playerSpeed = 10.0f;
    public float playerJump = 5.0f;
    public float gravity = 10.0f;
    public string facing = "right";

    public GameObject bobaGun;
    public GameObject gunPos1;
    public GameObject gunPos2;
    public GameObject gunPos3;


    private Vector3 moveDirection = Vector3.zero;
    private BobaGun gun;
    private CharacterController playerController;
    private float gunSpeed = 10f;
    // Use this for initialization
    void Start ()
    {
        gun = GetComponentInChildren<BobaGun>();
        playerController = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update ()
    {
        float step = gunSpeed*Time.deltaTime;
        if (playerController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= playerSpeed;
            if (Input.GetKey(KeyCode.J))
            {
                moveDirection.y = playerJump;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        playerController.Move(moveDirection * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.K))
        {
            gun.gunFire();
        }
       // print(Input.GetAxisRaw("Horizontal"));
        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            facing = "left";
            bobaGun.transform.position = Vector3.MoveTowards(bobaGun.transform.position, gunPos3.transform.position, step);
            if (bobaGun.transform.rotation.eulerAngles.y <= 0)
                bobaGun.transform.Rotate(0, 180, 0, Space.Self);
            if (bobaGun.transform.rotation.eulerAngles.z == 90)
                bobaGun.transform.Rotate(0, 0, -90, Space.Self);
            //bobaGun.transform.RotateAround(bobaGun.transform.position, transform.up, Time.deltaTime * -180f);

        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            facing = "right";
            bobaGun.transform.position = Vector3.MoveTowards(bobaGun.transform.position, gunPos1.transform.position, step);
            if (bobaGun.transform.rotation.eulerAngles.y > 0)
                bobaGun.transform.Rotate(0, -180, 0, Space.Self);
            if (bobaGun.transform.rotation.eulerAngles.z == 90)
                bobaGun.transform.Rotate(0, 0, -90, Space.Self);

            //bobaGun.transform.RotateAround(bobaGun.transform.position, transform.up, Time.deltaTime *180f);
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            bobaGun.transform.position = Vector3.MoveTowards(bobaGun.transform.position, gunPos2.transform.position, step);
            if (bobaGun.transform.rotation.eulerAngles.z != 90)
                bobaGun.transform.Rotate(0,  0, 90, Space.Self);

        }


    }
}
