using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f; 

    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded; 

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;
        transform.position += movement * moveSpeed * Time.deltaTime;

       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (movement != Vector3.zero)
        {
            animator.SetBool("IsWalking", true);
            RotateTowardsMovement(movement);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void Jump()
    {
       
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        animator.SetBool("IsJumping", true);
    }

    void RotateTowardsMovement(Vector3 movementDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    
    void OnCollisionEnter(Collision collision)
    {
        
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f) 
            {
                isGrounded = true;
                animator.SetBool("IsJumping", false);
                break;
            }
        }
    }

   
}