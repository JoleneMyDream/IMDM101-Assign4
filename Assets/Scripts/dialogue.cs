using UnityEngine;

public class DistanceDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public float showDistance = 3f; 

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (dialogBox != null)
            dialogBox.SetActive(false);
    }

    void Update()
    {
        if (player == null || dialogBox == null) return;

        
        float distance = Vector3.Distance(transform.position, player.position);

        
        if (distance <= showDistance)
        {
            dialogBox.SetActive(true);
        }
    }
}