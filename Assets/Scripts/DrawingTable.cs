using UnityEngine;

public class DrawingTable : MonoBehaviour
{
    public Player player;
    public GameObject drawing;
    private int index = 0;
    private GameObject destroyable;
    private RectTransform rect;
    public void ChangeDrawing()
    {
        GameObject newDrawing = Instantiate(player.collection.comicsCollection[index]);
        newDrawing.transform.SetParent(transform);
        rect = newDrawing.GetComponent<RectTransform>();
        rect.localScale = Vector3.one;
        rect.anchoredPosition = Vector2.zero;
        destroyable = drawing;
        Destroy(destroyable);
        drawing = newDrawing;
        if (index < player.collection.comicsCollection.Count - 1)
        {
            index += 1;
        }
        else
        {
            index = 0;
        }
    }
}
