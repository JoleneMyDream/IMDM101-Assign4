/*
using UnityEngine;
using TMPro;

public class DestroyOnPlayerTouch : MonoBehaviour
{
    private int count;
    public TextMeshProUGUI countText;
    //private boolean allCollected;
    

    void Start()
    {
        count = 0;
        SetCountText();
        //allCollected = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            count = count + 1;
            SetCountText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            count = count + 1;
            SetCountText();
        }
    }
   

    void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 11)
       {
           countText.text =  "All foods collected!";
       }
   }
}

*/