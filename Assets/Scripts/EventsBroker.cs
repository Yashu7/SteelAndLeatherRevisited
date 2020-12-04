using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventsBroker
{
    #region Custom Delegates
    public delegate void ObjectClicked(GameObject obj);
    public delegate void UpdateUI(int amount);
    public delegate void PassObject<T>(T Tobj);
    #endregion
   
    #region Events
    public static event ObjectClicked ReturnClick;
    public static event Action ClickedForgeButton;
    public static event Action ClickedBuySteelButton;
    public static event Action ClickedBuyLeatherButton;
    public static event UpdateUI UpdateFame;
    public static event UpdateUI UpdateGold;
    public static event UpdateUI UpdateSteel;
    public static event UpdateUI UpdateLeather;
    public static event PassObject<GameObject> ArmorTimesUp;

    #endregion
  
    #region Assign Game Points To UI delegats

    public static void CallUpdateFame(int amount)
    {
        if(UpdateFame != null)
       
            UpdateFame(amount);
        
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

    #endregion
}