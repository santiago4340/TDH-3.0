using UnityEngine;
using TMPro;

public class HongoManager : MonoBehaviour
{
    public TextMeshProUGUI mushroomCounterText; // Referencia al texto de la UI
    private int mushroomCount = 0; // Contador de hongos atrapados

    void Start()
    {
        UpdateMushroomCounter(); // Actualiza el texto inicial
    }

    // Método para contar un hongo atrapado
    public void CollectMushroom()
    {
        mushroomCount++; // Aumenta el contador
        UpdateMushroomCounter(); // Actualiza el texto en la UI

        // Actualiza la UI de pociones después de recolectar
        FindObjectOfType<PotionCraftingManager>().UpdatePotionUI();
    }

    // Método para actualizar el texto del contador
    private void UpdateMushroomCounter()
    {
        mushroomCounterText.text = "Hongos: " + mushroomCount; // Actualiza el texto
    }

    public int GetMushroomCount()
    {
        return mushroomCount;
    }

    public void UseMushrooms(int amount)
    {
        if (mushroomCount >= amount)
        {
            mushroomCount -= amount;
            UpdateMushroomCounter();
        }
        else
        {
            Debug.Log("No tienes suficientes hongos.");
        }
    }
}
