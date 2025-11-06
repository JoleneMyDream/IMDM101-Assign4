using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // WASD
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S

        // calculate the direction
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        // move
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}

