using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Workshop : MonoBehaviour
{
    
    public float maxWorkers = 1;
    public float addWorkerCost = 100;
    public float addWorkerScale = 2;
    public float upgradeCapacityCost = 1000;
    public float upgradeCapacityScale = 2;
    public Player player;
    public TextMeshProUGUI inputUpgradeCostText;
    public int workersCount = 0;
    public Worker[] workers;
    
    private bool workergood;
    private Text workshopStateText;
    private Text upgradeCostText;
    public bool addWorker()
    {
       
        workergood = player.money >= addWorkerCost;
        if (workergood)
        {
            workergood = workersCount < maxWorkers;
            if (workergood)
            {
                player.LoseMoney(addWorkerCost);
                workersCount++;
                addWorkerCost = addWorkerCost * addWorkerScale;
                player.textBox.NewText("New employee hired !");
                player.PlayYaySound();
            }
            else
            {
                player.textBox.NewText("Insufficient workshop capacity");
                player.PlayNoSound();
            }
        }
        else
        {
            player.textBox.NewText("Not enough money !");
            player.PlayNoSound();
        }

        return workergood;
    }

    public void upgradeCapacity()
    {
        if (maxWorkers < 5)
        {
            if (player.money >= upgradeCapacityCost)
            {
                maxWorkers=maxWorkers+2;
                player.LoseMoney(upgradeCapacityCost);
                upgradeCapacityCost = upgradeCapacityCost * upgradeCapacityScale;
                int x = Mathf.RoundToInt(maxWorkers); 

                for (int i = 0; i < x; i++)
                {
                    workers[i].GameObject().SetActive(true);
                }
                player.textBox.NewText("Increased workshop capacity");
                player.PlayYaySound();
            }
            else
            {
                player.PlayNoSound();
                player.textBox.NewText("Not enough money !");
            }
        }
        else
        {
            player.textBox.NewText("Maximum capacity reached");
            player.PlayNoSound();
        }

    }

    void Start()
    {
        upgradeCostText = new Text() { dynaText = inputUpgradeCostText };
    }
    void Update()
    {
        if (maxWorkers >= 5)
        {
            upgradeCostText.SetText("Maximum");
        }
        else
        {
            upgradeCostText.SetText("Cost: " + upgradeCapacityCost.ToString());
        }
        
    }
}
