using UnityEngine;

public class RangeFollower : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float triggerRange = 5f;
    [SerializeField] private float followSpeed = 3f;
    [SerializeField] private float followDistance = 2f;

    private bool isFollowing = false;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

    
        if (distance <= triggerRange)
        {
            isFollowing = true;
        }

        if (isFollowing)
        {
          
            Vector3 followOffset = -player.forward * followDistance; 
            Vector3 targetPosition = player.position + followOffset;

            targetPosition.y = player.position.y;

            
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                followSpeed * Time.deltaTime
            );

         
            transform.LookAt(player);
        }
    }
}