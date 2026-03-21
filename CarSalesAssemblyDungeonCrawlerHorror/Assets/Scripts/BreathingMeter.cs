using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BreathingMeter : MonoBehaviour
{
    public float breathMeterValue;
    public float breathMeterMaxValue = 100f;
//U can modify the rate in the projectManager...thing with this script.
    [SerializeField] private float breathMeterDecreaseRate = 5f; 

    [SerializeField] private float pumpIncreaseAmount = 5f; // Amount to increase the breath meter when pumping

//Rendering part!!!!!!!!
    public TMP_Text BreathingPercentageText;
    public Slider BreathingSlider;



    bool isDead = false;
    void Start()
    {
        breathMeterValue = breathMeterMaxValue;
    }
    public void pump()
    {
        if (!isDead&& breathMeterValue < breathMeterMaxValue)
        {
            breathMeterValue = Mathf.Min(breathMeterValue + pumpIncreaseAmount, breathMeterMaxValue);
        }
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
            isDead = true;
        }
    //pump..
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pump();
        }

        // Update rendering!
        BreathingSlider.value = breathMeterValue / breathMeterMaxValue;
        BreathingPercentageText.text = Mathf.RoundToInt((breathMeterValue / breathMeterMaxValue) * 100) + "%";
        
    }

}
