using UnityEngine;

public class StoreInteractable : MonoBehaviour
{
    public GameObject storeUI; // Referencia al panel de UI de la tienda
    private bool isNearStore = false; // Para verificar si el jugador está cerca de la tienda

    void Update()
    {
        // Detecta si el jugador está cerca y presiona "E"
        if (isNearStore && Input.GetKeyDown(KeyCode.E))
        {
            ToggleStoreUI();
        }
    }

    private void ToggleStoreUI()
    {
        bool isActive = storeUI.activeSelf;
        storeUI.SetActive(!isActive); // Alterna la visibilidad de la UI

        // Controlar el estado del cursor
        if (!isActive)
        {
            Cursor.lockState = CursorLockMode.None; // Libera el cursor
            Cursor.visible = true; // Hace visible el cursor
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
            Cursor.visible = false; // Oculta el cursor
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearStore = true;
            // Opcional: Mostrar un mensaje en pantalla como "Presiona E para interactuar"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearStore = false;
            storeUI.SetActive(false); // Cierra la UI si el jugador se aleja
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
            Cursor.visible = false; // Oculta el cursor
        }
    }
}
