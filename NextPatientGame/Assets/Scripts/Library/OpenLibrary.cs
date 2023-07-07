using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLibrary : MonoBehaviour
{
    public GameObject OpenLibraryButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doctor"))
        {
            OpenLibraryButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Doctor"))
        {
            OpenLibraryButton.SetActive(false);
        }
    }
}
