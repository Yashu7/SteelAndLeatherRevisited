using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventsBroker
{
    public delegate void ObjectClicked(GameObject obj);
    public static event ObjectClicked ReturnClick;
    public static event Action ClickedForgeButton;

    public static void CallReturnClick(GameObject obj)
    {
        if(ReturnClick != null)
        ReturnClick(obj);
    }
    public static void CallClickedForgeButton()
    {
        if(ClickedForgeButton != null)
        ClickedForgeButton();
    }

}