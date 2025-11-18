using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if ((gameObject.CompareTag("levelExit") && other.CompareTag("Key")) ||
            (gameObject.CompareTag("Key") && other.CompareTag("levelExit")))
        {
            Debug.Log("Level exit key acquired! Loading next scene.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if ((gameObject.CompareTag("levelExit") && collision.gameObject.CompareTag("Key")) ||
            (gameObject.CompareTag("Key") && collision.gameObject.CompareTag("levelExit")))
        {
            Debug.Log("Level exit key acquired! Loading next scene.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}