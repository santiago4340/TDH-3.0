using UnityEngine;

public class CalderoInteractivo : MonoBehaviour
{
    public GameObject craftingUI; // Referencia al panel de UI de pociones
    private bool isNearCaldero = false; // Para verificar si el jugador está cerca del caldero

    void Update()
    {
        // Detecta si el jugador está cerca y presiona "E"
        if (isNearCaldero && Input.GetKeyDown(KeyCode.E))
        {
            ToggleCraftingUI();
        }
    }

    private void ToggleCraftingUI()
    {
        bool isActive = craftingUI.activeSelf;
        craftingUI.SetActive(!isActive); // Alterna la visibilidad de la UI

        // Controlar el estado del cursor
        if (!isActive)
        {
            // Si se abre la UI, bloquea el cursor
            Cursor.lockState = CursorLockMode.None; // Libera el cursor
            Cursor.visible = true; // Hace visible el cursor
        }
        else
        {
            // Si se cierra la UI, vuelve a bloquear el cursor
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
            Cursor.visible = false; // Oculta el cursor
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearCaldero = true;
            // Opcional: Mostrar un mensaje en pantalla como "Presiona E para interactuar"
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearCaldero = false;
            craftingUI.SetActive(false); // Cierra la UI si el jugador se aleja
            // Opcional: Ocultar el mensaje de interacción

            // Asegúrate de volver a bloquear el cursor al salir
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
            Cursor.visible = false; // Oculta el cursor
        }
    }
}
