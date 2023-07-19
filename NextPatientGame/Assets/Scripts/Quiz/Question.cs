using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public string questionText; // Soru metni
    public string[] options; // Þýklarý içeren array
    public string[] clues; // Sorularin cluelari olacak onlari tutacak
    public int correctAnswer;
    public Question(string questionText, string[] options, string[] clues, int correctAnswer)
    {
        this.questionText = questionText;
        this.options = options;
        this.clues = clues;
        this.correctAnswer = correctAnswer;
    }
}
