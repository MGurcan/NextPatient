using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public PatientSpawn patientSpawn;
    public bool isPatientActive = false;

    public void SpawnPatientController()
    {
        if (!isPatientActive)
        {
            patientSpawn.Spawn();
            isPatientActive = true;
        }
    }
}
