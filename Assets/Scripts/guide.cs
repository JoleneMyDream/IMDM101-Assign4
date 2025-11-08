
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    private Transform player;
    private bool isFollowing = false;
    public float followSpeed = 3f;
    public float followDistance = 1f;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isFollowing && player != null)
        {
           
            Vector3 targetPosition = player.position - player.forward * followDistance;
            targetPosition.y = transform.position.y; 

            
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            transform.rotation = player.rotation;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartFollowing();
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartFollowing();
        }
    }

    void StartFollowing()
    {
        isFollowing = true;
      
    }
}
