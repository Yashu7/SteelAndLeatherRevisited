using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour, IButton
{
     public Button button {get;set;}
    public void OnClickedButton()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
    void Start()
    {
        //Find it's button and assign action.
         button = transform.GetComponent<Button>();
        button.onClick.AddListener(OnClickedButton);
    }
}
