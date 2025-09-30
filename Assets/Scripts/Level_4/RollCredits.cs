using UnityEngine;
using UnityEngine.SceneManagement;

public class RollCredits : Interactables
{
    private bool enabled;
    private bool used;
    [SerializeField] private GameObject guard;

    void Start()
    {
        enabled = false;
        used = false;
    }

    public override void Use()
    {
        if (!enabled || used)
        {
            return;
        }
        Debug.Log("Rolling credits...");
        guard.SetActive(false); // Disable the guard GameObject
        SceneManager.LoadSceneAsync(7, LoadSceneMode.Additive);

        //// find gameobject with tag playyer and teleport it 10m up in the air
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //if (player != null)
        //{
        //    player.transform.position += new Vector3(0, 10, 0);
        //}

    }

    public void Enable()
    {
        enabled = true;
    }

}
