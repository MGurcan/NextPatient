using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    private bool oyunDurdu = false;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!oyunDurdu)
            {
                Time.timeScale = 0; 
                oyunDurdu = true;
            }
            else
            {
                Time.timeScale = 1; 
                oyunDurdu = false;
            }
        }
    }

    public void pause()
    {
        Debug.Log("Pause methodu");
        if (!oyunDurdu)
        {
            Time.timeScale = 0;
            oyunDurdu = true;
        }
        else
        {
            Time.timeScale = 1;
            oyunDurdu = false;
        }
    }

    public void Exit()
    {
        Debug.Log("Exit methodu");
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Office");
    }




}
