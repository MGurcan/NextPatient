using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientMovement : MonoBehaviour
{
    public Vector3 targetPoint;
    private NavMeshAgent agent;
    private bool isMove = false;

    void Start()
    {
        //targetPoint = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();

        Invoke("SetPatientDestination", 3f);    //3 secs aftes spawn make patient moving
    }

    void Update()
    {
        /*
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMove = true;
        }

        // Eger hareketEt true ise ve hedefNokta null degilse, hedef noktaya hareket eder
        if (isMove && targetPoint != null)
        {
            // Agent etkin oldugunu ve bir NavMesh uzerinde oldugunu kontrol eder
            if (agent.isActiveAndEnabled && agent.isOnNavMesh)
            {
                agent.SetDestination(targetPoint);
            }
            else
            {
                Debug.LogError("NavMeshAgent is not active or not on a NavMesh!");
            }
        }*/
    }

    private void SetPatientDestination()
    {
        if (targetPoint != null && agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            agent.SetDestination(targetPoint);
        }
        else
        {
            Debug.LogError("NavMeshAgent is not active or not on a NavMesh!");
        }
    }


}
