using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class RespawnTrigger : MonoBehaviour
{
  
    [SerializeField] private Transform respawnPoint;


    [SerializeField] private int targetSceneIndex = 0;

    [Header("UI显示 (TextMeshPro)")]

    [SerializeField] private TMP_Text counterText;
    [SerializeField] private string displayFormat = "Fall Count: {0}/3";


    [SerializeField] private bool enableLogs = true;

    private int collisionCount = 0;
    private const int MAX_COUNT = 3;

    void Start()
    {
        UpdateCounterDisplay();

       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Fall") && collision.gameObject.CompareTag("Player"))
        {
            collisionCount++;

           

            UpdateCounterDisplay();

            if (collisionCount >= MAX_COUNT)
            {
                LoadTargetScene();
            }
            else
            {
                RespawnPlayer(collision.gameObject);
            }
        }
    }

    private void RespawnPlayer(GameObject playerObj)
    {
        if (playerObj == null || respawnPoint == null) return;

        playerObj.transform.position = respawnPoint.position;
        playerObj.transform.rotation = respawnPoint.rotation;
      
    }

 
    private void UpdateCounterDisplay()
    {
        if (counterText != null)
        {
            counterText.text = string.Format(displayFormat, collisionCount);
        }
    }

    private void LoadTargetScene()
    {

        SceneManager.LoadScene(targetSceneIndex);
    }

    public void ResetCounter()
    {
        collisionCount = 0;
        UpdateCounterDisplay();

    }

    public int GetCurrentCount()
    {
        return collisionCount;
    }

    public void SetCount(int newCount)
    {
        collisionCount = Mathf.Clamp(newCount, 0, MAX_COUNT);
        UpdateCounterDisplay();
    }
}