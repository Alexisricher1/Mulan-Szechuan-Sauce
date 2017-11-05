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

    [SerializeField]
    private EnduranceBar enduranceBar;

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


        Endurance();


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

    private void Endurance()
    {

        // Récupération d'endurance
        if (playerAttributes.endurance < 100 && !isSprinting)
        {
            playerAttributes.endurance += 1;
        }
        // ENDURANCE
        else if (Input.GetButton("Joy" + playerNumber + "_BButton"))
        {
            if (playerAttributes.endurance <= 0)
            {
                Debug.Log("player" + playerNumber + " endurance is depleted: " + playerAttributes.endurance + " endurance.");
                isSprinting = false;
            }
            else if (playerAttributes.endurance > 0)
            {
                isSprinting = true;
                playerAttributes.endurance -= 1;
                Debug.Log("player" + playerNumber + " is sprinting with : " + playerAttributes.endurance + " endurance.");
            }
        }
        else if (Input.GetButtonUp("Joy" + playerNumber + "_BButton"))
        {
            Debug.Log("player" + playerNumber + " has stopped sprinting : " + playerAttributes.endurance + " endurance.");

            isSprinting = false;
        }
        enduranceBar.Endurance(playerNumber, playerAttributes.endurance);

    }
}
