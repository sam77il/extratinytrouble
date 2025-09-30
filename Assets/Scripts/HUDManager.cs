using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameObject healthsObject;
    [SerializeField] private GameObject emptyLifePrefab;
    [SerializeField] private GameObject fullLifePrefab;

    private void Start()
    {
        if (GameManager.Instance.CurrentGame.difficulty == 0)
        {
            // Easy
            for (int i = 0; i < 10; i++)
            {
                Instantiate(fullLifePrefab, healthsObject.transform);
            }
        }
        else if (GameManager.Instance.CurrentGame.difficulty == 1)
        {
            // Medium
            for (int i = 0; i < 5; i++)
            {
                Instantiate(fullLifePrefab, healthsObject.transform);
            }
        }
        else if (GameManager.Instance.CurrentGame.difficulty == 2)
        {
            // Hard
            for (int i = 0; i < 1; i++)
            {
                Instantiate(fullLifePrefab, healthsObject.transform);
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(emptyLifePrefab, healthsObject.transform);
            }
        }
    }

}
