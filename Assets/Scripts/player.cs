using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 10f; 
    private Rigidbody rb;

    void Start()
    {
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

       
        if (movement != Vector3.zero)
        {
            RotateTowardsMovement(movement);
        }
    }

    void RotateTowardsMovement(Vector3 movementDirection)
    {
       
        Quaternion targetRotation = Quaternion.LookRotation(movementDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}