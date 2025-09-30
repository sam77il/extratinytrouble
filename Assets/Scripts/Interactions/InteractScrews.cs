using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Audio;

public class InteractScrews : Interactables
{

    public bool isScrewed = true;
    [SerializeField] private AudioClip unscrewSound;
    [SerializeField] private AudioClip landingSound;
    protected AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = unscrewSound;
        audioSource.volume = 0.25f;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.dopplerLevel = 1f;

        //StartCoroutine(DelayUse()); // for testing
    }

    //private IEnumerator DelayUse()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    Use();
    //}

    public override void Use()
    {
        //Debug.Log("unScrewing " + gameObject.name);

        StartCoroutine(UseHelper());
    }

    private IEnumerator UseHelper()
    {
        audioSource.Play();
        float sec = 0f;
        while ( sec <= 0.2f )
        {
            // move toward z axis and rotate around z axis in local space slowly over time
            transform.Translate(Vector3.forward * Time.deltaTime * 0.5f, Space.Self);
            transform.Rotate(Vector3.forward * Time.deltaTime * -360f, Space.Self);
            sec += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.25f);
        isScrewed = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = landingSound;
        audioSource.volume = 0.25f;
        audioSource.Play();
    }

}
