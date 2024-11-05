using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public TextMeshProUGUI goldText; // Texto para mostrar la cantidad de oro
    public TextMeshProUGUI upgradeCostText; // Texto para mostrar el costo de la mejora
    public Button upgradeButton; // Botón de mejora

    private int gold = 0; // Cantidad de oro que tiene el jugador
    private int upgradeCost = 100; // Costo inicial de la mejora
    private PotionCraftingManager potionCraftingManager;

    void Start()
    {
        potionCraftingManager = FindObjectOfType<PotionCraftingManager>();
        UpdateGoldText(); // Actualizar el texto de oro al inicio
        UpdateUpgradeCostText(); // Actualizar el texto de costo de mejora al inicio

        // Asigna el método Upgrade al evento OnClick del botón de mejora
        if (upgradeButton != null)
        {
            upgradeButton.onClick.AddListener(Upgrade); 
        }
    }

    public void UpdateStoreUI()
    {
        // Aquí puedes agregar lógica para mostrar cuántas pociones hay disponibles para vender
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

    // Método para la mejora
    public void Upgrade()
    {
        if (gold >= upgradeCost)
        {
            gold -= upgradeCost; // Deduce el oro
            upgradeCost += 50; // Incrementa el costo de la siguiente mejora (puedes ajustar este valor)

            Debug.Log("¡Mejora comprada!");
            UpdateGoldText();
            UpdateUpgradeCostText();
        }
        else
        {
            Debug.Log("No tienes suficiente oro para mejorar.");
        }
    }

    private void UpdateGoldText()
    {
        goldText.text = "Oro: " + gold; // Actualiza el texto del oro en la UI
    }

    private void UpdateUpgradeCostText()
    {
        upgradeCostText.text = "Costo: " + upgradeCost; // Actualiza el texto del costo de mejora
    }
}
