using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class MenuController : MonoBehaviour
{
    // Método para iniciar el juego
    public void PlayGame()
    {
        // Aquí puedes cargar la escena del juego
        SceneManager.LoadScene("Gameplay"); // Cambia el nombre por el de tu escena
    }

    // Método para salir del juego
    public void QuitGame()
    {
        // Esto cerrará el juego
        Application.Quit();
    }
}
