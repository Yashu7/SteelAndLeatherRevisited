using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ForgeButton : MonoBehaviour, IButton
{
    public Button button {get;set;}
    public void OnClickedButton()
    {
        EventsBroker.CallClickedForgeButton();
    }
    void Start()
    {
        //Find it's button and assign action.
         button = transform.GetComponent<Button>();
        button.onClick.AddListener(OnClickedButton);
    }
    
    
}
