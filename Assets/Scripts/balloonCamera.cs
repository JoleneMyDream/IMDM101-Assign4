using UnityEngine;

public class BalloonCamera : MonoBehaviour
{
    
    [SerializeField] private Transform balloon; 
    [SerializeField] private Transform player;   

  
    [SerializeField] private Vector3 balloonOffset = new Vector3(0, 5, -10);
    [SerializeField] private float horizontalAngle = 0f;
    [SerializeField] private float verticalAngle = 30f;
    [SerializeField] private float distance = 10f;

    
    [SerializeField] private Vector3 playerOffset = new Vector3(0, 3, 0);

    private bool followBalloon = true;  

    void Start()
    {
   
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
               
            }
        }

        
    }

    void LateUpdate()
    {
        if (followBalloon && balloon != null)
        {
            
            float hRad = horizontalAngle * Mathf.Deg2Rad;
            float vRad = verticalAngle * Mathf.Deg2Rad;

            Vector3 rotatedOffset = new Vector3(
                Mathf.Sin(hRad) * Mathf.Cos(vRad),
                Mathf.Sin(vRad),
                Mathf.Cos(hRad) * Mathf.Cos(vRad)
            ) * distance;

            Vector3 targetPosition = balloon.position + rotatedOffset + balloonOffset;
            transform.position = targetPosition;
            transform.LookAt(balloon);

            Debug.DrawLine(transform.position, balloon.position, Color.green);
        }
        else if (player != null)
        {
            
            Vector3 targetPosition = player.position + playerOffset;
            transform.position = targetPosition;
            transform.rotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);

       
            Debug.DrawLine(transform.position, player.position, Color.blue);
        }
        
    }

    public void SwitchToPlayer()
    {
        if (followBalloon)  
        {
            followBalloon = false;
            transform.rotation = Quaternion.LookRotation(player.forward, Vector3.up);
        }
    }

    void OnDrawGizmos()
    {
        if (followBalloon)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 1f);
        }
        else
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, 1f);
        }
    }
}