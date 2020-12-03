using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   #region fields and properties
   public int gold;
   public int leather;
   public int steel;
   public int fame;
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
       gold -= 10;
       leather += 5;
       CalculatePoints();
   } 
   private void BuySteel()
   {
       gold -= 10;
       steel += 5;
       CalculatePoints();
   } 
   private void Forge()
   {
       if(clickedObject == null) return;
       var partCost = clickedObject.GetComponent<IPart>();
       steel -= partCost.SteelCost;
       leather -= partCost.LeatherCost;
       
       Destroy(clickedObject);
       
       
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
       CalculatePoints();
       
   } 
   private void CalculatePoints()
   {
       EventsBroker.CallUpdateLeather(leather);
       EventsBroker.CallUpdateFame(fame);
       EventsBroker.CallUpdateGold(gold);
       EventsBroker.CallUpdateSteel(steel);
   }
   #endregion
}
