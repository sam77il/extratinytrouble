using TMPro;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    private bool isLocked;
    private TextMeshPro displayText;
    private const string correctCode = "9133"; // Example correct code
    private string enteredCode = "";
    private string displayCode = "----";
    private int hasToEnter = 4;


    private void Start()
    {
        isLocked = true; // Keypad starts locked
        displayText = GetComponentInChildren<TextMeshPro>(); // get the TextMeshPro component in children
    }

    public void Unlock()
    {
        isLocked = false;
        displayText.text = displayCode;
        Debug.Log("Keypad unlocked!");
    }
    public bool IsLocked()
    {
        return isLocked;
    }

    public void PressKey(string number)
    {
        if (isLocked)
        {
            displayText.text = "Locked";
            Debug.Log("Keypad is locked. Cannot press keys.");
        }
        else
        {
            --hasToEnter;
            enteredCode += number;
            displayCode = displayCode.Remove(4 - hasToEnter - 1, 1).Insert(4 - hasToEnter - 1, number);
        }

        if (hasToEnter == 0)
        {
            if (enteredCode == correctCode)
            {
                displayText.text = "Correct";
                Debug.Log("Correct code entered!");
                // Add logic to open the door or perform the desired action
            }
            else
            {
                displayText.text = "Wrong";
                Debug.Log("Incorrect code. Try again.");
            }
            // Reset for next attempt
            enteredCode = "";
            displayCode = "----";
            hasToEnter = 4;
        }
        else
        {
            displayText.text = displayCode;
        }
    }

}
