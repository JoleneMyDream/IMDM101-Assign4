using UnityEngine;

public class DestroyOnPlayerTouch : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }
}
