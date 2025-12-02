using UnityEngine;

public class BalloonCamera : MonoBehaviour
{
    [SerializeField] private Transform balloon;  // 
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10); 

    void LateUpdate()
    {
        if (balloon != null)
        {
            
            transform.position = balloon.position + offset;

            
            transform.LookAt(balloon);
        }
    }
}