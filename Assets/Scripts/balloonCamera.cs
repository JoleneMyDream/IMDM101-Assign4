using UnityEngine;

public class BalloonCamera : MonoBehaviour
{
    [SerializeField] private Transform balloon;


    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10);


    [SerializeField] private float horizontalAngle = 0f;
    [SerializeField] private float verticalAngle = 30f;
    [SerializeField] private float distance = 10f;

    void LateUpdate()
    {
        if (balloon != null)
        {

            float hRad = horizontalAngle * Mathf.Deg2Rad;
            float vRad = verticalAngle * Mathf.Deg2Rad;


            Vector3 rotatedOffset = new Vector3(
                Mathf.Sin(hRad) * Mathf.Cos(vRad),
                Mathf.Sin(vRad),
                Mathf.Cos(hRad) * Mathf.Cos(vRad)
            ) * distance;

            transform.position = balloon.position + rotatedOffset;


            transform.LookAt(balloon);
        }
    }
}