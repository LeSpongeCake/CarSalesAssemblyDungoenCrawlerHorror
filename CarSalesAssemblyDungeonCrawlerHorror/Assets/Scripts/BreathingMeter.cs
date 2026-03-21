using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BreathingMeter : MonoBehaviour
{
    private Dead deadScript;

    public float breathMeterValue;
    public float breathMeterMaxValue = 100f;

//U can modify the rate in the projectManager...or objects with this script.
    [Header("Meter change Settings")]
    [SerializeField] private float breathMeterDecreaseRate = 5f; 

    [SerializeField] private float pumpIncreaseAmount = 5f; // Amount to increase the breath meter when pumping

//Rendering part!!!!!!!!
    [Header("UI Elements")]
    public TMP_Text BreathingPercentageText;
    public Slider BreathingSlider;
    public Image BreathingFill;
    [SerializeField] private float blinkingThreshold = 30f; 
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color blinkingColor = Color.red;


    void Start()
    {
        breathMeterValue = breathMeterMaxValue;
        deadScript = FindAnyObjectByType<Dead>();

    }
    public void pump()
    {
        if (!deadScript.isDead && breathMeterValue < breathMeterMaxValue)
        {
            breathMeterValue = Mathf.Min(breathMeterValue + pumpIncreaseAmount, breathMeterMaxValue);
        }
    }

    public void slideBlink()
    {
        float t = Mathf.PingPong(Time.time, 0.8f);
        BreathingFill.color = Color.Lerp(blinkingColor, normalColor, t);
    }

    // Update is called once per frame
    void Update()
    {
        if (breathMeterValue > 0)
        {
            breathMeterValue -= breathMeterDecreaseRate * Time.deltaTime;
        }
        else
        {
            breathMeterValue = 0;
            deadScript.Die();
        }

    //pump..
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pump();
        }

        // Update rendering!
        BreathingSlider.value = breathMeterValue / breathMeterMaxValue;
        BreathingPercentageText.text = Mathf.RoundToInt((breathMeterValue / breathMeterMaxValue) * 100) + "%";

        if (breathMeterValue  <= blinkingThreshold)
        {
            slideBlink();
        }
        else {
            BreathingFill.color = normalColor;
        }


    }
    // For restart the game
    // public void resetBreathingMeter()
    // {
    //   breathMeterValue = breathMeterMaxValue;
    // }

}
