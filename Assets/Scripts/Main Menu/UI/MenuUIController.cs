using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public string userName = "";

    public void AssignUsername(string _userName)
    {
        userName = _userName;
    }

    public void SaveUsername()
    {
        User.Set(userName);
         SceneManager.LoadScene(1);
    }

    void Start()
    {
        EventsBroker.OnCreateUser += SaveUsername;
    }
    void OnDisable()
    {
        EventsBroker.OnCreateUser -= SaveUsername;
    }
}
