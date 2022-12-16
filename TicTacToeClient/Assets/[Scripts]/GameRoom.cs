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
    public GameObject networkedClient;

    private void Start()
    {
        gameRoomEnterButton.GetComponent<Button>().onClick.AddListener(FindGameRoomButtonPressed);

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
    }

    private void FindGameRoomButtonPressed()
    {     
        networkedClient.GetComponent<NetworkedClient>().SendMessageToHost(ClientToServerSignifiers.AddToGameRoomQueue + "");
        SceneManager.LoadScene("GameScene");
    }

}
