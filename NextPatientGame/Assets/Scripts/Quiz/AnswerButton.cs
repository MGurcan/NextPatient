using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public bool isCorrect;
    public Button button;
    public static AnswerButton selectedButton;

    public void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (selectedButton != null)
        {
            selectedButton.Deselect();
        }

        Select();
    }

    public void Select()
    {
        Debug.Log("You sellect button");
        selectedButton = this;
        button.interactable = false;
    }

    public void Deselect()
    {
        Debug.Log("You deselect button");
        selectedButton = null;
        button.interactable = true;
    }

    public bool IsSelected()
    {
        return selectedButton == this;
    }
}