using System;
using TMPro;
using UnityEngine;

public class MoreMoneyButton : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI inputMoneyAmount;
    public DrawingTable table;
    private Text moneyAmountText;
    

    void Start()
    {
        moneyAmountText = new Text(){dynaText = inputMoneyAmount};
    }
    public void Activate()
    {
        Comic comicComponent = table.drawing.GetComponent<Comic>();
        if (comicComponent.Filled())
        {
            player.WinMoney(player.collection.value);
            comicComponent.Erase();
            player.drawingTable.ChangeDrawing();
        }
        else
        {
            player.textBox.NewText("Fill the bubbles to sell your comic");
        }
        
    }

    void Update()
    {
        moneyAmountText.dynaText.SetText( Math.Round(player.money).ToString() + "$");
    }
}


