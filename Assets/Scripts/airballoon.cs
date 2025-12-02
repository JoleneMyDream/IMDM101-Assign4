using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    public float riseSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("stopBalloon"))
        {
        
            enabled = false;
            

          
            BalloonCamera cameraScript = FindObjectOfType<BalloonCamera>();
            if (cameraScript != null)
            {
                cameraScript.SwitchToPlayer();
            }
        }
    }
}