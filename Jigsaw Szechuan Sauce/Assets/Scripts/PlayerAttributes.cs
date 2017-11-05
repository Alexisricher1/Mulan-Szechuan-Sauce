using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int health = 100;
    public int endurance = 100;
    private PlayerMovement playerMovement;
    private int playerNumber;

    [SerializeField]
    private HealthBar healthBarUI;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerNumber = playerMovement.playerNumber;
    }

    public void GetHit(int damage)
    {
        health -= damage;

        // UI 
        healthBarUI.Health(playerNumber, health);

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
