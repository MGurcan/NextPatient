using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientMovement : MonoBehaviour
{
    public Vector3 targetPoint;
    private NavMeshAgent agent;
    private bool isReached = false;

    public GameObject controller;

    void Start()
    {
        controller = GameObject.FindWithTag("GameController");
        agent = GetComponent<NavMeshAgent>();

        Invoke("SetPatientDestination", 3f);    //3 secs aftes spawn make patient moving
    }

    void Update()
    {
        if (ReachedDestination())
        {
            isReached = true;
        }
    }

    public bool GetIsReached()
    {
        return isReached;
    }
    private void SetPatientDestination()
    {
        if (targetPoint != null && agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            agent.SetDestination(targetPoint);
            agent.stoppingDistance = 0.1f;
        }
        else
        {
            Debug.LogError("NavMeshAgent is not active or not on a NavMesh!");
        }
    }

    private bool ReachedDestination()
    {
        // Check if we've reached the destination

        if (!agent.pathPending && agent.remainingDistance != 0)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }


}