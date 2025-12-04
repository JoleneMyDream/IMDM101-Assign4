using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    void OnCollisionEnter(Collision collision) 
    {
        
        if (gameObject.CompareTag("Fall") && collision.gameObject.CompareTag("Player"))
        {
            RespawnPlayer(collision.gameObject);
        }
    }

    private void RespawnPlayer(GameObject playerObj)
    {
        if (playerObj == null) return;

        if (respawnPoint != null)
        {
            playerObj.transform.position = respawnPoint.position;
            playerObj.transform.rotation = respawnPoint.rotation;

           
        }
    }
}