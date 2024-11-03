using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class TomateManager : MonoBehaviour
{
    public TextMeshProUGUI tomatoCounterText; // Referencia al texto de la UI
    private int tomatoCount = 0; // Contador de tomates atrapados

    // M�todo que se llama al iniciar el juego
    void Start()
    {
        UpdateTomatoCounter(); // Actualiza el texto inicial
    }

    // M�todo para contar un tomate atrapado
    public void CollectTomato()
    {
        tomatoCount++; // Aumenta el contador
        UpdateTomatoCounter(); // Actualiza el texto en la UI
    }

    // M�todo para actualizar el texto del contador
    private void UpdateTomatoCounter()
    {
        tomatoCounterText.text = "Tomates: " + tomatoCount; // Actualiza el texto
    }
}
