using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    [SerializeField]
    private float fillAmountPlayer1;

    [SerializeField]
    private float fillAmountPlayer2;

    [SerializeField]
    private Image player1Health;

    [SerializeField]
    private Image player2Health;

	// Update is called once per frame
	void Update ()
    {
        HandleBar();
	}

    private void HandleBar()
    {
        player1Health.fillAmount = fillAmountPlayer1;
        player2Health.fillAmount = fillAmountPlayer2;
    }

    public void Health(int playerNumber, int health)
    {
        if (playerNumber == 1)
        {
            fillAmountPlayer1 = (float) health / 100;
        }
        else if (playerNumber == 2)
        {
            fillAmountPlayer2 = (float)health / 100;
        }
    }
}
