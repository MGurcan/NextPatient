using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public GameObject OfficeHolder;
    public GameObject WireTask;
    public GameObject NumbersTask;

    public GameController GameController;
    public void CloseTask(GameObject taskObject)
    {
        taskObject.SetActive(false);
        transform.gameObject.SetActive(false);
        //OfficeHolder.SetActive(true);
        GameController.LockAndHideCursor();
    }

    public void OpenTask()
    {
        //OfficeHolder.SetActive(false);
        transform.gameObject.SetActive(true);
        if(WireTask != null) { WireTask.GetComponent<WireTask>().StartCheckWireTask(); }
       
    }
    public void ForceCloseTask()
    {
        if(WireTask.activeSelf)
        {
            WireTask.GetComponent<WireTask>().ResetGame();
            WireTask.SetActive(false);
        }
        else if(NumbersTask.activeSelf)
        {
            NumbersTask.GetComponent<NumbersTask>().RestartGame();
            NumbersTask.SetActive(false);
        }
        transform.gameObject.SetActive(false);
    }
}
