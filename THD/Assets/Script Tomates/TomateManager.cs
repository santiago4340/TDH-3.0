using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class TomateManager : MonoBehaviour
{
    public TextMeshProUGUI tomatoCounterText; // Referencia al texto de la UI
    private int tomatoCount = 0; // Contador de tomates atrapados

    // Método que se llama al iniciar el juego
    void Start()
    {
        UpdateTomatoCounter(); // Actualiza el texto inicial
    }

    // Método para contar un tomate atrapado
    public void CollectTomato()
    {
        tomatoCount++; // Aumenta el contador
        UpdateTomatoCounter(); // Actualiza el texto en la UI
    }

    // Método para actualizar el texto del contador
    private void UpdateTomatoCounter()
    {
        tomatoCounterText.text = "Tomates: " + tomatoCount; // Actualiza el texto
    }
}
