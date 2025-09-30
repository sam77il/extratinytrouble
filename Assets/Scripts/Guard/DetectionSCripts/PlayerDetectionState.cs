using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDetectionState : MonoBehaviour
{
    private float detectionTime; // Time the player has been detected
    [SerializeField] private float requiredDetectionTime; // Time required to trigger an alert
    private bool playerInSight; // Whether the player is currently in sight
    public bool playerDetected => detectionTime >= requiredDetectionTime;

    [Header("UI References")]
    [SerializeField] private Image detectionWarning; // UI element to show state

    private void Start()
    {
        Color col = detectionWarning.color;
        col.a = 0f;
        detectionWarning.color = col;
    }

    private void Update()
    {
        //Debug.Log("detected time: " +  detectionTime);
        // increase transparency when detecting goes up, decrease when goes down
        if (detectionWarning != null)
        {
            Color col = detectionWarning.color;
            col.a = detectionTime / requiredDetectionTime;
            detectionWarning.color = col;
        }

        if (playerInSight)
        { // player is in sight, increase detection time
            detectionTime += Time.deltaTime;
            if (detectionTime >= requiredDetectionTime)
            {
                // Trigger alert state
                Debug.Log("Player detected! Triggering alert state.");
                detectionTime = requiredDetectionTime; // Clamp to max

                GameManager.Instance.UpdateLifes("rem", 1);
                SceneManager.LoadScene(gameObject.scene.buildIndex);
                SceneManager.LoadSceneAsync(5, LoadSceneMode.Additive);
            }
        }
        else
        { // player is not in sight, decrease detection time
            detectionTime -= Time.deltaTime*3;
            if (detectionTime < 0f)
                detectionTime = 0f;
        }

    }

    public void SetPlayerInSight(bool inSight)
    {
        playerInSight = inSight;
    }



}
