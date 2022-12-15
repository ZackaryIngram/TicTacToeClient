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

}
