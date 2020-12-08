using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickController : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            RaycastHit hit;

           if(Physics.Raycast(ray,out hit))
           {
               EventsBroker.CallReturnClick(hit.collider.gameObject);
              
           }


        }
    }
   
}
