using UnityEngine;

public class BreathingMeter : MonoBehaviour
{
    public float breathMeterValue;
    public float breathMeterMaxValue = 100f;
    [SerializeField] private float breathMeterDecreaseRate = 5f; 

    bool isDead = false;
    void Start()
    {
        breathMeterValue = breathMeterMaxValue;
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
            bool isDead = true;
        }
        
    }
    public void pump()
    {
        if (!isDead&& breathMeterValue < breathMeterMaxValue)
        {
            breathMeterValue = Mathf.Min(breathMeterValue + 20f, breathMeterMaxValue);
        }
    }

}
