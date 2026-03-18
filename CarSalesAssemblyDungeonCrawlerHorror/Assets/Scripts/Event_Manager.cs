using UnityEngine;


public class Event_Manager : MonoBehaviour
{
    public float current_Time;
    public Timer timer;
    public Background_Manager background_Manager;

    public Sprite sprite1;

    // current event chain - what level are we at (should change to something better)
    int stage = 1;
    
    void Update()
    {
        current_Time = timer.timeRemaining;

        if (stage ==1 && current_Time <= 50)
        {
            background_Manager.Change_Background(sprite1);
            stage += 1;
        }
    }
}
