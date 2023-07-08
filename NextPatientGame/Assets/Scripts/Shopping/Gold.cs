using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    private int totalGold = 0;

    public Text goldText;
    private void GatherGold(int goldAmount)
    {
        totalGold += goldAmount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
            GatherGold(20);
            goldText.text = "" + totalGold; 
        }
        
        
    }
}
