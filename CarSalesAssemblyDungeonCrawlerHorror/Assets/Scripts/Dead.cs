using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame

        public void Die()
        {
            if (isDead) return; 

            isDead = true;

            Debug.Log("Player is dead");

            SceneManager.LoadScene("End");
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
