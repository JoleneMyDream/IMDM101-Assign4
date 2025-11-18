using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    private Transform player;
    private bool isRotating = false;
    public float rotationSpeed = 90f;
    public float rotationRadius = 2f;
    public float heightOffset = 0f;
    private float currentAngle = 0f;

    private Benjathemaker.SimpleGemsAnim gemAnim;
    private Vector3 rotationCenter; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gemAnim = GetComponent<Benjathemaker.SimpleGemsAnim>();
    }

    void Update()
    {
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
                heightOffset,
                Mathf.Sin(currentAngle * Mathf.Deg2Rad) * rotationRadius
            );

            transform.position = rotationCenter + offset;

           
            transform.LookAt(rotationCenter);
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

}