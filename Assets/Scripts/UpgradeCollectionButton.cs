using TMPro;
using UnityEngine;
using System;
public class UpgradeCollectionButton : MonoBehaviour
{
    public float cost=15;
    public float costScale=1.5f;
    public Player player;
    public TextMeshProUGUI inputCollectionNumberText;
    public TextMeshProUGUI inputCostText;
    
    private Text collectionNumberText;
    private Text costText;
    
    public void Activate()
    {
        if (player.money > cost)
        { 
            player.money -= cost;
            player.ChangeCollection();
            cost = cost * costScale;
            Debug.Log("Collection changed");
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    void Start()
    {
        collectionNumberText = new Text() { dynaText = inputCollectionNumberText };
        costText = new Text() { dynaText = inputCostText };
    }

    void Update()
    {
        collectionNumberText.SetText("Collection N."+player.collectionIndex.ToString());
        costText.SetText("Cost: " + Math.Round(cost).ToString());
    }
}
