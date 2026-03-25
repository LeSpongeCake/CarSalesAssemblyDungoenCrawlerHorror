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
    public int score { get; set; }

    public RectTransform ADpanel;
    public RectTransform Steampanel;
    int steamdown;
    public Vector2 targetADspot = new Vector2(765, 0);
    public Vector2 targetSteamspot = new Vector2(518, -447);
    public Vector2 Steamstartspot;
    public GameObject jumpscareimage;

    public AudioSource steamAudioSource;
    public AudioClip steamSound;
    bool steamSoundPlayed = false;

    public AudioSource adAudioSource;
    public AudioClip adSound;
    bool adSoundPlayed = false;

    public AudioSource carAudioSource;
    public AudioClip carFixedSound;
    bool carSoundPlayed = false;

    int adtrigger;
    int steamtrigger;
    int scaretrigger;

    void Start()
    {
        score = 0;
        steamdown = 0;

        Steamstartspot = Steampanel.anchoredPosition;
        adtrigger = UnityEngine.Random.Range(10, 71);
        steamtrigger = UnityEngine.Random.Range(10, 71);
        scaretrigger = UnityEngine.Random.Range(10, 71);

        Debug.Log("Event_Manager started");
        Debug.Log("Ad trigger = " + adtrigger);
        Debug.Log("Steam trigger = " + steamtrigger);
        Debug.Log("Scare trigger = " + scaretrigger);

        if (steamAudioSource != null)
        {
            steamAudioSource.playOnAwake = false;
            steamAudioSource.spatialBlend = 0f;
        }
        else
        {
            Debug.Log("Steam Audio Source is NOT assigned");
        }

        if (adAudioSource != null)
        {
            adAudioSource.playOnAwake = false;
            adAudioSource.spatialBlend = 0f;
        }
        else
        {
            Debug.Log("Ad Audio Source is NOT assigned");
        }

        if (carAudioSource != null)
        {
            carAudioSource.playOnAwake = false;
            carAudioSource.spatialBlend = 0f;
        }
        else
        {
            Debug.Log("Car Audio Source is NOT assigned");
        }

        if (steamSound == null) Debug.Log("Steam Sound is NOT assigned");
        if (adSound == null) Debug.Log("Ad Sound is NOT assigned");
        if (carFixedSound == null) Debug.Log("Car Fixed Sound is NOT assigned");
        if (timer == null) Debug.Log("Timer is NOT assigned");
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ItemCollected()
    {
        score += 1;
        display_score.text = "CAR PARTS: " + score;
        Debug.Log("Item collected. Score = " + score);
    }

    public void CarFixed()
    {
        Debug.Log("CarFixed called");

        if (score == 3)
        {
            score = 4;
            display_score.text = "CAR FIXED! NOW LEAVE";

            if (!carSoundPlayed && carAudioSource != null && carFixedSound != null)
            {
                carAudioSource.clip = carFixedSound;
                carAudioSource.Play();
                carSoundPlayed = true;
                Debug.Log("Car fixed sound played");
            }
        }
        else
        {
            Debug.Log("CarFixed called but score was not 3. Score = " + score);
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
        if (timer == null) return;

        current_Time = timer.timeRemaining;

        if (current_Time <= 0)
        {
            Gamewon = false;
            SceneManager.LoadScene("End");
        }

        if (current_Time <= adtrigger)
        {
            Debug.Log("Ad trigger reached at time " + current_Time);
            StartAd();

            if (!adSoundPlayed && adAudioSource != null && adSound != null)
            {
                adAudioSource.clip = adSound;
                adAudioSource.Play();
                adSoundPlayed = true;
                Debug.Log("Ad sound played");
            }
        }

        if (current_Time <= steamtrigger)
        {
            Debug.Log("Steam trigger reached at time " + current_Time);
            Steam();

            if (!steamSoundPlayed && steamAudioSource != null && steamSound != null)
            {
                steamAudioSource.clip = steamSound;
                steamAudioSource.Play();
                steamSoundPlayed = true;
                Debug.Log("Steam sound played");
            }
        }

        if (current_Time <= scaretrigger)
        {
            Debug.Log("Scare trigger reached at time " + current_Time);
            JumpScare();
            jumpscareimage.SetActive(false);
            scaretrigger = -1;
        }
    }

    public void StartAd()
    {
        if (ADpanel.anchoredPosition.x >= 765)
        {
            ADpanel.anchoredPosition = Vector2.MoveTowards(ADpanel.anchoredPosition, targetADspot, 160 * Time.deltaTime);
        }
    }

    public void Steam()
    {
        if (Steampanel.anchoredPosition.y < -447 && steamdown == 0)
        {
            Steampanel.anchoredPosition = Vector2.MoveTowards(Steampanel.anchoredPosition, targetSteamspot, 160 * Time.deltaTime);
        }
        else
        {
            steamdown = 1;
            Steampanel.anchoredPosition = Vector2.MoveTowards(Steampanel.anchoredPosition, Steamstartspot, 160 * Time.deltaTime);
        }
    }

    public void JumpScare()
    {
        jumpscareimage.SetActive(true);
    }
}