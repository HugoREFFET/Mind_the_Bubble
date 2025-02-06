using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public CanvasGroup[] canvas;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

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

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

}
