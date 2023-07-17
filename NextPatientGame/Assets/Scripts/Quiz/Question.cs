using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public string questionText; // Soru metni
    public string[] options; // Þýklarý içeren array
    public int correctAnswer;
    public Question(string questionText, string[] options, int correctAnswer)
    {
        this.questionText = questionText;
        this.options = options;
        this.correctAnswer = correctAnswer;
    }
}
