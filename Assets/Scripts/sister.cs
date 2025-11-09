
using UnityEngine;
using System.Collections;

public class SimpleCakeReaction : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool isReacting = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cake") && !isReacting)
        {
            StartCoroutine(ReactToCake());
        }
    }

    IEnumerator ReactToCake()
    {
        isReacting = true;

       
        Vector3 initialPosition = transform.position;
        Quaternion initialRotation = transform.rotation;

        
        transform.Rotate(0, -90, 0);
        yield return new WaitForSeconds(0.2f);

        
        float distanceMoved = 0f;
        while (distanceMoved < 2f)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * step);
            distanceMoved += step;
            yield return null;
        }

        
        transform.rotation = initialRotation;

        isReacting = false;
    }
}