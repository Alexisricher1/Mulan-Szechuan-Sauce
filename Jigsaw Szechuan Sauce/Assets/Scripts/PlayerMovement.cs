using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerNumber;
    public float speed = 6.0F;
    public float gravity = 20.0F;
    public float sprintingForce = 7f;
    public bool isSprinting;

    private Vector3 moveDirection = Vector3.zero;
    private PlayerAttributes playerAttributes;

    private Rigidbody rb;

    void Start()
    {
        isSprinting = false;
        rb = GetComponent<Rigidbody>();
        playerAttributes = GetComponent<PlayerAttributes>();
    }

    void Update()
    {
        //    if (controller.isGrounded && !playerAttributes.IsDead())
        //    {
        //        moveDirection = new Vector3(Input.GetAxis("Joy" + playerNumber + "_LeftJoyHorizontal"),
        //                                    0, Input.GetAxis("Joy" + playerNumber + "_LeftJoyVertical"));
        //        moveDirection = transform.TransformDirection(moveDirection);
        //        moveDirection *= speed;
        //    }

        //    zPressure = Mathf.Abs(Input.GetAxis("Joy" + playerNumber + "_LeftJoyHorizontal"));
        //    moveDirection.y -= gravity * Time.deltaTime;

        //    controller.Move(moveDirection * Time.deltaTime);
        //}

        // Sprinting
        if (Input.GetButtonDown("Joy" + playerNumber + "_BButton"))
        {
            isSprinting = true;
        }

        moveDirection = new Vector3(Input.GetAxis("Joy" + playerNumber + "_LeftJoyHorizontal"),
                                    0, Input.GetAxis("Joy" + playerNumber + "_LeftJoyVertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed + (isSprinting ? sprintingForce : 0);

        // Apply a force that attempts to reach our target velocity
        var velocity = rb.velocity;
        var velocityChange = (moveDirection - velocity);
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
