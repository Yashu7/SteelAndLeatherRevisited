using UnityEngine;
public class ArmorPart : MonoBehaviour, IPart
{
    
    public int SteelCost {get;set;}
    public int LeatherCost{get;set;}
    
    public int InitializeCost()
    {
        return Random.Range(1,5);
    }

    void Start()
    {
        SteelCost = InitializeCost();
        LeatherCost = InitializeCost();
    }

    
    
}
