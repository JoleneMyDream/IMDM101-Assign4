using UnityEngine;

public class GhostHorizontalFloat : MonoBehaviour
{
    
    public float floatDistance = 3f;      
    public float floatSpeed = 1f;           
    public bool startFromRight = true;      

    private Vector3 startPosition;
    private float currentLerpTime = 0f;
    private bool movingRight = true;

    void Start()
    {
     
        startPosition = transform.position;

        
        movingRight = startFromRight;

      
        if (startFromRight)
        {
            transform.position = startPosition + Vector3.right * floatDistance;
        }
    }

    void Update()
    {
       
        currentLerpTime += Time.deltaTime * floatSpeed;

       
        float t = Mathf.PingPong(currentLerpTime, 1f);

        Vector3 leftPos = startPosition + Vector3.left * floatDistance;
        Vector3 rightPos = startPosition + Vector3.right * floatDistance;

        
        if (movingRight)
        {
            transform.position = Vector3.Lerp(leftPos, rightPos, t);
        }
        else
        {
            transform.position = Vector3.Lerp(rightPos, leftPos, t);
        }
    }
}