using System;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Workshop : MonoBehaviour
{
    
    public float maxWorkers = 1;
    public float addWorkerCost = 100;
    public float addWorkerScale = 2;
    public float upgradeCapacityCost = 200;
    public float upgradeCapacityScale = 2;
    public Player player;
    public TextMeshProUGUI inputWorkshopStateText;
    public TextMeshProUGUI inputUpgradeCostText;
    public int workersCount = 0;
    
    private bool workergood;
    private Text workshopStateText;
    private Text upgradeCostText;
    public bool addWorker()
    {
        workergood = player.money >= addWorkerCost;
        if (player.money >= addWorkerCost)
        {
            workergood = workersCount < maxWorkers;
            if (workergood)
            {
                player.money -= addWorkerCost;
                workersCount++;
                addWorkerCost = addWorkerCost * addWorkerScale;

            }
            else
            {
                Debug.Log("Place insuffisante");
            }
        }
        else
        {
            Debug.Log("Not enough money");
        }

        return workergood;
    }

    public void upgradeCapacity()
    {
        if (player.money >= upgradeCapacityCost)
        {
            maxWorkers=maxWorkers*upgradeCapacityScale;
            player.money -= upgradeCapacityCost;
            upgradeCapacityCost = upgradeCapacityCost * upgradeCapacityScale;
        }
        else
        {
            Debug.Log("Not enough money");
        }

    }

    void Start()
    {
        workshopStateText = new Text() { dynaText = inputWorkshopStateText };
        upgradeCostText = new Text() { dynaText = inputUpgradeCostText };

        
    }
    void Update()
    {
        workshopStateText.SetText(workersCount.ToString() + "/" + maxWorkers.ToString() + " Employees");
        upgradeCostText.SetText("Cost: " + upgradeCapacityCost.ToString());
    }
}
