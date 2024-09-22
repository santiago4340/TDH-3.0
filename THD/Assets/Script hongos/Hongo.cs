using UnityEngine;

public class Hongo : MonoBehaviour
{
    private HongoManager hongoManager;

    void Start()
    {
        // Encuentra el script HongoManager en la escena
        hongoManager = FindObjectOfType<HongoManager>();
    }

    // Método que se llama cuando el collider del jugador choca con el hongo
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            hongoManager.CollectMushroom(); // Aumenta el contador en HongoManager
            Destroy(gameObject); // Destruye el hongo
        }
    }
}
