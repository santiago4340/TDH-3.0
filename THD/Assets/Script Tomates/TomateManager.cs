using UnityEngine;
using TMPro;

public class TomateManager : MonoBehaviour
{
    public TextMeshProUGUI tomatoCounterText; // Referencia al texto de la UI
    private int tomatoCount = 0; // Contador de tomates atrapados

    void Start()
    {
        UpdateTomatoCounter(); // Actualiza el texto inicial
    }

    public void CollectTomato()
    {
        tomatoCount++; // Aumenta el contador
        UpdateTomatoCounter(); // Actualiza el texto en la UI

        // Actualiza la UI de pociones después de recolectar
        FindObjectOfType<PotionCraftingManager>().UpdatePotionUI();
    }

    private void UpdateTomatoCounter()
    {
        tomatoCounterText.text = "Tomates: " + tomatoCount; // Actualiza el texto
    }

    public int GetTomatoCount()
    {
        return tomatoCount;
    }

    public void UseTomatoes(int amount)
    {
        if (tomatoCount >= amount)
        {
            tomatoCount -= amount; // Disminuye la cantidad de tomates
            UpdateTomatoCounter(); // Actualiza el texto
        }
        else
        {
            Debug.Log("No tienes suficientes tomates.");
        }
    }
}
