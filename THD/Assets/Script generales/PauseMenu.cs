using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject audioSettingsPanel;
    public Slider volumeSlider;
    public AudioSource gameplayAudio;
    public CameraController cameraController; // Referencia al controlador de la cámara

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        audioSettingsPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (gameplayAudio != null)
        {
            volumeSlider.value = gameplayAudio.volume;
            gameplayAudio.volume = volumeSlider.value;
            if (!gameplayAudio.isPlaying)
            {
                gameplayAudio.Play();
            }
        }

        volumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !audioSettingsPanel.activeSelf)
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

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (cameraController != null)
        {
            cameraController.EnableCameraMovement(true);
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (cameraController != null)
        {
            cameraController.EnableCameraMovement(false);
        }
    }

    public void OpenAudioSettings()
    {
        pauseMenuUI.SetActive(false);
        audioSettingsPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (cameraController != null)
        {
            cameraController.EnableCameraMovement(false); // Asegura que la cámara esté bloqueada
        }
    }

    public void CloseAudioSettings()
    {
        audioSettingsPanel.SetActive(false);
        pauseMenuUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (cameraController != null)
        {
            cameraController.EnableCameraMovement(false); // Asegura que la cámara siga bloqueada en el menú de pausa
        }
    }

    public void AdjustVolume(float volume)
    {
        if (gameplayAudio != null)
        {
            gameplayAudio.volume = Mathf.Clamp(volume, 0f, 1f);
            Debug.Log("Volumen ajustado a: " + gameplayAudio.volume);
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
