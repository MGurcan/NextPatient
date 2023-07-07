using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public PatientSpawn patientSpawn;
    public bool isPatientActive = false;


    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.N)){
            SpawnPatientController();
        }
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
