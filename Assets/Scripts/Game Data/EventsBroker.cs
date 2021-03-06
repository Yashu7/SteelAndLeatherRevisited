﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventsBroker
{
    #region Custom Delegates
    public delegate void ObjectClicked(GameObject obj);
    public delegate void UpdateUI(int amount);
    public delegate void PassObject<T>(T Tobj);
    public delegate void PassTwoObjects<T,T2>(T obj,T2 obj2);

    
    #endregion
   
    #region Events
    public static event ObjectClicked ReturnClick;
    public static event Action ClickedForgeButton;
    public static event Action ClickedBuySteelButton;
    public static event Action ClickedBuyLeatherButton;
    public static event UpdateUI UpdateGuildPoints;
    public static event UpdateUI UpdateGold;
    public static event UpdateUI UpdateSteel;
    public static event UpdateUI UpdateLeather;
    public static event UpdateUI UpdateLeftTimer;
    public static event UpdateUI UpdateRightTimer;
    public static event PassTwoObjects<GameObject, int> CheckTimer;
    public static event PassObject<GameObject> ArmorTimesUp;
    public static event Action OnGameOver;
    public static event Action OnCreateUser;

   

    #endregion
  
    #region Game Flow Control
    public static void CallOnGameOver()
    {
        if(OnGameOver != null)
        OnGameOver();
    }
    public static void CallCreateUser()
    {
        if(OnCreateUser != null)
        OnCreateUser();
    }
    
    #endregion

    #region Assign Game Points To UI delegats

    public static void CallUpdateGuildPoints(int amount)
    {
        if(UpdateGuildPoints != null)
       
            UpdateGuildPoints(amount);
        
    }
    public static void CallUpdateGold(int amount)
    {
        if(UpdateGold != null)
       
            UpdateGold(amount);
        
    }
    public static void CallUpdateSteel(int amount)
    {
        if(UpdateSteel != null)
       
            UpdateSteel(amount);
        
    }
    public static void CallUpdateLeather(int amount)
    {
        if(UpdateLeather != null)
       
            UpdateLeather(amount);
        
    }
    #endregion
   
    #region Raycast2d Click
    public static void CallReturnClick(GameObject obj)
    {
        if(ReturnClick != null)
        ReturnClick(obj);
    }
    #endregion
   
    #region UI Buttons
    public static void CallClickedForgeButton()
    {
        if(ClickedForgeButton != null)
        ClickedForgeButton();
    }
     public static void CallClickedBuySteelButton()
   {
       if(ClickedBuySteelButton != null)
       ClickedBuySteelButton();
   }
   public static void CallClickedBuyLeatherButton()
   {
       if(ClickedBuyLeatherButton != null)
       ClickedBuyLeatherButton();
   }
   #endregion

    #region Armor Action
    public static void CallArmorTimesUp(GameObject armor)
    {
        if(ArmorTimesUp != null)
        ArmorTimesUp(armor);
        
    }
    public static void CallUpdateUiLeftTimer(int timer)
    {
        if(UpdateLeftTimer != null)
        {
            UpdateLeftTimer(timer);
        }
    }
     public static void CallUpdateUiRightTimer(int timer)
    {
        if(UpdateRightTimer != null)
        {
            UpdateRightTimer(timer);
        }
    }
    public static void CallCheckTimer(GameObject obj, int i)
     {
        if(CheckTimer != null)
        {
            CheckTimer(obj, i);
        }
    }
  

    #endregion
}