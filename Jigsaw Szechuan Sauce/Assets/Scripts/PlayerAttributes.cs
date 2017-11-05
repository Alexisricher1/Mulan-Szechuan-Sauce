using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int health = 100;
    public int endurance = 100;
    private int playerNumber;

    void Start()
    {
        playerNumber = GetComponentInParent<PlayerMovement>().playerNumber;
    }

    public void GetHit(int damage)
    {
        health -= damage;
        Debug.Log("player " + playerNumber + " lost health : " + health + "health");
        if (IsDead())
        {
            Debug.Log("player " + playerNumber + " is dead!");
            GameManager gm = FindObjectOfType<GameManager>();
            gm.EndGame(playerNumber);
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
