using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public AudioMixer audioMixer;
    public Slider audioSlider;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        if (FindObjectOfType<GameHandler>() != null)
        {
            FindObjectOfType<GameHandler>().DestroyGameHandler();
        }

        SceneManager.LoadScene(1);
    }

    public void ResetVolume()
    {
        audioSlider.value = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
