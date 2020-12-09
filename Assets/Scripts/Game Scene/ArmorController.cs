using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : MonoBehaviour
{
    public float timespan;
    
    void Start()
    {
        timespan = Random.Range(10,25);
    }
    void Update()
    {
        EventsBroker.CallCheckTimer(this.gameObject, (int)timespan);
        timespan -= Time.deltaTime;
        if(timespan <= 0) 
        {
            EventsBroker.CallArmorTimesUp(this.gameObject);
            
        }
    }
}
    
