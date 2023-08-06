using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTask : MonoBehaviour
{

    private int minigameID_wiretask = 1;

    public List<Color> wireColors = new List<Color>();

    public List<Wire> leftWires = new List<Wire>();
    public List<Wire> rightWires = new List<Wire>();

    private List<Color> availableColors;

    private List<int> availableLeftWireIndex;
    private List<int> availableRightWireIndex;

    public Wire CurrentDraggedWire;
    public Wire CurrentHoveredWire;

    public bool IsTaskCompleted = false;

    public QuizManager quizManager;
    public GameObject MiniGames;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        availableColors = new List<Color>(wireColors);

        availableLeftWireIndex = new List<int>();
        availableRightWireIndex = new List<int>();

        for(int i = 0; i < leftWires.Count; i++)
        {
            availableLeftWireIndex.Add(i);
        }
        for (int i = 0; i < rightWires.Count; i++)
        {
            availableRightWireIndex.Add(i);
        }

        while(availableColors.Count > 0 && availableLeftWireIndex.Count > 0 && availableRightWireIndex.Count > 0) {

            Color pickedColor = availableColors[Random.Range(0, availableColors.Count)];
            int pickedLeftWireIndex = Random.Range(0, availableLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0, availableRightWireIndex.Count);

            leftWires[availableLeftWireIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            rightWires[availableRightWireIndex[pickedRightWireIndex]].SetColor(pickedColor);

            availableColors.Remove(pickedColor);
            availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            availableRightWireIndex.RemoveAt(pickedRightWireIndex);
        }
    }

    public void StartCheckWireTask()
    {
        StartCoroutine(CheckTaskCompletion());
    }
    private IEnumerator CheckTaskCompletion()
    {
        while (!IsTaskCompleted)
        {
            int successfulWires = 0;
            for (int i = 0; i < rightWires.Count; i++)
            {
                if (rightWires[i].IsSuccess) { successfulWires++; }
            }
            if (successfulWires >= rightWires.Count)
            {
                quizManager.GatherClues(minigameID_wiretask);

                MiniGames.GetComponent<MiniGameController>().CloseTask(transform.gameObject);
                ResetGame();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ResetGame()
    {
        // Clear the previous wire colors and reset lists
        foreach (var leftWire in leftWires)
        {
            leftWire.SetColor(Color.white); // Assuming Color.white is the default color
            leftWire.ResetLineRenderer();
            leftWire.IsSuccess = false;
        }

        foreach (var rightWire in rightWires)
        {
            rightWire.SetColor(Color.white); // Assuming Color.white is the default color
            rightWire.IsSuccess = false;
            rightWire.ResetLineRenderer();
        }

        // Reset available colors and indices
        availableColors.Clear();
        availableColors.AddRange(wireColors);

        availableLeftWireIndex.Clear();
        for (int i = 0; i < leftWires.Count; i++)
        {
            availableLeftWireIndex.Add(i);
        }

        availableRightWireIndex.Clear();
        for (int i = 0; i < rightWires.Count; i++)
        {
            availableRightWireIndex.Add(i);
        }

        // Randomly assign new colors to wires
        while (availableColors.Count > 0 && availableLeftWireIndex.Count > 0 && availableRightWireIndex.Count > 0)
        {
            Color pickedColor = availableColors[Random.Range(0, availableColors.Count)];
            int pickedLeftWireIndex = Random.Range(0, availableLeftWireIndex.Count);
            int pickedRightWireIndex = Random.Range(0, availableRightWireIndex.Count);

            leftWires[availableLeftWireIndex[pickedLeftWireIndex]].SetColor(pickedColor);
            rightWires[availableRightWireIndex[pickedRightWireIndex]].SetColor(pickedColor);

            availableColors.Remove(pickedColor);
            availableLeftWireIndex.RemoveAt(pickedLeftWireIndex);
            availableRightWireIndex.RemoveAt(pickedRightWireIndex);
        }

        IsTaskCompleted = false;
    }

}
