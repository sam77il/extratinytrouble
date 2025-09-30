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
        float waitTime = 0.0f; // default wait time in seconds
        if (video != null)
            waitTime = (float)video.length; // set wait time to video length if video is assigned
        yield return new WaitForSeconds((float)video.length); // wait 

        string sceneName = gameObject.scene.name; // get current scene name

        if (sceneName == "Credits")
        {
            SceneManager.LoadScene(0); // load main menu after credits
        }
        else if (sceneName == "MantelGag")
        {
            SceneManager.LoadScene(2); // load first level after intro cutscene
        }
        else
        {
            // unload cutscene
            Debug.Log("UnloadingScene: " + sceneName);
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }

}
