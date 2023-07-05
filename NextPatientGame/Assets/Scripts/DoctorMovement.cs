using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoctorMovement : MonoBehaviour
{
    [Header("Doctor Movement")]
    [SerializeField]
    private float moveSpeedX = 2f;
    [SerializeField]
    private float moveSpeedZ = 5f;
    [SerializeField]
    private float jumpForce = 200f;
    private bool isGround = false;

    public Rigidbody rb;
    private DoctorActions doctor_actions;

    private Vector2 movementInput;
    private float jumpInput;
    private float runInput;
    private float runVelocity = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        doctor_actions = new DoctorActions();
        doctor_actions.Doktor_Map.Enable();
    }

    void Update()
    {
        movementInput = doctor_actions.Doktor_Map.Movement.ReadValue<Vector2>();
        runInput = doctor_actions.Doktor_Map.Run.ReadValue<float>();
        jumpInput = doctor_actions.Doktor_Map.Jump.ReadValue<float>();

        if (movementInput.y < 0) moveSpeedZ = 3f;   // walk backward
        else moveSpeedZ = 5f;                       // walk forward
        
        if(runInput >  0)
        {   //run
            runVelocity = 1.5f;
        }
        else
        {
            runVelocity = 1f;
        }


        Vector3 movement = new Vector3(movementInput.x * moveSpeedX, 0f, movementInput.y * moveSpeedZ);

        movement = transform.TransformDirection(movement);
        movement.x *= runVelocity * Time.deltaTime;
        movement.z *= runVelocity * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

        if (jumpInput > 0) Jump();
    }

    private void Jump()
    {
        if(isGround) { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGround = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chair"))
        {
            Debug.Log("Sandalyeye Geldi");
        }
    }
}
