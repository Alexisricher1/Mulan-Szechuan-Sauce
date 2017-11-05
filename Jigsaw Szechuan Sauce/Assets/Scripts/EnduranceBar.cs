using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class EnduranceBar : MonoBehaviour {
    [SerializeField]
    private float fillAmountPlayer1;

    [SerializeField]
    private float fillAmountPlayer2;

    [SerializeField]
    private Image player1Endurance;

    [SerializeField]
    private Image player2Endurance;

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        player1Endurance.fillAmount = fillAmountPlayer1;
        player2Endurance.fillAmount = fillAmountPlayer2;
    }

    public void Endurance(int playerNumber, int endurance)
    {
        if (playerNumber == 1)
        {
            fillAmountPlayer1 = (float)endurance / 100;
        }
        else if (playerNumber == 2)
        {
            fillAmountPlayer2 = (float)endurance / 100;
        }
    }
}
