using System.Collections;
using UnityEngine;

public class InteractLighter : Interactables
{
    public bool hasLighter = false;

    public override void Use()
    {
        UseHelper();
    }

    private void UseHelper()
    {
        hasLighter = true;
        gameObject.SetActive(false);
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.HasLighter = true;
    }

}
