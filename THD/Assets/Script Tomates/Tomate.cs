using UnityEngine;

public class Tomate : MonoBehaviour
{
    private TomateManager tomateManager;

    void Start()
    {
        // Encuentra el script TomateManager en la escena
        tomateManager = FindObjectOfType<TomateManager>();
    }

    // Método que se llama cuando el collider del jugador choca con el tomate
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            tomateManager.CollectTomato(); // Aumenta el contador en TomateManager
            Destroy(gameObject); // Destruye el tomate
        }
    }
}
