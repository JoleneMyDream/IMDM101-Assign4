using UnityEngine;
using UnityEngine.SceneManagement;

public class saveMe : MonoBehaviour
{
 void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}