using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerNumber;
    public float speed = 6.0F;
    public float gravity = 20.0F;
    public RopeManager ropeManager;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private PlayerAttributes playerAttributes;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        playerAttributes = GetComponent<PlayerAttributes>();
    }

    void Update()
    {
        if (controller.isGrounded && !playerAttributes.IsDead())
        {
            moveDirection = new Vector3(Input.GetAxis("Joy" + playerNumber + "_LeftJoyHorizontal"),
                                        0, Input.GetAxis("Joy" + playerNumber + "_LeftJoyVertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        // Setting max distance for rope to players
        if (playerNumber == 1)
        {
            ropeManager.player2MaxDist = Math.Abs(transform.position.z);
            Debug.Log("player 1 max dist : " + ropeManager.player1MaxDist);
        }
        else
        {
            ropeManager.player1MaxDist = Math.Abs(transform.position.z);
            //Debug.Log("player 2 dist : " + ropeManager.player2MaxDist);
        }


        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
