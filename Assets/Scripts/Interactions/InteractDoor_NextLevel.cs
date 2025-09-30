using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractDoor_NextLevel : Interactables
{
    [SerializeField] private int levelIndex; // Index of the next level to load

    public override void Use()
    {
        // Load the next level based on the specified index
        SceneManager.LoadSceneAsync(levelIndex);
    }
}
