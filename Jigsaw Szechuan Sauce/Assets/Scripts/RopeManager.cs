using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public GameObject Rope1;
    public GameObject Rope2;
    public GameObject player1;
    public GameObject player2;

    public float player1MaxDist;
    public float player2MaxDist;

    void Start()
    {
        player1MaxDist = player1.gameObject.transform.position.z;
        player2MaxDist = player2.gameObject.transform.position.z;
    }

    void Update()
    {
        player1MaxDist = player1MaxDist + player2MaxDist;
        player2MaxDist = player2MaxDist + player2MaxDist;
    }
}
