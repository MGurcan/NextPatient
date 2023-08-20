using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Shop;

public class PauseGame : MonoBehaviour
{
    private bool oyunDurdu = false;

    public GameData gameData;

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
        gameData.currentPatientID = 0;
        gameData.purchasedJokers = new List<ShopItem>();
        gameData.totalGold = 0;
        gameData.alivePatientIndexes = new List<int>();
        gameData.currentQuestionID = 0;
        SceneManager.LoadScene("StartCredit");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Office");
    }
}
