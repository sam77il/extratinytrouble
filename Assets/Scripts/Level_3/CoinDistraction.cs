using System.Collections;
using UnityEngine;

public class CoinDistraction : MonoBehaviour
{
    [SerializeField] private GuradCantineAiLogic guard;
    [SerializeField] private AudioClip landingSound;
    [SerializeField] private bool doDistract;

    private void Start()
    {
        if (!doDistract) return;
        GuradCantineAiLogic[] guards = FindObjectsByType<GuradCantineAiLogic>(FindObjectsSortMode.None);
        foreach (var g in guards)
        {
            if (g.gameObject.name.Contains("Red"))
            {
                guard = g;
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Coin collided with " + collision.gameObject.name);
        // play sound at collision point
        AudioSource.PlayClipAtPoint(landingSound, collision.contacts[0].point);

        StartCoroutine(WaitAndDistractGuard(transform));
    }

    private IEnumerator WaitAndDistractGuard(Transform coinTransform)
    {
        yield return new WaitForSeconds(1.5f);
        guard.Distract(new Transform[] { coinTransform });
    }
}
