using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class TicTacToeManager : MonoBehaviour
{
    public GameObject makePlayButton;
    public GameObject networkedClient;

    private void Start()
    {
        makePlayButton.GetComponent<Button>().onClick.AddListener(FindMakePlayButtonPressed);
    }

    private void FindMakePlayButtonPressed()
    {

        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.TicTacToePlay + "");
        
    }
}
