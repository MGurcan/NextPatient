using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    private bool isAnswered = false;

    public void updateScore()
    {
        if (!isAnswered)
        {
            score++;
            scoreText.text = "Score: " + score;
            isAnswered = true;
        }
    }

    public void decreaseScore()
    {
        if (!isAnswered)
        {
            score--;
            scoreText.text = "Score: " + score;
            isAnswered = true;
        }
    }

    public void ResetAnsweredStatus()
    {
        isAnswered = false;
    }
}
