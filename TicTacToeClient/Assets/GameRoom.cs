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
    public InputField gameRoom;
  
    ArrayList rooms;

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.dataPath + "/gameRoom.txt"))
        {
            rooms = new ArrayList(File.ReadAllLines(Application.dataPath + "/gameRoom.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/gameRoom.txt", "");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToLockedUIState()
    {
      //  SceneManager.LoadScene("LockedUIScene");
    }

    void WriteDataToGameRoomFile()
    {
        bool gameRoomFileExists = false;

        rooms = new ArrayList(File.ReadAllLines(Application.dataPath + "/gameRoom.txt"));
        foreach (var i in rooms)
        {
            if (i.ToString().Contains(gameRoom.text))
            {
                gameRoomFileExists = true;
                break;
            }
        }

        if (gameRoomFileExists)
        {
            Debug.Log($"Username '{gameRoom.text}' already exists");
        }
        else
        {
            rooms.Add(gameRoom.text);
            File.WriteAllLines(Application.dataPath + "/gameRoom.txt", (String[])rooms.ToArray(typeof(string)));
            Debug.Log("Account Registered");
        }
    }

}
