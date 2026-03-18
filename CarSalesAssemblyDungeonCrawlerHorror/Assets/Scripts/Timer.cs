using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text displayTime;
    public float timeRemaining {get; set;}
    
    void Start()
    {
        timeRemaining = 60;
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        // rounding down the timer to 4 digits
        double b = System.Math.Round(timeRemaining,2);

        displayTime.text = b.ToString();
    }
}
