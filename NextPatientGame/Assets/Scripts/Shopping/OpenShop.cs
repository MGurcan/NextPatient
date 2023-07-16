using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject Shop;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) ){
            Shop.SetActive(true);
        }
    }
}
