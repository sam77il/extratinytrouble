using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using static UnityEditor.FilePathAttribute;

/// <summary>
/// Adjusted GuardAiLogic.cs script for the cantine Level 3
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class GuradCantineAiLogic : GuardAiLogic
{
    void Start()
    {
        // set the variables
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = walkingSound;
        audioSource.volume = 0.5f;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.dopplerLevel = 1f;
        patrollingIsEnabled = true;

        // get NavMeshAgent
        m_Agent = GetComponent<NavMeshAgent>();
        // get animator from child component (the 3d model)
        m_Animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        if (m_Animator.GetBool("isWalking") && m_Agent.velocity.magnitude > 1.5f)
            m_Animator.speed = m_Agent.velocity.magnitude / m_Agent.speed; // adjust animation speed based on agent speed
        else
            m_Animator.speed = 1f; // reset animation speed when not walking

        if (m_Agent.remainingDistance <= m_Agent.stoppingDistance && !m_Agent.pathPending)
        {
            m_Animator.SetBool("isWalking", false);
        }
    }


    public void Distract(Transform[] locations)
    {
        StartCoroutine(DistractRoutine(locations));
    }

    private IEnumerator DistractRoutine(Transform[] locations)
    {
        foreach (Transform location in locations)
        {
            // Move to the distraction location
            m_Agent.SetDestination(location.position);
            m_Animator.SetBool("isWalking", true); // set animation
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            // Wait until the agent reaches the destination
            while (m_Agent.pathPending || m_Agent.remainingDistance > m_Agent.stoppingDistance)
            {
                yield return null;
            }
        }
        // After investigating all points, you can choose to return to a default position or resume patrolling
        m_Agent.isStopped = true;
        m_Animator.SetBool("isWalking", false); // set animation
        audioSource.Stop(); // stop walking sound
    }

}