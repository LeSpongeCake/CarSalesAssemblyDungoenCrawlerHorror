using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{
    public bool isDead = false;
    public TMP_Text WastedText;
    public GameObject WastedPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDead = false;
        if (WastedPanel != null)
        {
            WastedPanel.SetActive(false);
        }
        if (WastedText != null)
        {
            WastedText.text = "";
        }
    }

    // Update is called once per frame

        public void Die()
        {
            if (isDead) return; 

            isDead = true;

            Debug.Log("Player is dead");

            if (WastedPanel != null)
                WastedPanel.SetActive(true);
            if (WastedText != null)                
                WastedText.text = "WASTED";
        }

    void Update()
    {

        
    }

   // For restart the game
    /*
    public void resetDeath()
    {
        isDead = false;
        if (WastedPanel != null)
        {
            WastedPanel.SetActive(false);
        }
        if (WastedText != null)
        {
            WastedText.text = "";
        }
    }
    */
        
        
}
