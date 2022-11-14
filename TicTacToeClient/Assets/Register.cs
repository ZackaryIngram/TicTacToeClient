using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{

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
            Debug.Log("Account Registered");
        }
    }


}