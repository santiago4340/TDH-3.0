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

        // Asegurarse de que el cursor est� oculto y bloqueado al inicio del juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Configurar el valor inicial del slider al volumen actual del audio source
        if (gameplayAudio != null)
        {
            volumeSlider.value = gameplayAudio.volume; // Ajustar el slider al volumen actual
            gameplayAudio.volume = volumeSlider.value; // Aseg�rate de que el volumen inicial sea correcto
            if (!gameplayAudio.isPlaying)
            {
                gameplayAudio.Play(); // Asegurarte de que la m�sica est� sonando
            }
        }

        // Agregar el listener para el slider
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    void Update()
    {
        // Solo activar/desactivar el men� de pausa si no est� en el panel de audio
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

        // Ocultar y bloquear el cursor al reanudar el juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Mostrar y desbloquear el cursor cuando el juego est� en pausa
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OpenAudioSettings()
    {
        pauseMenuUI.SetActive(false);
        audioSettingsPanel.SetActive(true);
        // Asegurarse de que el cursor est� visible y desbloqueado en las configuraciones de audio
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseAudioSettings()
    {
        audioSettingsPanel.SetActive(false);
        pauseMenuUI.SetActive(true);
        // Vuelve a bloquear y ocultar el cursor al cerrar la configuraci�n de audio
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Se puede mantener visible si se desea
    }

    public void AdjustVolume(float volume)
    {
        if (gameplayAudio != null)
        {
            gameplayAudio.volume = Mathf.Clamp(volume, 0f, 1f); // Ajusta el volumen del AudioSource
            Debug.Log("Volumen ajustado a: " + gameplayAudio.volume); // Log para verificar el volumen
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
