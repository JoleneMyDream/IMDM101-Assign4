using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject targetPlayer; 
    public Vector3 offset = new Vector3(0f, 10f, 0f);

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
    

        if (targetPlayer != null)
        {
          
            transform.position = targetPlayer.transform.position + offset;

            
            transform.LookAt(targetPlayer.transform.position);
        }
    }
}