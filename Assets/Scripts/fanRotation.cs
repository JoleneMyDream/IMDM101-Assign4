using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float rotationSpeed = 50f; 

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
