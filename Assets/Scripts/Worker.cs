using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Worker : MonoBehaviour
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
    
    private bool active = false;
    private float progress;
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
            progress += (Time.deltaTime*speed);
            while (progress >= 1)
            {
                progress -= 1;
                player.WinMoney(player.collection.value);
            } 
            valueText.SetText(Math.Round(player.collection.value*player.moneyMultiplier*speed,2).ToString()+ " /s");
            costText.SetText(Math.Round(upgradeCost).ToString() + " to upgrade");
        }
        else
        {
            valueText.SetText("");
            costText.SetText("Cost : " + Math.Round(workshop.addWorkerCost));
        }

        
    }

    public void Upgrade()
    {
        
        if (player.money >= upgradeCost)
        {
            player.money -= upgradeCost;
            speed = speed * upgradeSpeedScale;
            upgradeCost = upgradeCost * upgradeCostScale;
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    public void OnActivated()
    {
        if (workshop.addWorker())
        {
                    Debug.Log(active);
                    button=GetComponent<Button>();
                    button.onClick.RemoveAllListeners();
                    button.onClick.AddListener(Upgrade);
                    childTransform = transform.GetChild(0); 
                    GameObject child = childTransform.gameObject;
                    texte=child.GetComponent<TextMeshProUGUI>();
                    texte.text = name;
                    active = true;
                    Debug.Log(active);
        }
    }
}
