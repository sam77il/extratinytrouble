using System.Collections.Generic;
using UnityEngine;

public class SignsManager : MonoBehaviour
{
    [SerializeField] private GameObject exits;
    [SerializeField] private GameObject directionSign1;
    [SerializeField] private GameObject directionSign2;
    [SerializeField] private GameObject directionSign3;
    [SerializeField] private GameObject directionSign4;
    [SerializeField] private GameObject directionSign5;
    [SerializeField] private GameObject directionSign6;
    [SerializeField] private GameObject directionSign7;
    [SerializeField] private GameObject directionSign8;
    [SerializeField] private GameObject directionSign9;
    private List<GameObject> exitPoints = new List<GameObject>();
    public int selectedExitIndex = -1;

    private void Start()
    {
        foreach (Transform child in exits.transform)
        {
            exitPoints.Add(child.gameObject);
        }

        foreach (GameObject exit in exitPoints)
        {
            exit.SetActive(false);
        }

        RandomizeExit();
    }

    private void RandomizeExit()
    {
        if (exitPoints.Count == 0) return;

        int randomIndex = Random.Range(0, exitPoints.Count);
        GameObject selectedExit = exitPoints[randomIndex];

        selectedExit.SetActive(true);
        selectedExitIndex = int.Parse(selectedExit.name.Split('_')[1]);
        Debug.Log("Activated Exit: " + selectedExitIndex);
    }

    private void ChoosePath()
    {
        if (selectedExitIndex == 1)
        {
            directionSign2.SetActive(true); // right
            directionSign1.SetActive(true); // right
            directionSign3.SetActive(true); // right
            directionSign4.SetActive(true); // left
            directionSign5.SetActive(true); // right
            directionSign6.SetActive(true); // left
            directionSign7.SetActive(true); // right
            directionSign8.SetActive(true); // right
            directionSign9.SetActive(true); // right
        }
        else if (selectedExitIndex == 2)
        {
            directionSign2.SetActive(true); // left
            directionSign1.SetActive(true); // left
            directionSign3.SetActive(true); // left
            directionSign4.SetActive(true); // left
            directionSign5.SetActive(true); // right
            directionSign6.SetActive(true); // left
            directionSign7.SetActive(true); // right
            directionSign8.SetActive(true); // left
            directionSign9.SetActive(true); // right
        }
        else if (selectedExitIndex == 3)
        {
            directionSign2.SetActive(true); // left
            directionSign1.SetActive(true); // left
            directionSign3.SetActive(true); // right
            directionSign4.SetActive(true); // right
            directionSign5.SetActive(true); // right
            directionSign6.SetActive(true); // left
            directionSign7.SetActive(true); // left
            directionSign8.SetActive(true); // left
            directionSign9.SetActive(true); // right
        }
        else if (selectedExitIndex == 4)
        {
            directionSign2.SetActive(true); // left
            directionSign1.SetActive(true); // right
            directionSign3.SetActive(true); // right
            directionSign4.SetActive(true); // left
            directionSign5.SetActive(true); // right
            directionSign6.SetActive(true); // right
            directionSign7.SetActive(true); // left
            directionSign8.SetActive(true); // left
            directionSign9.SetActive(true); // right
        }
        else if (selectedExitIndex == 5)
        {
            directionSign2.SetActive(true); // left
            directionSign1.SetActive(true); // right
            directionSign3.SetActive(true); // right
            directionSign4.SetActive(true); // left
            directionSign5.SetActive(true); // right
            directionSign6.SetActive(true); // right
            directionSign7.SetActive(true); // left
            directionSign8.SetActive(true); // right
            directionSign9.SetActive(true); // right
        }
        else if (selectedExitIndex == 6)
        {
            directionSign2.SetActive(true); // right
            directionSign1.SetActive(true); // right
            directionSign3.SetActive(true); // right
            directionSign4.SetActive(true); // left
            directionSign5.SetActive(true); // right
            directionSign6.SetActive(true); // right
            directionSign7.SetActive(true); // right
            directionSign8.SetActive(true); // right
            directionSign9.SetActive(true); // left
        }
    }
}
