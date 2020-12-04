using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    public Text steelAmount;
    public Text leatherAmount;
    public Text goldAmount;
    public Text fameAmount;
    public Text leftTimer;
    public Text rightTimer;

    void Start()
    {
        EventsBroker.UpdateFame += UpdateFame;
        EventsBroker.UpdateGold += UpdateGold;
        EventsBroker.UpdateLeather += UpdateLeather;
        EventsBroker.UpdateSteel += UpdateSteel;
        EventsBroker.UpdateLeftTimer += UpdateLeftTimer;
        EventsBroker.UpdateRightTimer += UpdateRightTimer;

    }
    private void UpdateLeftTimer(int timer)
    {
        leftTimer.text = timer.ToString();
       
    }
    private void UpdateRightTimer(int timer)
    {
      
        rightTimer.text = timer.ToString();
    }
    private void UpdateGold(int amount)
    {
        goldAmount.text = amount.ToString();
    }
    private void UpdateFame(int amount)
    {
        fameAmount.text = amount.ToString();
    }
    private void UpdateLeather(int amount)
    {
        leatherAmount.text = amount.ToString();
    }
    private void UpdateSteel(int amount)
    {
        steelAmount.text = amount.ToString();
    }

}
