using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QuizScreen;
    public PatientSpawn patientSpawn;
    public PatientMovement patientMovement;
    public bool isPatientActive = false;

    private GameObject patient;

    private bool quizOpened = false;

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
        if(patient != null)
            patientMovement = patient.GetComponent<PatientMovement>();
        if (!quizOpened && patientMovement != null && patientMovement.GetIsReached())
            OpenQuiz();
    }
    public void SpawnPatientController()
    {
        if (!isPatientActive)
        {
            patient = patientSpawn.Spawn();
            isPatientActive = true;
        }
    }
    public void OpenQuiz()
    {
        QuizScreen.SetActive(true);
        quizOpened = true; //refactor very tricky
    }

}
