using UnityEngine;

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

    Animator animator;

    public Gold gold;

    public GameObject footstep;
    public GameData gameData;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        doctor_actions = new DoctorActions();
        doctor_actions.Doktor_Map.Enable();

        gold.totalGold = gameData.totalGold;
        gold.UpdateAllCoinsUIText();
    }

    void Update()
    {
        movementInput = doctor_actions.Doktor_Map.Movement.ReadValue<Vector2>();
        runInput = doctor_actions.Doktor_Map.Run.ReadValue<float>();
        jumpInput = doctor_actions.Doktor_Map.Jump.ReadValue<float>();
        bool isRunning = movementInput.magnitude > 0.1f;

        bool isWalking = movementInput.magnitude > 0.1f; // Check if movement input is significant

        footstep.SetActive(isWalking);

        if (movementInput.y < 0) moveSpeedZ = 3f;   // walk backward
        else moveSpeedZ = 5f;                       // walk forward
        
        if(runInput >  0)
        {   //run
            runVelocity = 1.5f;
            isRunning = true;
        }
        else
        {
            runVelocity = 1f;
            isRunning = false;
        }


        Vector3 movement = new Vector3(movementInput.x * moveSpeedX, 0f, movementInput.y * moveSpeedZ);

        movement = transform.TransformDirection(movement);
        movement.x *= runVelocity * Time.deltaTime;
        movement.z *= runVelocity * Time.deltaTime;

        rb.MovePosition(rb.position + movement);

        if (jumpInput > 0) Jump();

        if (animator != null)
        {
            animator.SetBool("isWalking", isWalking);
            animator.SetBool("isRunning", isRunning);
        }
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

        if (collision.gameObject.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
            gold.GatherGold(150);
            gold.UpdateAllCoinsUIText();
            gameData.totalGold = gold.totalGold;
        }

        if (collision.gameObject.CompareTag("WireTask"))
        {

        }
    }

}
