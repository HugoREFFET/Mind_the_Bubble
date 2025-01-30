using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public TMP_InputField inputField;
    public string bubbleText;

    private void Update()
    {
        bubbleText = inputField.text;
    }
}
