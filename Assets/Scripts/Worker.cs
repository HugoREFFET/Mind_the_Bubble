using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Worker : InterractableObject
{
    public float speed=0.1f;
    public string name;
    public float upgradeCost = 100;
    public float upgradeCostScale = 1.5f;
    public float upgradeSpeedScale = 1.2f;
    public Workshop workshop;
    public TextMeshProUGUI inputValueText;
    public TextMeshProUGUI inputCostText;
    public Image tableColor;
    public Image bubbleImage;
    public TextMeshProUGUI bubbleText;
    public Image upgradeImage;
    
    private bool active, selected;
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
            costText.SetText(Math.Round(upgradeCost).ToString() + " to increase");
        }
        else
        {
            valueText.SetText("Available for "+ workshop.addWorkerCost);
            costText.SetText("Cost : " + Math.Round(workshop.addWorkerCost));
        }

        selected = IsSelected;
    }

    public void Upgrade()
    {
        if (player.money >= upgradeCost)
        {
            player.LoseMoney(upgradeCost);
            speed = speed * upgradeSpeedScale;
            upgradeCost = upgradeCost * upgradeCostScale;
            PlaySound();
        }
        else
        {
            player.textBox.NewText("Not enough money");
            player.PlayNoSound();
        }
    }

    private bool IsSelected => EventSystem.current.currentSelectedGameObject == gameObject;
    public void Selected()
    {
        if (selected)
        {
            if (!active && workshop.addWorker())
            {
                valueText.dynaText.fontSize = 22;
                tableColor.color = Color.white;
                active = true;
                images.Add(bubbleImage);
                images.Add(upgradeImage);
                texts.Add(bubbleText);
            }
            onHovered();
            StartCoroutine(Deselect());
        }
        else
        {
            selected = true;
        }
    }

    private IEnumerator Deselect()
    {
        yield return new WaitForSeconds(2f);
        onUnhovered();
        selected = false;
    }

    public void Clicked()
    {
        if (active)
        {
            player.PlayClickSound();
            Upgrade();
        }
    }
}