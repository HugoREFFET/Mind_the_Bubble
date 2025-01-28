using System;
using TMPro;
using UnityEngine;

public class MoreMoneyButton : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI inputMoneyAmount;
    public TMP_InputField blablaInputField;
    private Text moneyAmountText;
    

    void Start()
    {
        moneyAmountText = new Text(){dynaText = inputMoneyAmount};
    }
    public void Activate()
    {
        if (blablaInputField.text != "")
        {
            player.WinMoney(player.collection.value);
            blablaInputField.text = "";
        }
        else
        {
            Debug.Log("Type something");
        }
        
    }

    private void Update()
    {
        moneyAmountText.dynaText.SetText("Current Money: " + Math.Round(player.money).ToString());
    }
}


