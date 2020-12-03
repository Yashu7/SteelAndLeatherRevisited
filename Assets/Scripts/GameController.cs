using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   #region fields and properties
   public int gold = 50;
   public int leather = 30;
   public int steel = 30;
   public int fame = 0;
   private Vector3 leftSlot = new Vector3(-1.5F,2,0);
   private Vector3 rightSlot =  new Vector3(1.5F,2,0);
   
   public GameObject[] armors = new GameObject[2];
   public Transform leftArmor;
   public Transform rightArmor;
   public GameObject clickedObject;
   #endregion

   #region Unity Methods
   public void Start()
   {
       EventsBroker.ReturnClick += AssignObject;
       EventsBroker.ClickedForgeButton += Forge;
       EventsBroker.ClickedBuyLeatherButton += BuyLeather;
       EventsBroker.ClickedBuySteelButton += BuySteel;
       
       leftArmor = InstatiateNewArmor(armors[0],leftSlot);
       rightArmor = InstatiateNewArmor(armors[1],rightSlot);

       CalculatePoints();

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
        if((gold-5)< 0) return;
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
       EventsBroker.CallUpdateFame(fame);
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
           fame += 10;
           Destroy(leftArmor.gameObject);
           leftArmor = InstatiateNewArmor(armors[0],leftSlot);
          
           
       }
       if(rightArmor.childCount <= 1)
       {
           gold += 50;
           fame += 10;
           Destroy(rightArmor.gameObject);
           rightArmor = InstatiateNewArmor(armors[1],rightSlot);
            
       }
   }
   #endregion
}
