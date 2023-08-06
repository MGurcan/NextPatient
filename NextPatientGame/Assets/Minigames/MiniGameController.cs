using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{

    public GameObject OfficeHolder;

    public GameObject WireTask;
    public GameObject NumbersTask;
    public void CloseTask(GameObject taskObject)
    {
        taskObject.SetActive(false);
        transform.gameObject.SetActive(false);
        OfficeHolder.SetActive(true);
    }

    public void OpenTask()
    {
        OfficeHolder.SetActive(false);
        transform.gameObject.SetActive(true);
        WireTask.GetComponent<WireTask>().StartCheckWireTask();
    }
}
