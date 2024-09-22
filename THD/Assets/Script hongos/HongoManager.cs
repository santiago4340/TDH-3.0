using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class HongoManager : MonoBehaviour
{
    public TextMeshProUGUI mushroomCounterText; // Referencia al texto de la UI
    private int mushroomCount = 0; // Contador de hongos atrapados

    // M�todo que se llama al iniciar el juego
    void Start()
    {
        UpdateMushroomCounter(); // Actualiza el texto inicial
    }

    // M�todo para contar un hongo atrapado
    public void CollectMushroom()
    {
        mushroomCount++; // Aumenta el contador
        UpdateMushroomCounter(); // Actualiza el texto en la UI
    }

    // M�todo para actualizar el texto del contador
    private void UpdateMushroomCounter()
    {
        mushroomCounterText.text = "Hongos atrapados: " + mushroomCount; // Actualiza el texto
    }
}

