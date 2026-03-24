using TMPro;
using UnityEngine;

public class End_Script : MonoBehaviour
{
    public TMP_Text displaytext;
    public void Start()
    {
        Event_Manager events = FindObjectOfType<Event_Manager>();
        Dead dead = FindObjectOfType<Dead>();
        
        if (events.Gamewon == true)
        {
            displaytext.text = "Congratulations, a winner is you";
        }
        if (events.Gamewon == false)
        {
            displaytext.text = "You were too slow";
        }
        if (dead.isDead == true)
        {
            displaytext.text = "You forgot to breathe";
        }
    }
    
}
