using UnityEngine;
using UnityEngine.UI;
public class QuizManager : MonoBehaviour
{
    public AnswerButton[] buttons;
    public ScoreManager scoreManager;

    public void clickAnswer()
    {
        foreach (AnswerButton button in buttons)
        {
            if (button.IsSelected())
            {
                if (button.isCorrect)
                {
                    scoreManager.updateScore();
                }
                else
                {
                    scoreManager.decreaseScore();
                }

                button.Deselect();
                break;
            }
        }
    }

    public void NewQuestion()
    {
        foreach (AnswerButton button in buttons)
        {
            button.GetComponent<Button>().interactable = true;
            button.isCorrect = false;
        }

        scoreManager.ResetAnsweredStatus(); // ScoreManager'daki isAnswered deðerini sýfýrlar
    }
}