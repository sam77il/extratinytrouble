using System.Collections;
using UnityEngine;

public class InteractTrashbin : Interactables
{
    public bool isOnFire = false;

    public override void Use()
    {
        UseHelper();
    }

    private void UseHelper()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        Debug.Log("Player has lighter: " + player.HasLighter);
        if (!isOnFire && player.HasLighter)
        {
            isOnFire = true;
            TrashBin trashBin = FindFirstObjectByType<TrashBin>();
            trashBin.Use();
        }
    }

}
