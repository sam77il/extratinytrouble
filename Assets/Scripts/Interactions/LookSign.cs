using UnityEngine;

public class LookSign : Lookables
{
    [SerializeField] private GameObject arrowLeft;
    [SerializeField] private GameObject arrowRight;
    private int selectedExitIndex;

    void Start()
    {
        ResetDirectionSigns();
    }

    public int signID;
    public override void Look()
    {
        SignsManager signsManager = FindFirstObjectByType<SignsManager>();
        if (signsManager != null)
        {
            selectedExitIndex = signsManager.selectedExitIndex;
        }
        else
        {
            Debug.LogError("SignsManager not found in the scene.");
        }
        Debug.Log("Looking Sign " + signID);
        if (selectedExitIndex == 1)
        {
            if (signID == 1 || signID == 2 || signID == 3 || signID == 5 || signID == 7 || signID == 8 || signID == 9)
            {
                SetDirectionSigns("right");
            }
            else if (signID == 4 || signID == 6)
            {
                SetDirectionSigns("left");
            }
        }
        else if (selectedExitIndex == 2)
        {
            if (signID == 1 || signID == 2 || signID == 3 || signID == 4 || signID == 6 || signID == 8)
            {
                SetDirectionSigns("left");
            }
            else if (signID == 5 || signID == 7 || signID == 9)
            {
                SetDirectionSigns("right");
            }
        }
        else if (selectedExitIndex == 3)
        {
            if (signID == 1 || signID == 2 || signID == 6 || signID == 7 || signID == 8 || signID == 8)
            {
                SetDirectionSigns("left");
            }
            else if (signID == 3 || signID == 4 || signID == 5 || signID == 9)
            {
                SetDirectionSigns("right");
            }
        }
        else if (selectedExitIndex == 4)
        {
            if (signID == 1 || signID == 3 || signID == 5 || signID == 6 || signID == 9)
            {
                SetDirectionSigns("right");
            }
            else if (signID == 2 || signID == 4 || signID == 7 || signID == 8)
            {
                SetDirectionSigns("left");
            }
        }
        else if (selectedExitIndex == 5)
        {
            if (signID == 2 || signID == 4 || signID == 7)
            {
                SetDirectionSigns("left");
            }
            else if (signID == 1 || signID == 3 || signID == 5 || signID == 9 || signID == 6)
            {
                SetDirectionSigns("right");
            }
        }
        else if (selectedExitIndex == 6)
        {
            if (signID == 4 || signID == 9)
            {
                SetDirectionSigns("left");
            }
            else if (signID == 1 || signID == 2 || signID == 3 || signID == 5 || signID == 6 || signID == 7 || signID == 8)
            {
                SetDirectionSigns("right");
            }
        }
        Debug.Log("Selected Exit: " + selectedExitIndex);
        Debug.Log("Sign ID: " + signID);
    }

    private void ResetDirectionSigns()
    {
        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
    }

    private void SetDirectionSigns(string direction)
    {
        ResetDirectionSigns();

        if (direction == "left")
        {
            arrowLeft.SetActive(true);
        }
        else if (direction == "right")
        {
            arrowRight.SetActive(true);
        }
    }
}
