using TMPro;
using UnityEngine;
using System;
public class MoneyMultiplierButton : MonoBehaviour
{
    public float cost = 10;
    public float costScale = 1.8f;
    public float upgradeScale = 1.1f;
    public Player player;
    public TextMeshProUGUI inputMultiplierText;
    public TextMeshProUGUI inputCostText;
    
    private Text multiplierText;
    private Text costText;
    
    public void Activate()
    {
        if (cost <= player.money)
        {
            player.money -= cost;
            player.moneyMultiplier = player.moneyMultiplier * upgradeScale;
            cost = cost * costScale;
        }
        else
        {
            Debug.Log("Not enough money");  
        }
    }
    void Start()
    {
        multiplierText = new Text() { dynaText = inputMultiplierText };
        costText = new Text() { dynaText = inputCostText };
    }

    void Update()
    {
        multiplierText.SetText("X " + Math.Round(player.moneyMultiplier,1).ToString());
        costText.SetText("Cost: " + Math.Round(cost).ToString());
    }
}
