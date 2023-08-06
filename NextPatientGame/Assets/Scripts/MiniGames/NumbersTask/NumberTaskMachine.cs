using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberTaskMachine : MonoBehaviour
{

    public GameObject OpenNumbersTaskGameButton;
    public GameObject NumbersTaskMachineObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doctor"))
        {
            OpenNumbersTaskGameButton.SetActive(true);
            NumbersTaskMachineObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Doctor"))
        {
            OpenNumbersTaskGameButton.SetActive(false);
            NumbersTaskMachineObject.SetActive(false);
        }
    }
}
