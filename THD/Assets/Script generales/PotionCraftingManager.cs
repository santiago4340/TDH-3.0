using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionCraftingManager : MonoBehaviour
{
    public HongoManager hongoManager; // Referencia al gestor de hongos
    public TomateManager tomateManager; // Referencia al gestor de tomates

    public TextMeshProUGUI mushroomPotionText; // Texto para la poción de hongos
    public TextMeshProUGUI mixedPotionText; // Texto para la poción mixta
        
    public Button mushroomPotionButton; // Botón para crear poción de hongos
    public Button mixedPotionButton; // Botón para crear poción mixta

    // Inventario de pociones
    private int mushroomPotionCount = 0; // Contador de pociones de hongos
    private int mixedPotionCount = 0; // Contador de pociones mixtas

    void Start()
    {
        // Asignar listeners a los botones
        mushroomPotionButton.onClick.AddListener(CreateMushroomPotion);
        mixedPotionButton.onClick.AddListener(CreateMixedPotion);

        // Actualizar la UI al inicio
        UpdatePotionUI();
    }

    // Método para actualizar los textos y estados de los botones
    public void UpdatePotionUI()
    {
        int currentMushrooms = hongoManager.GetMushroomCount();
        int currentTomatoes = tomateManager.GetTomatoCount();

        // Actualizar texto para la Poción de Hongos
        mushroomPotionText.text = $"Poción de Hongos: {currentMushrooms}/2 hongos (Tienes: {mushroomPotionCount})";
        mushroomPotionButton.interactable = currentMushrooms >= 2;

        // Actualizar texto para la Poción de Hongo y Tomate
        mixedPotionText.text = $"Poción de Hongo y Tomate: {currentMushrooms}/2 hongos, {currentTomatoes}/1 tomate (Tienes: {mixedPotionCount})";
        mixedPotionButton.interactable = currentMushrooms >= 2 && currentTomatoes >= 1;
    }

    // Método para crear una Poción de Hongos
    public void CreateMushroomPotion()
    {
        if (hongoManager.GetMushroomCount() >= 2)
        {
            hongoManager.UseMushrooms(2);
            mushroomPotionCount++; // Incrementar el conteo de pociones de hongos
            Debug.Log("¡Poción de Hongos creada!");
            UpdatePotionUI();
            // También actualiza la tienda para reflejar los cambios
            FindObjectOfType<StoreManager>().UpdateStoreUI();
        }
        else
        {
            Debug.Log("No tienes suficientes hongos para crear una Poción de Hongos.");
        }
    }

    // Método para crear una Poción de Hongo y Tomate
    public void CreateMixedPotion()
    {
        if (hongoManager.GetMushroomCount() >= 2 && tomateManager.GetTomatoCount() >= 1)
        {
            hongoManager.UseMushrooms(2);
            tomateManager.UseTomatoes(1);
            mixedPotionCount++; // Incrementar el conteo de pociones mixtas
            Debug.Log("¡Poción de Hongo y Tomate creada!");
            UpdatePotionUI();
            // También actualiza la tienda para reflejar los cambios
            FindObjectOfType<StoreManager>().UpdateStoreUI();
        }
        else
        {
            Debug.Log("No tienes suficientes ingredientes para crear una Poción de Hongo y Tomate.");
        }
    }

    // Métodos para obtener la cantidad de pociones
    public int GetMushroomPotionCount()
    {
        return mushroomPotionCount;
    }

    public int GetMixedPotionCount()
    {
        return mixedPotionCount;
    }

    // Método para disminuir el conteo de pociones de hongos
    public void DecreaseMushroomPotionCount()
    {
        if (mushroomPotionCount > 0)
        {
            mushroomPotionCount--;
        }
    }

    // Método para disminuir el conteo de pociones mixtas
    public void DecreaseMixedPotionCount()
    {
        if (mixedPotionCount > 0)
        {
            mixedPotionCount--;
        }
    }
}
