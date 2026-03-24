using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Event_Manager : MonoBehaviour
{
    public float current_Time;
    public Timer timer;
    public Background_Manager background_Manager;
    public TMP_Text display_score;
    public bool Gamewon;
    public int score {get; set;}

    public RectTransform ADpanel;
    public RectTransform Steampanel;
    int steamdown;
    public UnityEngine.Vector2 targetADspot = new UnityEngine.Vector2(765, 0);
    public UnityEngine.Vector2 targetSteamspot = new UnityEngine.Vector2(518, -447);
    public UnityEngine.Vector2 Steamstartspot;
    public GameObject jumpscareimage;

    int adtrigger;
    int steamtrigger;
    int scaretrigger;

    void Start()
    {
        score = 0;
        steamdown = 0;

        Steamstartspot = Steampanel.anchoredPosition;
        adtrigger = Random.Range(10, 71);
        steamtrigger = Random.Range(10, 71);
        scaretrigger = Random.Range(10, 71);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ItemCollected()
    {
        score += 1;
        display_score.text = "CAR PARTS: " + score;
    }

    public void CarFixed()
    {
        if (score == 3)
        {
            score = 4;
            display_score.text = "CAR FIXED! NOW LEAVE";
        }
    }

    public void GameWon()
    {
        if (score == 4)
        {
            Gamewon = true;
            SceneManager.LoadScene("End");
        }
    }

    public void Update()
    {
        current_Time = timer.timeRemaining;
        if (current_Time <= 0)
        {
            Gamewon = false;
            SceneManager.LoadScene("End");
        }

        if (current_Time <= adtrigger)
        {
            StartAd();
        }
        if (current_Time <= steamtrigger)
        {
            Steam();
        }
        if (current_Time <= scaretrigger)
        {
            JumpScare();
            float counter = 0;
            while (counter < 4)
            {
                counter += Time.deltaTime;
            }
            jumpscareimage.SetActive(false);
            scaretrigger = 100;
        }
    }

    public void StartAd()
    {
        if (ADpanel.anchoredPosition.x >= 765)
        {
            ADpanel.anchoredPosition = UnityEngine.Vector2.MoveTowards(ADpanel.anchoredPosition, targetADspot, 120 * Time.deltaTime);
        }
    }

    public void Steam()
    {
        if (Steampanel.anchoredPosition.y < -447 && steamdown == 0)
        {
            Steampanel.anchoredPosition = UnityEngine.Vector2.MoveTowards(Steampanel.anchoredPosition, targetADspot, 120 * Time.deltaTime);
        }
        else 
        {
            steamdown = 1;
            Steampanel.anchoredPosition = UnityEngine.Vector2.MoveTowards(Steampanel.anchoredPosition, Steamstartspot, 120 * Time.deltaTime);
        }
    }

    public void JumpScare()
    {
        jumpscareimage.SetActive(true); 
    }

}
