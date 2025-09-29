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
    }

}
