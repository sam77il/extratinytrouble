using UnityEngine;
using UnityEngine.SceneManagement;

public class RollCredits : Interactables
{
    private bool isEnabled;
    private bool used;
    [SerializeField] private GameObject guard;

    void Start()
    {
        isEnabled = false;
        used = false;
    }

    public override void Use()
    {
        if (!isEnabled || used)
        {
            return;
        }
        Debug.Log("Rolling credits...");
        guard.SetActive(false); // Disable the guard GameObject
        SceneManager.LoadSceneAsync(7);

        //// find gameobject with tag playyer and teleport it 10m up in the air
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //if (player != null)
        //{
        //    player.transform.position += new Vector3(0, 10, 0);
        //}

    }

    public void Enable()
    {
        isEnabled = true;
    }

}
