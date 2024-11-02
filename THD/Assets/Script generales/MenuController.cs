using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class MenuController : MonoBehaviour
{
    // M�todo para iniciar el juego
    public void PlayGame()
    {
        // Aqu� puedes cargar la escena del juego
        SceneManager.LoadScene("Gameplay"); // Cambia el nombre por el de tu escena
    }

    // M�todo para salir del juego
    public void QuitGame()
    {
        // Esto cerrar� el juego
        Application.Quit();
    }
}
