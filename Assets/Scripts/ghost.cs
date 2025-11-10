using UnityEngine;

public class GhostFloatWithFlip : MonoBehaviour
{
    
    public float floatDistance = 2f;
    public float floatSpeed = 1f;

   
    public bool flipBasedOnDirection = true; 
    public bool faceMovementDirection = true; 

    private Vector3 startPosition;
    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPosition = transform.position;
        previousPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        previousPosition = transform.position;

        
        float horizontalOffset = Mathf.Sin(Time.time * floatSpeed) * floatDistance;
        transform.position = new Vector3(
            startPosition.x + horizontalOffset,
            startPosition.y,
            startPosition.z
        );

        
        HandleFlipping();
    }

    void HandleFlipping()
    {
        if (flipBasedOnDirection && spriteRenderer != null)
        {
           
            Vector3 moveDirection = transform.position - previousPosition;

            
            if (moveDirection.x > 0.01f) 
            {
                spriteRenderer.flipX = false; 
            }
            else if (moveDirection.x < -0.01f) 
            {
                spriteRenderer.flipX = true; 
            }
        }
    }
}