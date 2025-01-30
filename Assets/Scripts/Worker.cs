using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class Worker : InterractableObject
{
    
    public float speed=0.1f;
    public string name;
    public float upgradeCost = 100;
    public float upgradeCostScale = 1.5f;
    public float upgradeSpeedScale = 1.2f;
    public Player player;
    public Workshop workshop;
    public TextMeshProUGUI inputValueText;
    public TextMeshProUGUI inputCostText;
    public Image tableColor;
    public Image bubbleImage;
    public TextMeshProUGUI bubbleText;
    public Image upgradeImage;
    
    private bool active = false;
    private Button button;
    private TextMeshProUGUI texte;
    private Text valueText;
    private Text costText;
    private Transform childTransform;

    public void Start()
    {
        valueText = new Text { dynaText = inputValueText };
        costText = new Text { dynaText = inputCostText };
    }

    void Update()
    {
        if (active)
        {
            player.WinMoney(player.collection.value*speed*Time.deltaTime);
            
            valueText.SetText(Math.Round(player.collection.value*speed*player.moneyMultiplier,2).ToString()+ " /s");
            costText.SetText(Math.Round(upgradeCost).ToString() + " to upgrade");
        }
        else
        {
            valueText.SetText("Availble for "+ workshop.addWorkerCost);
            costText.SetText("Cost : " + Math.Round(workshop.addWorkerCost));
        }

        
    }

    public void Upgrade()
    {

        if (player.money >= upgradeCost)
        {
            player.LoseMoney(upgradeCost);
            speed = speed * upgradeSpeedScale;
            upgradeCost = upgradeCost * upgradeCostScale;
        }
        else
        {
            player.textBox.NewText("Not enough money");
        }
    }

    public void Clicked()
    {
        if (active)
        {
            Upgrade();
        }
        else
        {
            if (workshop.addWorker())
            {
                tableColor.color=Color.white;
                active = true;
                images.Add(bubbleImage);
                images.Add(upgradeImage);
                texts.Add(bubbleText);
                onHovered();
                
            }
        }
        
    }
}
