using UnityEngine;

public class PlayerGuide : MonoBehaviour
{
    public Transform player;
    public float guideDistance = 3f;
    public float guideHeight = 1f;
    public float smoothSpeed = 5f;
    public bool faceMovementDirection = true;
    public float activationDistance = 5f; 

    private Vector3 playerForward;
    private Vector3 initialPosition; 
    private Quaternion initialRotation; 
    private bool isGuiding = false; 
    private bool hasBeenActivated = false; 

    void Start()
    {
       
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }

    void Update()
    {
        if (player == null) return;

  
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

      
        if (!hasBeenActivated && distanceToPlayer <= activationDistance)
        {
            ActivateGuide();
        }

       
        if (isGuiding)
        {
            CalculateGuidePosition();
            SmoothMoveToTarget();

            if (faceMovementDirection)
            {
                FaceMovementDirection();
            }
        }
    }

    void ActivateGuide()
    {
        isGuiding = true;
        hasBeenActivated = true;
       
    }

    void CalculateGuidePosition()
    {
        
        playerForward = player.forward;
        playerForward.y = 0;
        playerForward.Normalize();
    }

    void SmoothMoveToTarget()
    {
        Vector3 targetPosition = player.position +
                                playerForward * guideDistance +
                                Vector3.up * guideHeight;

       
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }

    void FaceMovementDirection()
    {
        
        if (playerForward != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
        }
    }

   
    }

 