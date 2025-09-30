using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractDoorToLevel2 : Interactables
{

    public override void Use()
    {
        SceneManager.LoadSceneAsync(6);
    }

}
