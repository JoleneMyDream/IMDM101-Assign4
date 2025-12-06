using UnityEngine;

public class KeyTeleportTrigger : MonoBehaviour
{
    [SerializeField] private Transform[] objectsToTeleport = new Transform[2];
    [SerializeField] private Transform[] targetPositions = new Transform[2];

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportObjects();
        }
    }

    private void TeleportObjects()
    {
        if (objectsToTeleport[0] != null && targetPositions[0] != null)
        {
            objectsToTeleport[0].position = targetPositions[0].position;
        }

        if (objectsToTeleport[1] != null && targetPositions[1] != null)
        {
            objectsToTeleport[1].position = targetPositions[1].position;
        }
    }
}