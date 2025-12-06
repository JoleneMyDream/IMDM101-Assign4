using UnityEngine;

public class TeleportFourObjects : MonoBehaviour
{
    [SerializeField] private Transform[] objectsToTeleport = new Transform[4];
    [SerializeField] private Transform[] targetPositions = new Transform[4];
    [SerializeField] private bool hideAtStart = true;

    void Start()
    {
        if (hideAtStart)
        {
            SetObjectsActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportAllObjects();
        }
    }

    private void TeleportAllObjects()
    {

        SetObjectsActive(true);


        int minLength = Mathf.Min(objectsToTeleport.Length, targetPositions.Length);
        for (int i = 0; i < minLength; i++)
        {
            if (objectsToTeleport[i] != null && targetPositions[i] != null)
            {
                objectsToTeleport[i].position = targetPositions[i].position;
                objectsToTeleport[i].rotation = targetPositions[i].rotation;
            }
        }
    }

    private void SetObjectsActive(bool isActive)
    {
        foreach (Transform obj in objectsToTeleport)
        {
            if (obj != null)
            {
                obj.gameObject.SetActive(isActive);
            }
        }
    }
}