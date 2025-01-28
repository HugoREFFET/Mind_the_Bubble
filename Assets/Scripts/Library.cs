using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Library : MonoBehaviour
{
    
    public float currentValue=1;
    public float valueScale= 1.5f;
    public Player player;
    public List<Collection> collections;
    public List<string> names;
    void Start()
    {
        foreach (string s in names)
        {
            GameObject newObject = new GameObject(s);
            Collection collectionComponent = newObject.AddComponent<Collection>();
            collectionComponent.name = s;
            collectionComponent.value = currentValue;
            currentValue = currentValue * valueScale;
            collections.Add(collectionComponent);
        }
        player.collection = collections[0];
    }

    public void Renew()
    {

        names = new List<string> { "a", "b", "c"};
        foreach (string s in names)
        {
            GameObject newObject = new GameObject(s);
            Collection collectionComponent = newObject.AddComponent<Collection>();
            collectionComponent.name = s;
            collectionComponent.value = currentValue;
            currentValue = currentValue * valueScale;
            collections.Add(collectionComponent);
        }
    }
}
