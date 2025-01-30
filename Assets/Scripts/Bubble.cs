using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Bubble : MonoBehaviour
{
    public TMP_InputField inputField;
    public string bubbleText;
    public TextMeshProUGUI bubbleTextSize;
    public TMP_InputField inputField2;

    private void Update()
    {
        bubbleText = inputField.text;
        if (bubbleText.Length > 0)
        {
            bubbleTextSize.fontSize = ((100*inputField2.lineLimit) / (bubbleText.Length+3)) + 20;
        }
        
    }
}
