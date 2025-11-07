using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "levelExit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
