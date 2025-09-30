using UnityEngine;

public class PlayFootStep : MonoBehaviour
{
    [SerializeField] private AudioClip stepSound;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = stepSound;
        audioSource.volume = 1f;
        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

}

