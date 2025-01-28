using System;
using TMPro;
using UnityEngine;


public class Text : MonoBehaviour
{
    public TextMeshProUGUI dynaText;

    public void SetText(string text)
    {
        dynaText.text = text;
    }
}
