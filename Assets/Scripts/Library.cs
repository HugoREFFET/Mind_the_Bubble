using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Library : MonoBehaviour
{
    
    public float currentValue=1;
    public float valueScale= 1.5f;
    public Player player;
    [SerializeField]
    public List<Collection> collections;

    private int currentIndex = 3;
    void Start()
    {
        player.collection = collections[0];
        foreach (Collection c in collections)
        {
            c.value = currentValue;
            currentValue = currentValue * valueScale;
        }
    }

    public void Renew()
    {
        int repeat = collections.Count;
        for (int i = 0; i < repeat; i++)
        {
            GameObject gameObject = new GameObject();
            Collection reCollection = gameObject.AddComponent<Collection>();
            reCollection.value = currentValue;
            currentValue = currentValue * valueScale;
            reCollection.comicsCollection = collections[i].comicsCollection;
            reCollection.index = currentIndex;
            currentIndex += 1;
            collections.Add(reCollection);
            
        }
    }
}
