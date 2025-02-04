using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float money=0;
    public int maxIndex = 0;
    public Collection collection;
    public TextBox textBox;
    public AudioSource audioSource;
    public AudioClip clickSound;
    public AudioClip cashSound;
    public AudioClip noSound;
    public AudioClip yaySound;
    public AudioClip jackpotSound;
    
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
        if (collectionIndex >= (library.collections.Count-1))
        {
            library.Renew();
        }
        collectionIndex += 1;
        collection = library.collections[collectionIndex-1];
        textBox.NewText("New Collection Unlocked !");
        if (collection.index > maxIndex)
        {
            maxIndex = collection.index;
        }
    }

    public void PlayClickSound()
    {
        audioSource.clip = clickSound;
        audioSource.Play(); 
    }
    public void PlayCashSound()
    {
        audioSource.clip = cashSound;
        audioSource.Play(); 
    }
    public void PlayNoSound()
    {
        audioSource.clip = noSound;
        audioSource.Play(); 
    }

    public void PlayYaySound()
    {
        audioSource.clip = yaySound;
        audioSource.Play();
    }

    public void PlayJackpotSound()
    {
        audioSource.clip = jackpotSound;
        audioSource.Play();
    }
    
}
