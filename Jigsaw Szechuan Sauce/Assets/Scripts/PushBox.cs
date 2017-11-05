using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public bool isLeftBox;
    public float pushForce = 50;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PushBox")
            rb.AddForce(new Vector3(0, 0, isLeftBox ? -pushForce : pushForce), ForceMode.VelocityChange);
    }










    //private bool pushOpponentFlag;

    //void Start()
    //{
    //    player1 = GetComponentInParent<PlayerMovement>();
    //}

    //void LateUpdate()
    //{
    //    if (pushOpponentFlag && player1.zPressure >= player2.zPressure && player1.transform.position.z < 0)
    //    {
    //        player2.GetComponent<Rigidbody>().AddForce(
    //            new Vector3(0, 0, player1.zPressure * pushForce), ForceMode.VelocityChange);
    //    }
    //}

    //void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "PushBox")
    //    {
    //        player2 = collision.gameObject.GetComponentInParent<PlayerMovement>();

    //        if (player1.zPressure > player2.zPressure)
    //        {
    //            pushOpponentFlag = true;
    //        }
    //    }
    //}

    //void OnCollisionExit()
    //{
    //    pushOpponentFlag = false;
    //}
}
