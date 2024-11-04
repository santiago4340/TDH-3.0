using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionCraftingManager : MonoBehaviour
{
    public HongoManager hongoManager;
    public TomateManager tomateManager;

    public TextMeshProUGUI mushroomPotionText;
    public TextMeshProUGUI mixedPotionText;

    public Button mushroomPotionButton;
    public Button mixedPotionButton;

    void Start()
    {
        // Asignar listeners a los botones
        mushroomPotionButton.onClick.AddListener(CreateMushroomPotion);
        mixedPotionButton.onClick.AddListener(CreateMixedPotion);

        // Actualizar la UI al inicio
        UpdatePotionUI();
    }

    // M�todo para actualizar los textos y estados de los botones
    public void UpdatePotionUI()
    {
        int currentMushrooms = hongoManager.GetMushroomCount();
        int currentTomatoes = tomateManager.GetTomatoCount();

        // Actualizar texto para la Poci�n de Hongos
        mushroomPotionText.text = $"Poci�n de Hongos: {currentMushrooms}/2 hongos";
        mushroomPotionButton.interactable = currentMushrooms >= 2;

        // Actualizar texto para la Poci�n de Hongo y Tomate
        mixedPotionText.text = $"Poci�n de Hongo y Tomate: {currentMushrooms}/2 hongos, {currentTomatoes}/1 tomate";
        mixedPotionButton.interactable = currentMushrooms >= 2 && currentTomatoes >= 1;
    }

    // M�todo para crear una Poci�n de Hongos
    public void CreateMushroomPotion()
    {
        if (hongoManager.GetMushroomCount() >= 2)
        {
            hongoManager.UseMushrooms(2);
            Debug.Log("�Poci�n de Hongos creada!");
            // Aqu� puedes a�adir l�gica adicional para otorgar la poci�n al jugador
            UpdatePotionUI();
        }
        else
        {
            Debug.Log("No tienes suficientes hongos para crear una Poci�n de Hongos.");
        }
    }

    // M�todo para crear una Poci�n de Hongo y Tomate
    public void CreateMixedPotion()
    {
        if (hongoManager.GetMushroomCount() >= 2 && tomateManager.GetTomatoCount() >= 1)
        {
            hongoManager.UseMushrooms(2);
            tomateManager.UseTomatoes(1);
            Debug.Log("�Poci�n de Hongo y Tomate creada!");
            // Aqu� puedes a�adir l�gica adicional para otorgar la poci�n al jugador
            UpdatePotionUI();
        }
        else
        {
            Debug.Log("No tienes suficientes ingredientes para crear una Poci�n de Hongo y Tomate.");
        }
    }
}
