using UnityEngine;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        Application.targetFrameRate = 60;

        SceneManager.LoadScene("MainMenu");
    }
}
