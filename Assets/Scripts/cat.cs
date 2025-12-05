using UnityEngine;

public class SimpleFollower : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followRange = 5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float stoppingDistance = 1f;

    [SerializeField] private bool showGizmos = true;

    private bool isFollowing = false;

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followRange && distanceToPlayer > stoppingDistance)
        {
            isFollowing = true;
            FollowPlayer();
        }
        else
        {
            isFollowing = false;
        }
    }

    private void FollowPlayer()
    {
 
        Vector3 direction = new Vector3(
            player.position.x - transform.position.x,
            0, 
            player.position.z - transform.position.z
        ).normalized;

       
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

       
        Vector3 targetPosition = transform.position + direction * moveSpeed * Time.deltaTime;
        targetPosition.y = player.position.y; 
        transform.position = targetPosition;
    }

  
    private void OnDrawGizmosSelected()
    {
        if (!showGizmos) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);

        if (Application.isPlaying && isFollowing && player != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, player.position);
        }
    }
}