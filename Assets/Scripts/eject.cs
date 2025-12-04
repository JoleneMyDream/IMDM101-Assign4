using UnityEngine;

public class SimpleBounce : MonoBehaviour
{
    [SerializeField] private float bounceForce = 15f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
                
            }
        }
    }
}