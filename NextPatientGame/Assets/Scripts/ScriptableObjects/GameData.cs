using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Shop;

[CreateAssetMenu(fileName = "Game Data", menuName = "Game Data")]
public class GameData : ScriptableObject
{
    public int currentPatientID = 0;
    public List<ShopItem> purchasedJokers;
    public int totalGold;
    public List<int> alivePatientIndexes;
    public int currentQuestionID;
    public int beforeRoundPatientID;

    // default values
    [Header("Default Values")]
    public int defaultCurrentPatientID = 0;
    public List<ShopItem> defaultPurchasedJokers;
    public int defaultTotalGold = 450;
    public List<int> defaultAlivePatientIndexes;
    public int defaultCurrentQuestionID = 0;
    public int defaultBeforeRoundPatientID = 0;
}

