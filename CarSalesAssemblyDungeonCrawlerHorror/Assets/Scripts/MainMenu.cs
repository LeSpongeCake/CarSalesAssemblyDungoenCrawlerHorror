using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
