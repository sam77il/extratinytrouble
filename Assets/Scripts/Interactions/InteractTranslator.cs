using System.Collections;
using UnityEngine;

public class InteractTranslator : Interactables
{
    public bool hasTranslation = false;

    public override void Use()
    {
        UseHelper();
    }

    private void UseHelper()
    {
        hasTranslation = true;
        gameObject.SetActive(false);
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.HasTranslator = true;
    }

}
