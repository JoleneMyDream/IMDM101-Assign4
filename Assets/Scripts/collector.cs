using UnityEngine;
using TMPro;
public class collector : MonoBehaviour
{
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
    void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 9)
       {
           winTextObject.SetActive(true);
       }
   }

   void OnTriggerEnter(Collider other) 
   {
        if (other.gameObject.CompareTag("collectible")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
   }
}
