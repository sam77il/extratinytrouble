using UnityEngine;

public class SearchPlayer : MonoBehaviour
{
    // reference to the flashlight raycast script and guard ai logic script and player detection state script
    private FlashlightRaycast flashlightRaycast;
    private GuardAiLogic guardAiLogic;
    private PlayerDetectionState playerDetectionState;

    // Empty at eye level of the guard.
    [SerializeField] private Transform eyesPosition;
    [SerializeField] private float FOV;


    void Start()
    {
        // get GuardAiLogic component from this object
        guardAiLogic = GetComponent<GuardAiLogic>();

        playerDetectionState = null; // we will get this component later from the player when we see him

    }

    void FixedUpdate()
    {
        // get player with tag "Player" if it is in the trigger collider of this object
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("Player"));

        // check if hitColliders array is empty. if yes: return;
        if (hitColliders.Length == 0)
            return;

        Collider hitCollider = hitColliders[0]; // save collided player in a variable for easier acces

        Vector3 positionOfEyes = eyesPosition.position; 
        Vector3 directionToPlayer = (hitCollider.transform.position - positionOfEyes); // get direction vector to player
        directionToPlayer += new Vector3(0f, 0.5f, 0f); // adjust direction to be at the height of the player
        directionToPlayer = directionToPlayer.normalized; // normalize direction vector again after adjusting height
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer); // get angle of player relative to the guard


        if (angleToPlayer < (FOV/2)) // calculate if player is in view of *FOV* cone in front of guard
        {
            // do a sphereCast to see if player is in the light area of the flashlight
            RaycastHit hitInfo;
            Physics.Raycast(positionOfEyes, directionToPlayer, out hitInfo, 10f, LayerMask.GetMask("Player", "Obstacle"));
            Debug.DrawLine(positionOfEyes, hitInfo.point, Color.yellow); // draw yellow line to show direction to player
            Debug.DrawRay(positionOfEyes, directionToPlayer, Color.yellow); // draw yellow line to show direction to player

            if (hitInfo.collider != null) // if whe hit something ( the player or an obstacle )
            {
                if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player")) // when player in direct sight
                {
                    if (playerDetectionState == null) // get PlayerDetectionState component from the player if we don't have it yet
                        playerDetectionState = hitCollider.GetComponentInParent<PlayerDetectionState>();
                    playerDetectionState.SetPlayerInSight(true);
                    Debug.DrawLine(positionOfEyes, hitInfo.point, Color.magenta); // draw magenta line when player in sight
                    guardAiLogic.PausePatrollingForSeconds(3.5f); // pause patrolling when player in sight
                }
                else
                {
                    if (playerDetectionState != null)
                        playerDetectionState.SetPlayerInSight(false);
                    Debug.DrawLine(positionOfEyes, hitInfo.point, Color.cyan); // draw cyna line when player not in sight
                }

            } else
            {
                if (playerDetectionState != null)
                    playerDetectionState.SetPlayerInSight(false);
            }
        } 
    }

    private void OnDrawGizmos()
    {
        // visualize the overlap sphere in the editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 5f);

    }
}
