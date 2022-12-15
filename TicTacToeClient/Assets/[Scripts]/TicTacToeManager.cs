using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using TMPro;

public class TicTacToeManager : MonoBehaviour
{
    //Array of texts for each buttons text component
    public Text[] XO_texts;

    //Game object that a text is attached to. Only gets activated once a game is over.
    public GameObject verdictGameObject;
    public Text gameVerdict;
  
    //Players marker
    private string playerMarker;

    //Tracking each players move
    private int moveTracker;

    void Awake()
    {
        //Set the reference for grid spaces
        for (int i = 0; i < XO_texts.Length; i++)
        {
            XO_texts[i].GetComponentInParent<Spaces>().CreateTicTacToeManager(this);
        }

        //Set the first player as marker X
        playerMarker = "X";

        //Hide the verdict game object
       verdictGameObject.SetActive(false);

        //Set moves to 0
        moveTracker = 0;

        //Set the game on
        GameOn(true);
    }

    public string GetPlayersMark()
    {
        return playerMarker;
    }

    public void EndTurn()
    {
        //Increment the move trackker after every turn
        moveTracker++;

        //All game logic & all the possibilities of winning.
        if (XO_texts[0].text == playerMarker && XO_texts[1].text == playerMarker && XO_texts[2].text == playerMarker)
        {
            Verdict(playerMarker);
        }

        if (XO_texts[3].text == playerMarker && XO_texts[4].text == playerMarker && XO_texts[5].text == playerMarker)
        {
            Verdict(playerMarker);
        }

        if (XO_texts[6].text == playerMarker && XO_texts[7].text == playerMarker && XO_texts[8].text == playerMarker)
        {
            Verdict(playerMarker);
        }

        if (XO_texts[0].text == playerMarker && XO_texts[3].text == playerMarker && XO_texts[6].text == playerMarker)
        {
            Verdict(playerMarker);
        }

        if (XO_texts[1].text == playerMarker && XO_texts[4].text == playerMarker && XO_texts[7].text == playerMarker)
        {
            Verdict(playerMarker);
        }

        if (XO_texts[2].text == playerMarker && XO_texts[5].text == playerMarker && XO_texts[8].text == playerMarker)
        {
            Verdict(playerMarker);
        }

        if (XO_texts[0].text == playerMarker && XO_texts[4].text == playerMarker && XO_texts[8].text == playerMarker)
        {
            Verdict(playerMarker);
        }

        if (XO_texts[2].text == playerMarker && XO_texts[4].text == playerMarker && XO_texts[6].text == playerMarker)
        {
            Verdict(playerMarker);
        }

        //Tie game if all move tracker hits 9
        if (moveTracker >= 9)
        {
            Verdict("tie");
        }

        SwapTurn();

    }

    void SwapTurn()
    {
        //If player X goes, make it player O turn
        if(playerMarker == "X")
        {
            playerMarker = "O";
        }
        //If player O goes, make it player X turn
        else if(playerMarker == "O")
        {
            playerMarker = "X";
        }
    }

    void Verdict(string players)
    {
        //Set the game off
        GameOn(false);

        if (players == "tie")
        {
            SetVerict("Tie Game!");
        }
        //If its not a tie, display the winners marker 
        else
        {
            SetVerict(players + " Wins!");
        }      
    }

    void SetVerict(string verdictText)
    {
        //Turn on the game object
        verdictGameObject.SetActive(true);
        gameVerdict.text = verdictText;
    }

    //Toggle the game on or off 
    void GameOn(bool toggle)
    {
        for (int i = 0; i < XO_texts.Length; i++)
        {
            XO_texts[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}
