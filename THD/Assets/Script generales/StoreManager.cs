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
        // Aqu� puedes agregar l�gica para mostrar cu�ntas pociones hay disponibles para vender
        // Por ejemplo, podr�as tener botones para vender cada tipo de poci�n
    }

    // M�todo para vender pociones de hongos
    public void SellMushroomPotion()
    {
        if (potionCraftingManager.GetMushroomPotionCount() > 0)
        {
            potionCraftingManager.DecreaseMushroomPotionCount(); // Disminuir el conteo
            gold += 50; // A�adir oro
            Debug.Log("�Poci�n de Hongos vendida!");
            UpdateGoldText();
        }
        else
        {
            Debug.Log("No tienes pociones de hongos para vender.");
        }
    }

    // M�todo para vender pociones mixtas
    public void SellMixedPotion()
    {
        if (potionCraftingManager.GetMixedPotionCount() > 0)
        {
            potionCraftingManager.DecreaseMixedPotionCount(); // Disminuir el conteo
            gold += 100; // A�adir oro
            Debug.Log("�Poci�n Mixta vendida!");
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
