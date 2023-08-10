using System.Collections.Generic;
using UnityEngine;

public class PatientSpawn : MonoBehaviour
{
    public Transform patientSpawnPoint;
    public GameObject patient;
    public Vector3 targetPoint;

    public GameObject[] patients;

    private int currentPatientIndex = 0;

    public GameObject quizManager;

    List<int> alivePatientIndexes = new List<int> { 0, 1, 2, 3, 4 };

    private int beforeRoundPatientID = 0;
    public GameObject Spawn()
    {
        if(alivePatientIndexes.Count <= 0)
        {
            Debug.Log("GAME OVER!!!!!");
        }
        Debug.Log("Patient Spawned");
        
        //GameObject spawnedPatient = Instantiate(patient, patientSpawnPoint.position, patientSpawnPoint.rotation);
        GameObject spawnedPatient = Instantiate(patients[currentPatientIndex % patients.Length], patientSpawnPoint.position, patientSpawnPoint.rotation);


        spawnedPatient.GetComponent<PatientMovement>().targetPoint = targetPoint;
        spawnedPatient.GetComponent<PatientMovement>().patientId = currentPatientIndex;
        beforeRoundPatientID = currentPatientIndex;
        currentPatientIndex = GetNextPatientIndex();
        quizManager.GetComponent<QuizManager>().PrepareCluesForMiniGames();
        return spawnedPatient;
    }

    public void KillPatient()
    {
        int index = alivePatientIndexes.IndexOf(beforeRoundPatientID);
        alivePatientIndexes.RemoveAt(index);
    }

    private int GetNextPatientIndex()
    {
        return alivePatientIndexes[(alivePatientIndexes.IndexOf(currentPatientIndex) + 1) % alivePatientIndexes.Count];
    }
}
