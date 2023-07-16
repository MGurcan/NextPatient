using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Shop;

public class Jokers : MonoBehaviour
{

    public List<ShopItem> ShopItemsList;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)){
            for(int i = 0; i < ShopItemsList.Count; i++)
            {
                Debug.Log(ShopItemsList[i].ToString);
            }
        }    
    }

    public void PurchaseJoker(ShopItem shopItem)
    {
        ShopItemsList.Add(shopItem);
    }

}
