using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InteractCard : Interactables
{
    public string cardColor; // "Blue", "Red", "Green"
    public bool hasCard = false;

    public override void Use()
    {
        hasCard = true;
        Debug.Log("Interacted with " + gameObject.name + " - Card Color: " + cardColor);
        gameObject.SetActive(false);
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (cardColor == "Blue") player.HasBlueCard = true;
        else if (cardColor == "Red") player.HasRedCard = true;
        else if (cardColor == "Green") player.HasGreenCard = true;
    }
}
