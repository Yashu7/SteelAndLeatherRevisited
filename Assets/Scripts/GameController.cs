using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   #region fields and properties
   public int gold;
   public int leather;
   public int steel;
   private Vector3 leftSlot = new Vector3(-1.5F,2,0);
   private Vector3 rightSlot =  new Vector3(1.5F,2,0);
   
   public GameObject armor;
   public GameObject clickedObject;
   #endregion

   #region Unity Methods
   public void Start()
   {
       EventsBroker.ReturnClick += AssignObject;
       EventsBroker.ClickedForgeButton += Forge;
      
       var Armor = Instantiate(armor);
       Armor.transform.position = leftSlot;
      
       var Armor2 = Instantiate(armor);
       Armor2.transform.position = rightSlot;

   }
   #endregion
   #region My Methods
   //Assign clicked gameobject.
   private void AssignObject(GameObject obj)
   {
       clickedObject = obj;
   }
   private void InstatiateNewArmor()
   {

   }
   private void Forge()
   {
       if(clickedObject == null) return;
       Debug.Log("Repaired "+clickedObject.name);
   } 
   #endregion
}
