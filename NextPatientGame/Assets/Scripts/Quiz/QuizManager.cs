using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class QuizManager : MonoBehaviour
{
    public Question[] quizQuestions;
    public Button[] optionButtons;
    public int correctOption;
    public Text quizQuestion;

    public GameController gameController;

    private bool answered = false;

    public Image PanelColor;

    public Button[] jokerButtons;

    private bool x2Enabled = false;
    private int selectOptionTimes = 0; //used to check x2 joker

    private Color defaultButtonColor;
    private Color defaultPanelColor;

    public Color DefaultButtonColor { get => defaultButtonColor; set => defaultButtonColor = value; }

    private void Awake()
    {
        if (ColorUtility.TryParseHtmlString("#85FF31", out Color color))
        {
            defaultButtonColor = color;
        }
        else
        {
            defaultButtonColor = Color.white; // Varsayýlan bir renk deðeri atayabilirsiniz
            Debug.LogError("Geçersiz hexadecimal renk deðeri!");
        }
        if (ColorUtility.TryParseHtmlString("#B123DA", out Color color2))
        {
            defaultPanelColor = color2;
        }
        else
        {
            defaultPanelColor = Color.white; // Varsayýlan bir renk deðeri atayabilirsiniz
            Debug.LogError("Geçersiz hexadecimal renk deðeri!");
        }
    }
    private void Start()
    { 
        Debug.Log(DefaultButtonColor);
        Debug.Log(defaultPanelColor);
        quizQuestions = new Question[]
        {
            new Question("Soru 1", new string[] { "Sýk 1", "Þýk 2", "Sýk 3", "Sýk 4" }, 1),
            new Question("Soru 2", new string[] { "Sýk 1", "Þýk 2", "Sýk 3", "Sýk 4" }, 0),
            new Question("Soru 3", new string[] { "Sýk 1", "Þýk 2", "Sýk 3", "Sýk 4" }, 0),
            new Question("Soru 4", new string[] { "Sýk 1", "Þýk 2", "Sýk 3", "Sýk 4" }, 0),
            new Question("Soru 5", new string[] { "Sýk 1", "Þýk 2", "Sýk 3", "Sýk 4" }, 0)
        };
    }
    public void prepareQuiz(int quizQuestionID)
    {
        selectOptionTimes = 0;
        x2Enabled = false;
        PanelColor.color = defaultPanelColor;
        for (int i  = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].GetComponent<Image>().color = DefaultButtonColor;
            optionButtons[i].interactable = true;
        }

        answered = false;
        UpdateQuizQuestion(quizQuestionID);
        UpdateOptionButtons(quizQuestionID);
        correctOption  = quizQuestions[quizQuestionID].correctAnswer;
        SetJokerButtons();
    }
    public void UpdateQuizQuestion(int quizQuestionID)
    {
        quizQuestion.text = quizQuestions[quizQuestionID].questionText;
    }
    public void UpdateOptionButtons(int quizQuestionID)
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int optionIndex = i;
            optionButtons[i].GetComponentInChildren<Text>().text = quizQuestions[quizQuestionID].options[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(delegate { ButtonClicked(optionIndex); });
        }
    }

    public void SetJokerButtons()
    {
        
        //Button 0 -> 50/50
        jokerButtons[0].onClick.RemoveAllListeners();
        jokerButtons[0].onClick.AddListener(Activate_50_Joker);
        jokerButtons[0].GetComponentInChildren<Text>().text = 3.ToString();

        //Button 2 -> x2
        jokerButtons[2].onClick.RemoveAllListeners();
        jokerButtons[2].onClick.AddListener(Activate_x2_Joker);
        jokerButtons[2].GetComponentInChildren<Text>().text = 4.ToString();
    }

    private void ButtonClicked(int selectedOptionIndex)
    {
        if (answered) return;
        if (!x2Enabled)
        {
            answered = true;
        }
        else
        {
            if(selectOptionTimes == 2)
                answered = true;
        }
        

        if (selectedOptionIndex == correctOption)
        {
            StartCoroutine(CorrectAnswer(2, selectedOptionIndex));
        }
        else
        {      
            StartCoroutine(WrongAnswer(2, selectedOptionIndex));
        }

    }

    public void Activate_50_Joker()
    {
        Debug.Log("Activate 50 Joker Implemented");
        int deleteCount = 0;
        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i != correctOption && deleteCount < 2)
            {
                optionButtons[i].interactable = false;
                deleteCount++;
            }
        }
    }
    public void Activate_x2_Joker()
    {
        Debug.Log("Activate x2 Joker Implemented");
        x2Enabled = true;
    }

    private IEnumerator CorrectAnswer(float delay, int selectedOptionIndex)
    {
        PanelColor.color = Color.green;
        optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.yellow;
        yield return new WaitForSeconds(delay);
        gameController.CloseQuiz(true);
    }
    private IEnumerator WrongAnswer(float delay, int selectedOptionIndex)
    {
        if (!x2Enabled)
        {
            optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.red;
            PanelColor.color = Color.red;
            yield return new WaitForSeconds(delay);
            gameController.CloseQuiz(false);
        }
        else
        {
            selectOptionTimes++;
            if(selectOptionTimes == 2)
            {
                optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.red;
                PanelColor.color = Color.red;
                yield return new WaitForSeconds(delay);
                gameController.CloseQuiz(false);
            }
            else
            {
                optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.red;
                optionButtons[selectedOptionIndex].interactable = false;
            }
        }

    }
}
