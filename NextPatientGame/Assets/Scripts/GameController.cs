using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public PatientSpawn patientSpawn;
    public bool isPatientActive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnPatientController()
    {
        if (!isPatientActive)
        {
            patientSpawn.Spawn();
            isPatientActive = true;
        }
    }
}
