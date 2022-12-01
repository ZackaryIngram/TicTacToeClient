using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using UnityEditor.MemoryProfiler;
using UnityEditor.PackageManager;
using UnityEngine.Networking;

public class Register : MonoBehaviour
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

    public InputField usernameInput;
    public InputField passwordInput;
    public Button registerButton;
    public Button goToLoginButton;

    ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(WriteStuffToFile);
        goToLoginButton.onClick.AddListener(GoToLoginScene);

        //Check if you have the file, if not create one.
        if (File.Exists(Application.dataPath + "/accountInfo.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/accountInfo.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/accountInfo.txt", "");
        }

    }

    void GoToLoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }


    void WriteStuffToFile()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/accountInfo.txt"));
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(usernameInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Username '{usernameInput.text}' already exists");
        }
        else
        {
            credentials.Add(usernameInput.text + ":" + passwordInput.text);
            File.WriteAllLines(Application.dataPath + "/accountInfo.txt", (String[])credentials.ToArray(typeof(string)));
            //Send to server
            SendMessageToHost(ClientToServerSignifiers.CreateAccount + "," + usernameInput.text + "," + passwordInput.text);
            Debug.Log("Account Registered");
        }
    }

    public void SendMessageToHost(string msg)
    {
        byte[] buffer = Encoding.Unicode.GetBytes(msg);
        NetworkTransport.Send(hostID, connectionID, reliableChannelID, buffer, msg.Length * sizeof(char), out error);
    }


}