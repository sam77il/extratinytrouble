using UnityEngine;

public class SpawnPlayerForTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.SpawnPlayer(transform.position);
    }
}
