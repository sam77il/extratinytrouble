using UnityEngine;

public class InertactFusebox : Interactables
{
    private bool collectedScrewdriver;
    [SerializeField] private Keypad keypad; // reference to keypad to unlock it when fusebox is used

    void Start()
    {
        collectedScrewdriver = false;
    }

    public override void Use()
    {
        
        if (collectedScrewdriver)
        {
            Debug.Log("You used the fusebox with the screwdriver.");
            transform.GetChild(0).gameObject.SetActive(true); // hide the fusebox cover
            keypad.Unlock(); // unlock the keypad
        }
        else
        {
            Debug.Log("You need a screwdriver to use the fusebox.");
        }

    }

    // getter and setter for collectedScrewdriver
    public bool GetCollectedScrewdriver()
    {
        return collectedScrewdriver;
    }
    public void SetCollectedScrewdriver(bool value)
    {
        collectedScrewdriver = value;
    }

}
