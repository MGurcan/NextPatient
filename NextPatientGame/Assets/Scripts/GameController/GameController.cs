using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QuizScreen;
    public PatientSpawn patientSpawn;
    public PatientMovement patientMovement;
    public bool isPatientActive = false;

    private GameObject patient;
    public GameObject Shop;
    public GameObject InformationPanel;
    private bool quizOpened = false;


    public GoldSpawn goldSpawn;
    public QuizManager quizManager;
    private void Awake()
    {
        LockAndHideCursor();
    }

    void LockAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void UnlockAndShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            Shop.SetActive(true);
            UnlockAndShowCursor();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            InformationPanel.SetActive(true);
            UnlockAndShowCursor();
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
            UnlockAndShowCursor();
            quizOpened = true; // TODO refactor: very tricky
            quizManager.prepareQuiz(patientMovement.patientId);
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
        LockAndHideCursor();

        if (correctWrongAnswer)
        {
            goldSpawn.CreateGold();
        }
    }

    public void CloseShop()
    {
        Shop.SetActive(false);
        LockAndHideCursor();
    }

    public void CloseInformationPanel()
    {
        InformationPanel.SetActive(false);
        LockAndHideCursor();
    }

}
