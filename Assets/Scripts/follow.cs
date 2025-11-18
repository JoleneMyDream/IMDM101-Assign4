using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    private Transform player;
    private bool isRotating = false;
    public float rotationSpeed = 90f;
    public float rotationRadius = 2f;
    public float fixedHeight = 2f;
    private float currentAngle = 0f;

    private Benjathemaker.SimpleGemsAnim gemAnim;
    private Vector3 rotationCenter;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialUpDirection; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gemAnim = GetComponent<Benjathemaker.SimpleGemsAnim>();


        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialUpDirection = transform.up; 
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            ReturnToInitialPosition();
        }

        if (isRotating && player != null)
        {
            if (gemAnim != null)
            {
                gemAnim.isRotating = false;
                gemAnim.isFloating = false;
            }

            currentAngle += rotationSpeed * Time.deltaTime;
            if (currentAngle >= 360f) currentAngle -= 360f;

            rotationCenter = player.position;


            Vector3 offset = new Vector3(
                Mathf.Cos(currentAngle * Mathf.Deg2Rad) * rotationRadius,
                0f,
                Mathf.Sin(currentAngle * Mathf.Deg2Rad) * rotationRadius
            );


            Vector3 newPosition = rotationCenter + offset;
            newPosition.y = fixedHeight;
            transform.position = newPosition;

            
            transform.rotation = initialRotation;

            
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartRotating();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartRotating();
        }
    }

    void StartRotating()
    {
        if (!isRotating)
        {
            isRotating = true;

            if (player != null)
            {
                Vector3 direction = (transform.position - player.position).normalized;
                currentAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }

              
                initialRotation = transform.rotation;
                initialUpDirection = transform.up;
            }
        }
    }

    public void StopRotating()
    {
        isRotating = false;
        if (gemAnim != null)
        {
            gemAnim.isRotating = true;
            gemAnim.isFloating = true;
        }
    }


    void ReturnToInitialPosition()
    {

        isRotating = false;


        transform.position = initialPosition;
        transform.rotation = initialRotation;


        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }


        if (gemAnim != null)
        {
            gemAnim.isRotating = true;
            gemAnim.isFloating = true;
        }


    }
}