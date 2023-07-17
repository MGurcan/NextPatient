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
    private void Start()
    {
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
        answered = false;
        UpdateQuizQuestion(quizQuestionID);
        UpdateOptionButtons(quizQuestionID);
        correctOption  = quizQuestions[quizQuestionID].correctAnswer;
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


    private void ButtonClicked(int selectedOptionIndex)
    {
        if (answered) return;
        answered = true;

        if (selectedOptionIndex == correctOption)
        {
            StartCoroutine(CorrectAnswer(2, selectedOptionIndex));
        }
        else
        {      
            StartCoroutine(WrongAnswer(2, selectedOptionIndex));
        }

    }

    private IEnumerator CorrectAnswer(float delay, int selectedOptionIndex)
    {

        Color defaultButtonColor = optionButtons[0].GetComponent<Image>().color;
        Color defaultPanelColor = PanelColor.color;

        PanelColor.color = Color.green;
        optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.yellow;
        yield return new WaitForSeconds(delay);
        optionButtons[selectedOptionIndex].GetComponent<Image>().color = defaultButtonColor;
        PanelColor.color = defaultPanelColor;
        gameController.CloseQuiz(true);
    }
    private IEnumerator WrongAnswer(float delay, int selectedOptionIndex)
    {
        Color defaultButtonColor = optionButtons[0].GetComponent<Image>().color;
        Color defaultPanelColor = PanelColor.color;

        optionButtons[selectedOptionIndex].GetComponent<Image>().color = Color.red;
        PanelColor.color = Color.red;
        yield return new WaitForSeconds(delay);
        optionButtons[selectedOptionIndex].GetComponent<Image>().color = defaultButtonColor;
        PanelColor.color = defaultPanelColor;
        gameController.CloseQuiz(false);
    }
}
