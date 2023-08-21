using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Shop;

public class Jokers : MonoBehaviour
{

    public List<ShopItem> purchasedJokers;

    public void PurchaseJoker(ShopItem shopItem)
    {
        purchasedJokers.Add(shopItem);
    }

}