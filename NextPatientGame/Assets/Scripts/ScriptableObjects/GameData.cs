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
}
