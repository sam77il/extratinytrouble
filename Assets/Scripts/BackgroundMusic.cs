using System.Collections;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume = 0.5f;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = 0f;
        audioSource.loop = true; // Loop the music
        audioSource.dopplerLevel = 0; // Disable doppler effect for background music
        audioSource.Play();

        StartCoroutine(FadeIn(2f)); // Fade in over 2 seconds
    }

    // fade in
    public IEnumerator FadeIn(float duration)
    {
        audioSource = GetComponent<AudioSource>();
        float targetVolume = volume;
        float startVolume = 0f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / duration);
            yield return null;
        }
        audioSource.volume = targetVolume; // Ensure the volume is set to the target at the end
    }


    private void Update()
    {
        if (audioSource.time >= audioClip.length - 0.1f)
        {
            StartCoroutine(FadeIn(2f)); // Fade in over 2 seconds
        }
    }



}
