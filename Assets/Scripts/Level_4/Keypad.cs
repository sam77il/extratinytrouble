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

    [SerializeField] private RollCredits rollCredits; // Reference to RollCredits script
    [SerializeField] private GuardAiLogic guardAiLogic; // Reference to GuardAiLogic script
    [SerializeField] private AudioClip errorSound; // Sound to play on wrong code entry
    [SerializeField] private AudioClip correctSound; // Sound to play on correct code entry


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
            displayCode = enteredCode + new string('-', hasToEnter);

        }

        if (hasToEnter == 0)
        {
            if (enteredCode == correctCode)
            {
                displayText.text = "Correct";
                Debug.Log("Correct code entered!");
                AudioSource.PlayClipAtPoint(correctSound, transform.position); // Play correct sound
                rollCredits.Enable(); // Enable rolling credits

            }
            else
            {
                displayText.text = "Wrong";
                Debug.Log("Incorrect code. Try again.");
                AudioSource.PlayClipAtPoint(errorSound, transform.position); // Play error sound
                guardAiLogic.AlertGuard(transform.position); // Alert the guard
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
