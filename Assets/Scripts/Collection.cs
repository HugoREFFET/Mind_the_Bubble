using UnityEngine;

public class Collection : MonoBehaviour
{
    public string name;
    public float value;

    public void SetCollection(string toName, float toValue)
    {
        name= toName;
        value = toValue;
    }
}
