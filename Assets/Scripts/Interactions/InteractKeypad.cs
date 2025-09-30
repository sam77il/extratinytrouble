using System.Collections;
using UnityEngine;

public class InteractKeypad : Interactables
{
    [SerializeField] private GameObject redCard;
    [SerializeField] private GameObject greenCard;
    [SerializeField] private GameObject blueCard;

    private bool redCardInserted = false;
    private bool greenCardInserted = false;
    private bool blueCardInserted = false;
    public override void Use()
    {
        UseHelper();
    }

    private void UseHelper()
    {
        Debug.Log("Interacted with Keypad");
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (player.HasBlueCard && !blueCardInserted)
        {
            blueCardInserted = true;
            Debug.Log("Blue Card Inserted");
            blueCard.SetActive(true);
        }
        if (player.HasGreenCard && !greenCardInserted)
        {
            greenCardInserted = true;
            Debug.Log("Green Card Inserted");
            greenCard.SetActive(true);
        }
        if (player.HasRedCard && !redCardInserted)
        {
            redCardInserted = true;
            Debug.Log("Red Card Inserted");
            redCard.SetActive(true);
        }

        if (redCardInserted && greenCardInserted && blueCardInserted)
        {
            Debug.Log("All Cards Inserted! Keypad Unlocked!");
            // Add logic for unlocking the keypad here
            BoxCollider collider = GetComponent<BoxCollider>();
            collider.enabled = false;
        }
    }
}
