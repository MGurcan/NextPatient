using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientMovement : MonoBehaviour
{
    public Transform targetPoint;
    private NavMeshAgent agent;
    private bool isMove = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            isMove = true;
        }

        // Eger hareketEt true ise ve hedefNokta null degilse, hedef noktaya hareket eder
        if (isMove && targetPoint != null)
        {
            // Agent etkin oldugunu ve bir NavMesh uzerinde oldugunu kontrol eder
            if (agent.isActiveAndEnabled && agent.isOnNavMesh)
            {
                agent.SetDestination(targetPoint.position);
            }
            else
            {
                Debug.LogError("NavMeshAgent is not active or not on a NavMesh!");
            }
        }
    }
}
