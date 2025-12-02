using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    public float riseSpeed = 2f; 
    void Update()
    {
        transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
    }
}