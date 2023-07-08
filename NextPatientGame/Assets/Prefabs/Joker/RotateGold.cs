using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGold : MonoBehaviour
{
    private int rotateSpeed = 150;
    void Start()
    {
        transform.Rotate(Vector3.right, 90f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }
}
