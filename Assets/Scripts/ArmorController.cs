using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : MonoBehaviour
{
    private float timespan = 10;
    private Vector3 position;
    void Start()
    {
        position = transform.position;
    }
    void Update()
    {
        timespan -= Time.deltaTime;
        if(timespan <= 0) 
        {
            EventsBroker.CallArmorTimesUp(this.gameObject);
            
        }
    }
}
    
