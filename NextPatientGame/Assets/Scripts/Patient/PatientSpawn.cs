using UnityEngine;

public class PatientSpawn : MonoBehaviour
{

    public Transform patientSpawnPoint;
    public GameObject patient;
    public Vector3 targetPoint;
    public GameObject Spawn()
    {
        Debug.Log("Patient Spawned");
        GameObject spawnedPatient = Instantiate(patient, patientSpawnPoint.position, patientSpawnPoint.rotation);

        spawnedPatient.GetComponent<PatientMovement>().targetPoint = targetPoint;
        return spawnedPatient;
    }
}
