using UnityEngine;

public class ExitController : MonoBehaviour
{
    public int exitIndex;
    public int finalExitIndex;
    private SignsManager signsManager;

    private void Start()
    {
        signsManager = FindFirstObjectByType<SignsManager>();
        finalExitIndex = signsManager.selectedExitIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            signsManager.SetExit(exitIndex);
        }
    }
}
