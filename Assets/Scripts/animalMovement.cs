using UnityEngine;
using UnityEngine.AI;

public class animalMovement : MonoBehaviour
{
    public Transform targetLocation;
    private NavMeshAgent navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent != null && targetLocation != null)
        {
            //set destination of animals to target location
            navMeshAgent.SetDestination(targetLocation.position);
        }
    }
}