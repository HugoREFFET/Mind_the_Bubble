using System;
using TMPro;
using UnityEngine;

public class PersonalizedComic : MonoBehaviour
{
    public TextMeshProUGUI button_text;

    public Comic comic;

    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;

    public GameObject selectionNumber_Prefab;

    public GameObject validateComicButton;

    private GameObject selectedComic1, selectedComic2, selectedComic3;
    private GameObject selectionNumber1, selectionNumber2, selectionNumber3;

    private int comicSelectedNumber = 1;

    private bool comics_collection_window_opened = false;

    private GameObject zone_comic1, zone_comic2, zone_comic3;

    private void Awake()
    {
        zone_comic1 = zone1.transform.GetChild(0).gameObject;
        zone_comic2 = zone2.transform.GetChild(0).gameObject;
        zone_comic3 = zone3.transform.GetChild(0).gameObject;
    }

    public void SelectComic(GameObject gameObjectClicked)
    {
        if (comicSelectedNumber == 1)
        {
            selectedComic1 = gameObjectClicked.transform.GetChild(0).gameObject;
            // Instantiate number as child of selectedComic1
            selectionNumber1 = Instantiate(selectionNumber_Prefab, selectedComic1.transform);
            selectionNumber1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = comicSelectedNumber.ToString();
        }
        else if (comicSelectedNumber == 2)
        {
            selectedComic2 = gameObjectClicked.transform.GetChild(0).gameObject;

            selectionNumber2 = Instantiate(selectionNumber_Prefab, selectedComic2.transform);
            selectionNumber2.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = comicSelectedNumber.ToString();
        }
        else if (comicSelectedNumber == 3)
        {
            selectedComic3 = gameObjectClicked.transform.GetChild(0).gameObject;

            selectionNumber3 = Instantiate(selectionNumber_Prefab, selectedComic3.transform);
            selectionNumber3.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = comicSelectedNumber.ToString();

            validateComicButton.SetActive(true);
        }
        else if (comicSelectedNumber > 3) 
        {
            Destroy(selectionNumber3);
            comicSelectedNumber = 3;

            selectedComic3 = gameObjectClicked.transform.GetChild(0).gameObject;

            selectionNumber3 = Instantiate(selectionNumber_Prefab, selectedComic3.transform);
            selectionNumber3.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = comicSelectedNumber.ToString();

            validateComicButton.SetActive(true);
        }

        comicSelectedNumber++;
    }

    public void ValidateComic()
    {
        // Destroy number as child of selectedComic1
        Destroy(selectionNumber1);
        Destroy(selectionNumber2);
        Destroy(selectionNumber3);

        Destroy(zone_comic1);
        Destroy(zone_comic2);
        Destroy(zone_comic3);

        zone_comic1 = Instantiate(selectedComic1, zone1.transform);
        zone_comic2 = Instantiate(selectedComic2, zone2.transform);
        zone_comic3 = Instantiate(selectedComic3, zone3.transform);

        comic.bubbles[0] = zone_comic1.transform.GetChild(1).gameObject.GetComponent<Bubble>();
        comic.bubbles[1] = zone_comic2.transform.GetChild(1).gameObject.GetComponent<Bubble>();
        comic.bubbles[2] = zone_comic3.transform.GetChild(1).gameObject.GetComponent<Bubble>();

        zone_comic1.transform.GetChild(1).gameObject.SetActive(true);
        zone_comic2.transform.GetChild(1).gameObject.SetActive(true);
        zone_comic3.transform.GetChild(1).gameObject.SetActive(true);

        comicSelectedNumber = 1;
        // setActive(false) validateComicButton
        validateComicButton.SetActive(false);

        Debug.Log("it worked ?");
    }

    public void OpenClose_collection(GameObject comics_Collection_Window)
    {
        comics_collection_window_opened = !comics_collection_window_opened;
        if (comics_collection_window_opened)
        {
            comics_Collection_Window.SetActive(true);
            button_text.text = "Close collection";
        }
        else 
        {
            comics_Collection_Window.SetActive(false);
            button_text.text = "Open collection";
        }
    }

    public void ScreenShot()
    {
        ScreenCapture.CaptureScreenshot("screenshot-" + DateTime.Now.ToString("yyyy-MM-dd-HH-ss") + ".png");
    }
}
