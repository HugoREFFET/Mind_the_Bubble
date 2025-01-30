using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float money=0;
    public int maxIndex = 0;
    public Collection collection;
    public TextBox textBox;

    
    public Library library;
    public DrawingTable drawingTable;
    public int collectionIndex = 1;
    public float moneyMultiplier = 1.0f;
    

    public void WinMoney(float amount)
    {
        money += amount*moneyMultiplier;
    }    
    public void LoseMoney(float amount)
    {
        money -= amount;
    }

    public void ChangeCollection()
    {
        if (collectionIndex == (library.collections.Count))
        {
            library.Renew();
        }
        collectionIndex += 1;
        collection = library.collections[collectionIndex-1];
        textBox.NewText("New collection unlocked !");
        if (collection.index > maxIndex)
        {
            maxIndex = collection.index;
        }
    }



}
