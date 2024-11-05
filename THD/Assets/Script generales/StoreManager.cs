using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public TextMeshProUGUI goldText; // Texto para mostrar la cantidad de oro
    private int gold = 0; // Cantidad de oro que tiene el jugador
    private PotionCraftingManager potionCraftingManager;

    void Start()
    {
        potionCraftingManager = FindObjectOfType<PotionCraftingManager>();
        UpdateGoldText(); // Actualizar el texto de oro al inicio
        UpdateStoreUI(); // Actualizar la tienda al inicio
    }

    public void UpdateStoreUI()
    {
        // Aquí puedes agregar lógica para mostrar cuántas pociones hay disponibles para vender
        // Por ejemplo, podrías tener botones para vender cada tipo de poción
    }

    // Método para vender pociones de hongos
    public void SellMushroomPotion()
    {
        if (potionCraftingManager.GetMushroomPotionCount() > 0)
        {
            potionCraftingManager.DecreaseMushroomPotionCount(); // Disminuir el conteo
            gold += 50; // Añadir oro
            Debug.Log("¡Poción de Hongos vendida!");
            UpdateGoldText();
        }
        else
        {
            Debug.Log("No tienes pociones de hongos para vender.");
        }
    }

    // Método para vender pociones mixtas
    public void SellMixedPotion()
    {
        if (potionCraftingManager.GetMixedPotionCount() > 0)
        {
            potionCraftingManager.DecreaseMixedPotionCount(); // Disminuir el conteo
            gold += 100; // Añadir oro
            Debug.Log("¡Poción Mixta vendida!");
            UpdateGoldText();
        }
        else
        {
            Debug.Log("No tienes pociones mixtas para vender.");
        }
    }

    private void UpdateGoldText()
    {
        goldText.text = "Oro: " + gold; // Actualiza el texto del oro en la UI
    }
}
