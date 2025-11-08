using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject targetPlayer;
    public Vector3 offset = new Vector3(0f, 10f, -5f);
    public float smoothSpeed = 0.125f;
    internal static object current;

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        if (targetPlayer != null)
        {
            
            Vector3 playerForward = targetPlayer.transform.forward;


            Vector3 desiredPosition = targetPlayer.transform.position +
                                  new Vector3(0f, offset.y, offset.z);


            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            
            transform.LookAt(targetPlayer.transform.position);
        }
    }
}