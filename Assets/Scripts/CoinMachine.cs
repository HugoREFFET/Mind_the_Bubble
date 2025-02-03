using UnityEngine;

public class CoinMachine : InterractableObject
{
    public float usualWin;
    public AudioSource audioSource;
    public AudioClip coinSound;
    public void Clicked()
    {
        audioSource.clip = coinSound;
        audioSource.Play(); 
        float randomInt = Random.Range(1, 1000);
        if (randomInt == 1)
        {
            player.WinMoney(1000);
            player.textBox.NewText("Jackpot !");
            player.PlayJackpotSound(); 
        }
        else
        {
            player.WinMoney(1);
        }

    }
}
