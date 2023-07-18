using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Shop;

public class Jokers : MonoBehaviour
{

    public List<ShopItem> purchasedJokers;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)){
            for(int i = 0; i < purchasedJokers.Count; i++)
            {
                Debug.Log(purchasedJokers[i].ToString);
            }
        }    
    }

    public void PurchaseJoker(ShopItem shopItem)
    {
        purchasedJokers.Add(shopItem);
    }

}
