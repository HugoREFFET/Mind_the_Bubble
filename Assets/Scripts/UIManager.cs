using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasGroup[] canvas;
    

    public void SwitchCanvas(int canvasNumber)
    {
        foreach (CanvasGroup canvaGrp in canvas)
        {
            canvaGrp.alpha = 0;
            canvaGrp.interactable = false;
            canvaGrp.blocksRaycasts = false;
        }
        canvas[canvasNumber].alpha= 1;
        canvas[canvasNumber].interactable = true;
        canvas[canvasNumber].blocksRaycasts = true;
    }
}
