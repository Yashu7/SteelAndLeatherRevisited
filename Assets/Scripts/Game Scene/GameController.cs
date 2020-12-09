using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class GameController : MonoBehaviour
{
   #region fields and properties
   public Text textResponse;
   public int gold = 50;
   public int leather = 30;
   public int steel = 30;
   public int guildPoints = 0;
   private Vector3 leftSlot = new Vector3(-1.5F,2,0);
   private Vector3 rightSlot =  new Vector3(1.5F,2,0);
   
   public GameObject armor;
   public Transform leftArmor;
   public Transform rightArmor;
   public GameObject clickedObject;
   public float timer;
   #endregion

   #region Unity Methods
    void Start()
   {
      
       
       EventsBroker.ReturnClick += AssignObject;
       EventsBroker.ClickedForgeButton += Forge;
       EventsBroker.ClickedBuyLeatherButton += BuyLeather;
       EventsBroker.ClickedBuySteelButton += BuySteel;
       EventsBroker.ArmorTimesUp += ResetArmor;
       EventsBroker.CheckTimer += ValidateTimer;
       
       
       
       leftArmor = InstatiateNewArmor(armor,leftSlot);
       rightArmor = InstatiateNewArmor(armor,rightSlot);

       CalculatePoints();

   }
  
   public void OnDisable()
   {
        EventsBroker.ReturnClick -= AssignObject;
       EventsBroker.ClickedForgeButton -= Forge;
       EventsBroker.ClickedBuyLeatherButton -= BuyLeather;
       EventsBroker.ClickedBuySteelButton -= BuySteel;
       EventsBroker.ArmorTimesUp -= ResetArmor;
       EventsBroker.CheckTimer -= ValidateTimer;
   }
    
   #endregion
   #region My Methods
   //Assign clicked gameobject.
   private void AssignObject(GameObject obj)
   {
       clickedObject = obj;
   }
   private Transform InstatiateNewArmor(GameObject armor,Vector3 pos)
   {
      
       var Armor = Instantiate(armor);
       Armor.transform.position = pos;
       return Armor.transform;
   }
   private void BuyLeather()
   {
       if((gold-5)< 0) return;
       gold -= 5;
       leather += 1;
       CalculatePoints();
   } 
   private void BuySteel()
   {
        if(CheckIfLost(5)) return;
       gold -= 5;
       steel += 1;
       CalculatePoints();
   } 
   private void Forge()
   {
       if(clickedObject == null) return;
       var partCost = clickedObject.GetComponent<IPart>();
       if(ValidatePayment(partCost))
       {
       steel -= partCost.SteelCost;
       leather -= partCost.LeatherCost;
       }
       else{
           return;
       }
       
       Destroy(clickedObject);
       CheckIfWholeArmorRepaired();
       CalculatePoints();
   } 
   private void CalculatePoints()
   {
       EventsBroker.CallUpdateLeather(leather);
       EventsBroker.CallUpdateGuildPoints(guildPoints);
       EventsBroker.CallUpdateGold(gold);
       EventsBroker.CallUpdateSteel(steel);
   }
   private bool ValidatePayment(IPart part)
   {
        if((steel - part.SteelCost) < 0) return false;
        if((leather - part.LeatherCost) < 0) return false;
        return true;
   } 

   private void CheckIfWholeArmorRepaired()
   {
    if(leftArmor.childCount <= 1)
       {
           gold += 50;
           guildPoints += 10;
           Destroy(leftArmor.gameObject);
           leftArmor = InstatiateNewArmor(armor,leftSlot);
          
           
       }
       if(rightArmor.childCount <= 1)
       {
           gold += 50;
           guildPoints += 10;
           Destroy(rightArmor.gameObject);
           rightArmor = InstatiateNewArmor(armor,rightSlot);
            
       }
   }
   public void ResetArmor(GameObject gameObject)
   {
       if(!CheckIfLost(15))
       {
      
        gold -= 15;
        guildPoints -= 5;
        if(leftArmor.transform.position == gameObject.transform.position)
        {
        Destroy(gameObject);
        leftArmor = InstatiateNewArmor(armor,leftSlot);
        }
        if(rightArmor.transform.position == gameObject.transform.position)
        {
        Destroy(gameObject);
        rightArmor = InstatiateNewArmor(armor,rightSlot);
        }
        CalculatePoints();
       }
      
   }
   public void ValidateTimer(GameObject gameObject, int timer)
   {
       if(leftArmor.transform.position == gameObject.transform.position)
        {
            EventsBroker.CallUpdateUiLeftTimer(timer);
        }
        if(rightArmor.transform.position == gameObject.transform.position)
        {
            EventsBroker.CallUpdateUiRightTimer(timer);
        }
   }
   public  void SaveHighPointsToApi()
   {
       HighPointsModel model = new HighPointsModel()
           {
               Id = 999,
               PlayerID = SystemInfo.deviceUniqueIdentifier,
               HighPoints = guildPoints,
               Username = User.Get()
               
           };
        string response = "";
         
        response = ApiConsumer.InsertHighScore(model);
        textResponse.text = response;
        Debug.Log(response);
   }
   private bool CheckIfLost(int amount)
   {
       if((gold - amount) <= 0) 
       {
            SaveHighPointsToApi();
            EventsBroker.CallOnGameOver();
            Destroy(leftArmor.gameObject);
            Destroy(rightArmor.gameObject);
            Destroy(this.gameObject);
           
           return true;
       }
       return false;
       
   }
   #endregion
}
