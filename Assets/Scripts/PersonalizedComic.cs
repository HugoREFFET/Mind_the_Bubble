using TMPro;
using UnityEngine;

public class PersonalizedComic : MonoBehaviour
{
    public TextMeshProUGUI button_text;

    private GameObject selectedZone;
    private GameObject selectedComic;
    private bool zoneIsSelected = false;
    private bool comics_collection_window_opened = false;

    public void SelectZone(GameObject gameObjectClicked)
    {
        Debug.Log("zone Clicked");
        selectedZone = gameObjectClicked;
        zoneIsSelected = true;
    }

    public void SelectComic(GameObject gameObjectClicked)
    {
        selectedComic = gameObjectClicked.transform.GetChild(0).gameObject;
        if (zoneIsSelected)
        {
            Destroy(selectedZone.transform.GetChild(0).gameObject);
            GameObject newComicChild = Instantiate(selectedComic, selectedZone.transform);
            newComicChild.transform.GetChild(1).gameObject.SetActive(true);
            Debug.Log("it worked ?");
        }

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
            zoneIsSelected = false;
        }
    }
}
