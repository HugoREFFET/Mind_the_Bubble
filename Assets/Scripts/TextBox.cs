using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    public TextMeshProUGUI text;
    public RectTransform rect;
    public string state="Idle";

    private float stayedFor=0f;

    public void Update()
    {
        if (rect.anchoredPosition.y >= 60f)
        {
            state = "Idle";
            stayedFor += Time.deltaTime;
        }        
        if (stayedFor >= 1)
        {
            state = "GoingDown";
        }
        
        if (state == "GoingUp")
        {
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + (500f*Time.deltaTime));
        }
        else if (state == "GoingDown")
        {
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y - (300f*Time.deltaTime));
        }
        else if (rect.anchoredPosition.y <= -100f)
        {
            state = "Idle";
            
        }
    }

    public void NewText(string newText)
    {
        text.text = newText;
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -130f);
        state = "GoingUp";
        stayedFor = 0f;
    }
}
