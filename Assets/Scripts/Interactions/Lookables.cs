using UnityEngine;

public class Lookables : MonoBehaviour
{
    public virtual void Look()
    {
        Debug.Log("Looking at " + gameObject.name);
    }
}
