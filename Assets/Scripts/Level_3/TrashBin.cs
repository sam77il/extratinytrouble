using System.Collections;
using UnityEngine;

public class TrashBin : Interactables
{
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private GuradCantineAiLogic guard;
    [SerializeField] private Transform[] targetPositions;
    private GameObject fire;

    private void Start()
    {
        fire = transform.GetChild(1).gameObject;
        fire.SetActive(false);
         //StartCoroutine(TestCode()); // For testing purposes only
    }

    private IEnumerator TestCode()
    {
        yield return new WaitForSeconds(2f);
        Use();
    }

    public override void Use()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (!player.HasLighter) return;
        
        Debug.Log("Trash bin interacted with.");
        fire.SetActive(true);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
        StartCoroutine(DistractGuard());

    }

    private IEnumerator DistractGuard()
    {
        yield return new WaitForSeconds(1.5f);
        guard.Distract(targetPositions);
    }

}
