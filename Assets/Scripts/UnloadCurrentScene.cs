using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UnloadCurrentScene : MonoBehaviour
{
    [SerializeField] private VideoClip video; // reference to the video clip to get its length

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(UnloadSceneAfterSeconds());
    }

    private IEnumerator UnloadSceneAfterSeconds()
    {
        yield return new WaitForSeconds((float)video.length); // wait for the length of the video

        string sceneName = gameObject.scene.name; // get current scene name

        if (sceneName == "Credits")
        {
            SceneManager.LoadScene(0); // load main menu after credits
        }
        else
        {
            // unload cutscene
            Debug.Log("UnloadingScene: " + sceneName);
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }

}
