using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spaces : MonoBehaviour
{
    public Button button;
    public Text buttonText;

    private TicTacToeManager tictactoemanager;

    public void CreateTicTacToeManager(TicTacToeManager manager)
    {
        tictactoemanager = manager;
    }

    public void SetSpace()
    {
        buttonText.text = tictactoemanager.GetPlayersMark();
        button.interactable = false;
        tictactoemanager.EndTurn();
    }
}
