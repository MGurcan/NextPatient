using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireTaskMachine : MonoBehaviour
{

    public GameObject OpenWireTaskGameButton;
    public GameObject WireTaskMachineObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doctor"))
        {
            OpenWireTaskGameButton.SetActive(true);
            WireTaskMachineObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Doctor"))
        {
            OpenWireTaskGameButton.SetActive(false);
            WireTaskMachineObject.SetActive(false);
        }
    }
}
