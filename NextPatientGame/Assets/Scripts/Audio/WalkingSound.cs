using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public GameObject footstep;

    void Start()
    {
        footstep.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey("w"))
        {
            footsteps();
        }
        else if(Input.GetKey("a"))
        {
            footsteps();
        }
        else if (Input.GetKey("s"))
        {
            footsteps();
        }
        else if (Input.GetKey("d"))
        {
            footsteps();
        }
        else
        {
            stopFootSteps();
        }
    }
    void footsteps()
    {
        footstep.SetActive (true);
    }
    void stopFootSteps()
    {
        footstep.SetActive(false);
    }
}
