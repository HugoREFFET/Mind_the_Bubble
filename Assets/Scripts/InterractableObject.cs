using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterractableObject : MonoBehaviour
{
    public List<Image> images;
    public List<TextMeshProUGUI> texts;
    public Player player;

    public void onHovered()
    {
        foreach (Image image in images)
            image.enabled = true;
        foreach (TextMeshProUGUI text in texts)
            text.enabled = true;
        
    }
    public void onUnhovered()
    {
        foreach (Image image in images)
            image.enabled = false;
        foreach (TextMeshProUGUI text in texts)
            text.enabled = false;
        
    }

    public void PlaySound()
    {
        player.PlayClickSound();
    }
}
