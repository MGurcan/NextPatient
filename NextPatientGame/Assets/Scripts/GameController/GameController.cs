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


    public GoldSpawn goldSpawn;
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
        {
            patientMovement = patient.GetComponent<PatientMovement>();
            if (!quizOpened && patientMovement != null && patientMovement.GetIsReached())
                OpenQuiz();
        }
            

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
        if(patient != null)
        {
            QuizScreen.SetActive(true);
            quizOpened = true; // TODO refactor: very tricky
        }
    }
    public void CloseQuiz(bool correctWrongAnswer) //correctWrongAnswer: true->correct answer, false-> wrong answer
    {

        if (patient != null)
        {   
            Destroy(patient);
            patient = null; // TODO refactor: update icerisinde tekrar open quiz calisiyor
            isPatientActive = false;
        }
        quizOpened = false;
        QuizScreen.SetActive(false);

        if (correctWrongAnswer)
        {
            goldSpawn.CreateGold();
        }
    }


}
