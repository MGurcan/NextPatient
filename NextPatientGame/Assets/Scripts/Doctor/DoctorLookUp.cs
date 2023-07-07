using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoctorLookUp : MonoBehaviour
{
    public float mouseSensivity = 15f;
    private float cameraRotationX = 0f;
    private bool isMouseLocked = true;
    void Update()
    {
        float mouseX = -Mouse.current.delta.x.ReadValue();
        cameraRotationX -= mouseX * mouseSensivity * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(0f, cameraRotationX, 0f);

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            isMouseLocked = !isMouseLocked;
            UpdateCursorLockState();
        }
    }

    private void UpdateCursorLockState()
    {
        Cursor.lockState = isMouseLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isMouseLocked;
    }
}
