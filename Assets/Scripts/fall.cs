using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
   
    [SerializeField] private GameObject player;

    
    [SerializeField] private Transform respawnPoint;

    
    [SerializeField] private Quaternion respawnRotation = Quaternion.identity;

    void Start()
    {
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        
    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            RespawnPlayer(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            RespawnPlayer(other.gameObject);
        }
    }

    private void RespawnPlayer(GameObject playerObj)
    {
        
        if (playerObj == null) return;

        
        Vector3 targetPosition;

        if (respawnPoint != null)
        {
            
            targetPosition = respawnPoint.position;
        }
        
        else
        {
            
            targetPosition = playerObj.transform.position;
            
            return;
        }

       
        playerObj.transform.position = targetPosition;
        playerObj.transform.rotation = respawnRotation;

        
        Rigidbody2D rb = playerObj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        
       

      
    }

    
}