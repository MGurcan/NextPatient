using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class NumbersTask : MonoBehaviour
{
    public List<Button> buttons;
    public List<Button> shuffledButtons;
    int counter = 0;
    private int minigameID_wiretask = 0;

    public QuizManager quizManager;
    public GameObject MiniGames;
    public void RestartGame()
    {
        counter = 0;
        shuffledButtons = buttons.OrderBy(a => Random.Range(0, 100)).ToList();
        for (int i = 1; i < 11; i++)
        {
            shuffledButtons[i - 1].GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            shuffledButtons[i - 1].interactable = true;
            shuffledButtons[i - 1].image.color = new Color32(133, 255, 49, 255);

        }
        buttons = shuffledButtons;
    }

    public void pressButton(Button button)
    {
        if (int.Parse(button.GetComponentInChildren<TextMeshProUGUI>().text) - 1 == counter)
        {
            counter++;
            button.interactable = false;
            button.image.color = Color.blue;
            if (counter == 10)
            {
                StartCoroutine(presentResult(true));
            }
        }
        else
        {
            StartCoroutine(presentResult(false));
        }
    }

    public IEnumerator presentResult(bool win)
    {
        if (!win)
        {
            Debug.Log("lose oldu");
            foreach (var button in buttons)
            {
                button.image.color = Color.red;
                button.interactable = false;
            }
            yield return new WaitForSeconds(2f);
            RestartGame();
        }
        else
        {
            Debug.Log("Win bravo");
            quizManager.GatherClues(minigameID_wiretask);
            MiniGames.GetComponent<MiniGameController>().CloseTask(transform.gameObject);
            RestartGame();
        }
        
    }
}