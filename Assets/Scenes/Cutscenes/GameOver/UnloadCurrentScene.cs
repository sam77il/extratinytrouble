using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UnloadCurrentScene : MonoBehaviour
{
    [SerializeField] private VideoClip video;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(UnloadSceneAfterSeconds());
    }

    private IEnumerator UnloadSceneAfterSeconds()
    {
        yield return new WaitForSeconds((float) video.length);

        // unload current scene
        Debug.Log("UnloadingScene: " + gameObject.scene.name);
        SceneManager.UnloadSceneAsync(gameObject.scene.name);

    }

}
