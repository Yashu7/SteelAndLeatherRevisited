using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : MonoBehaviour
{
    public GameObject head, leftArm,rightArm,leftLeg,rightLeg;
    void Start()
    {
        head = transform.GetChild(4).gameObject;
        leftArm =  transform.GetChild(1).gameObject;
        rightArm  = transform.GetChild(2).gameObject;
        leftLeg =  transform.GetChild(0).gameObject;
        rightLeg =  transform.GetChild(3).gameObject;
    }
}
    
