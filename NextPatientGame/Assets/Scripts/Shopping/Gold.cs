using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    #region SIngleton:Game

    public static Gold Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
    public int totalGold;

    [SerializeField] Text[] allCoinsUIText;
    void Start()
    {
        totalGold = 1000;
        UpdateAllCoinsUIText();
        Debug.Log("len" + allCoinsUIText.Length);
    }
    public void GatherGold(int goldAmount)
    {
        totalGold += goldAmount;
    }
    public void UpdateAllCoinsUIText()
    {
        Debug.Log("selam buraya girdi."  + allCoinsUIText);
        Debug.Log(allCoinsUIText.Length);
        for (int i = 0; i < allCoinsUIText.Length; i++)
        {
            Debug.Log("totalGold.ToString(): " + totalGold.ToString());
            allCoinsUIText[i].text = totalGold.ToString();

        }
    }
    public bool HasEnoughCoins(int amount)
    {
        return (totalGold >= amount);
    }

    public void UseCoins(int amount)
    {
        totalGold -= amount;
    }
}
