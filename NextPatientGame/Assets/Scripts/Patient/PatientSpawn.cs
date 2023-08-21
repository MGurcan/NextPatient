using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatientSpawn : MonoBehaviour
{
    public Transform patientSpawnPoint;
    public GameObject patient;
    public Vector3 targetPoint;

    public GameObject[] patients;

    public int currentPatientIndex = 0;

    public GameObject quizManager;

    List<int> alivePatientIndexes = new List<int> { 0, 1, 2, 3, 4 };

    private int beforeRoundPatientID = 0;

    public GameData gameData;
    private void Start()
    {
        beforeRoundPatientID = gameData.beforeRoundPatientID;
        alivePatientIndexes = gameData.alivePatientIndexes;
    }
    public GameObject Spawn()
    {
        if(alivePatientIndexes.Count <= 0)
        {
            Debug.Log("No Alive Patient");
        }
        Debug.Log("Patient Spawned");

        GameObject spawnedPatient = Instantiate(patients[currentPatientIndex % patients.Length], patientSpawnPoint.position, patientSpawnPoint.rotation);

        spawnedPatient.GetComponent<PatientMovement>().targetPoint = targetPoint;
        spawnedPatient.GetComponent<PatientMovement>().patientId = currentPatientIndex;
        beforeRoundPatientID = currentPatientIndex;
        gameData.beforeRoundPatientID = beforeRoundPatientID;
        currentPatientIndex = GetNextPatientIndex();
        gameData.currentPatientID = currentPatientIndex;
        quizManager.GetComponent<QuizManager>().PrepareCluesForMiniGames();
        return spawnedPatient;
    }

    public void KillPatient()
    {
        
        int index = alivePatientIndexes.IndexOf(beforeRoundPatientID);
        alivePatientIndexes.RemoveAt(index);
        //gameData.alivePatientIndexes.RemoveAt(index);

        if(alivePatientIndexes.Count <= 0)
        {
            SceneManager.LoadScene("FinishScene");
        }
    }

    private int GetNextPatientIndex()
    {
        return alivePatientIndexes[(alivePatientIndexes.IndexOf(currentPatientIndex) + 1) % alivePatientIndexes.Count];
    }
}
