using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour
{
    public Text steelAmount;
    public Text leatherAmount;
    public Text goldAmount;
    public Text guildPointsAmount;
    public Text leftTimer;
    public Text rightTimer;
    public GameObject gameOverUI;

    void Start()
    {
        EventsBroker.UpdateGuildPoints += UpdateGuildPoints;
        EventsBroker.UpdateGold += UpdateGold;
        EventsBroker.UpdateLeather += UpdateLeather;
        EventsBroker.UpdateSteel += UpdateSteel;
        EventsBroker.UpdateLeftTimer += UpdateLeftTimer;
        EventsBroker.UpdateRightTimer += UpdateRightTimer;
        EventsBroker.OnGameOver += TurnOffUi;

    }
    public void OnDisable()
    {
        EventsBroker.UpdateGuildPoints -= UpdateGuildPoints;
        EventsBroker.UpdateGold -= UpdateGold;
        EventsBroker.UpdateLeather -= UpdateLeather;
        EventsBroker.UpdateSteel -= UpdateSteel;
        EventsBroker.UpdateLeftTimer -= UpdateLeftTimer;
        EventsBroker.UpdateRightTimer -= UpdateRightTimer;
        EventsBroker.OnGameOver -= TurnOffUi;
    }
    private void TurnOffUi()
    {
        List<Transform> items = new List<Transform>();
        items = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        items.Remove(this.transform);
        foreach(var t in items)
        {
            t.gameObject.SetActive(false);
        }
        gameOverUI.SetActive(true);
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
    private void UpdateGuildPoints(int amount)
    {
        guildPointsAmount.text = amount.ToString();
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
