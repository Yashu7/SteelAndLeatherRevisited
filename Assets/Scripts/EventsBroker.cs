using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventsBroker
{
    public delegate void ObjectClicked(GameObject obj);
    public static event ObjectClicked ReturnClick;
    public static event Action ClickedForgeButton;
    public delegate void UpdateUI(int a, int b, int c ,int d);
    public static event UpdateUI UpdateUIScores;

    public static void CallUpdateUIScores(int a, int b, int c, int d)
    {
        if(UpdateUIScores != null)
       
            UpdateUIScores(a,b,c,d);
        
    }
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