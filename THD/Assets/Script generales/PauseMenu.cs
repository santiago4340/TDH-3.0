using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject audioSettingsPanel;
    public Slider volumeSlider;
    public AudioSource gameplayAudio;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        audioSettingsPanel.SetActive(false);

        // Configurar el valor inicial del slider al volumen actual del audio source
        if (gameplayAudio != null)
            volumeSlider.value = gameplayAudio.volume;
    }

    void Update()
    {
        // Activar/desactivar el menú de pausa al presionar ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void OpenAudioSettings()
    {
        pauseMenuUI.SetActive(false);
        audioSettingsPanel.SetActive(true);
    }

    public void CloseAudioSettings()
    {
        audioSettingsPanel.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void AdjustVolume(float volume)
    {
        gameplayAudio.volume = volume;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
