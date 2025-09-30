using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractDoor_NextLevel : MonoBehaviour
{
    [SerializeField] private int levelIndex; // Index of the next level to load

    public void Use()
    {
        // Load the next level based on the specified index
        SceneManager.LoadSceneAsync(levelIndex);
    }
}
