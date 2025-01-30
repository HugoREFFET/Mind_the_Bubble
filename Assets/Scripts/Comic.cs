using System;
using UnityEngine;

public class Comic : MonoBehaviour
{
    public Bubble[] bubbles;

    public bool Filled()
    {
        foreach (Bubble b in bubbles)
        {
            if (b.bubbleText == "")
            {
                return false;
            }
        }
        return true;
    }

    public void Erase()
    {
        foreach (Bubble b in bubbles)
        {
            b.inputField.text = "";
        }
    }
}
