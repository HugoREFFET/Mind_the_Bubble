using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UpgradeCollectionButton : MonoBehaviour
{
    public float cost=15;
    public float costScale=1.5f;
    public Player player;
    public TextMeshProUGUI inputCollectionNumberText;
    public TextMeshProUGUI inputGoNextText;
    public TextMeshProUGUI inputGoPreviousText;
    
    private bool buyable=false;
    private Text collectionNumberText;
    private Text goNextText;
    private Text goPreviousText;
    


    void Start()
    {
        collectionNumberText = new Text() { dynaText = inputCollectionNumberText };
        goNextText = new Text() { dynaText = inputGoNextText };
        goPreviousText = new Text() { dynaText = inputGoPreviousText };
    }

    void Update()
    {
        collectionNumberText.SetText("Collection N."+player.collection.index.ToString() + " : " + Math.Round(player.collection.value).ToString() + " $ par comic" );
        if (player.collection.index >= player.maxIndex)
        {
            goNextText.SetText("Coût : " + Math.Round(cost).ToString());
            buyable = true;
        }
        else
        {
            goNextText.SetText("Suivant");
            buyable = false;
        }
        
        if (player.collection.index == 1)
        {
            goPreviousText.SetText("/");
        }
        else
        {
            goPreviousText.SetText("Précedent");
        }
    }
    public void GoPreviousCollection()
    {
        if (player.collection.index == 1)
        {
            player.PlayNoSound();
            player.textBox.NewText("Pas de collection précedente");
        }
        else
        {
            player.PlayClickSound();
            player.collection = player.library.collections[player.collection.index -2];
            player.drawingTable.ChangeDrawing();
        }
    }

    public void GoNextCollection()
    {
        if (buyable)
        {
            if (player.money > cost)
            { 
                player.PlayYaySound();
                player.LoseMoney(cost);
                player.ChangeCollection();
                cost = cost * costScale;
                player.drawingTable.ChangeDrawing();
            }
            else
            {
                player.PlayNoSound();
                player.textBox.NewText("Pas assez d'argent !");
            } 
        }
        else
        {
            player.PlayClickSound();
            player.collection = player.library.collections[player.collection.index];
            player.drawingTable.ChangeDrawing();
        }
    }
}
