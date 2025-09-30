using UnityEngine;

public class InteractScrewdriver : Interactables
{
    [SerializeField] private InertactFusebox fusebox;
    
    public override void Use()
    {
        Debug.Log("You used the screwdriver.");
        fusebox.SetCollectedScrewdriver(true);
        gameObject.SetActive(false);

    }

}
