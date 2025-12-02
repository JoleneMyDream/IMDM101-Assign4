using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoaderGarden : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if ((gameObject.CompareTag("levelExit") && other.CompareTag("Player")) ||
            (gameObject.CompareTag("Player") && other.CompareTag("levelExit")))
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if ((gameObject.CompareTag("levelExit") && collision.gameObject.CompareTag("Player")) ||
            (gameObject.CompareTag("Player") && collision.gameObject.CompareTag("levelExit")))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
