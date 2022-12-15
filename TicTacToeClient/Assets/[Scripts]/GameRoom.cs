using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class GameRoom : MonoBehaviour
{
    int connectionID;
    int maxConnections = 1000;
    int reliableChannelID;
    int unreliableChannelID;
    int hostID;
    int socketPort = 5491;
    byte error;
    bool isConnected = false;
    int ourClientID;

    public GameObject gameRoomEnterButton;
    GameObject networkedClient;

    private void Start()
    {
        gameRoomEnterButton.GetComponent<Button>().onClick.AddListener(FindGameRoomButtonPressed);
    }

    private void FindGameRoomButtonPressed()
    {
       
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.AddToGameRoomQueue + "");
        SceneManager.LoadScene("TicTacToeScene");
    }

    private void ProcessRecievedMsg(string msg, int id)
    {
        Debug.Log("msg recieved = " + msg + ".  connection id = " + id);

        string[] csv = msg.Split(',');

        int signifier = int.Parse(csv[0]);

        if(signifier == ServerToClientSignifiers.loginSuccess)
        {
            SceneManager.LoadScene("GameRoomScene");
        }
        else if (signifier == ServerToClientSignifiers.GameSessionStarted)
        {
            SceneManager.LoadScene("TicTacToeScene");
        }
        else if(signifier == ServerToClientSignifiers.OpponentTicTacToePlay)
        {
            Debug.Log("Oppenent play");
        }

    }

}
