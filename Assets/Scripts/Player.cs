using UnityEngine;

public class Player : MonoBehaviour
{
    public float money=0;
    public Collection collection;
    public Library library;
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
        if ((collectionIndex <= library.collections.Count-1) == false)
        {
            library.Renew();
        }
        collectionIndex += 1;
        collection = library.collections[collectionIndex-1];
        
    }
    
}
