using UnityEngine;

public class PatientSpawn : MonoBehaviour
{
    public Transform patientSpawnPoint;
    public GameObject patient;
    public Vector3 targetPoint;

    public GameObject[] patients;

    private int currentPatientIndex = 0;

    public GameObject Spawn()
    {
        Debug.Log("Patient Spawned");
        
        //GameObject spawnedPatient = Instantiate(patient, patientSpawnPoint.position, patientSpawnPoint.rotation);
        GameObject spawnedPatient = Instantiate(patients[currentPatientIndex % patients.Length], patientSpawnPoint.position, patientSpawnPoint.rotation);

        spawnedPatient.GetComponent<PatientMovement>().targetPoint = targetPoint;
        spawnedPatient.GetComponent<PatientMovement>().patientId = currentPatientIndex;
        currentPatientIndex++;
        return spawnedPatient;
    }
}
