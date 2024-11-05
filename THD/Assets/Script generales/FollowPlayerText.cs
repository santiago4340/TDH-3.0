using UnityEngine;
using TMPro;

public class FollowPlayerText : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public Camera playerCamera; // Referencia a la c�mara del jugador
    private TextMeshProUGUI interactText; // Referencia al texto

    void Start()
    {
        interactText = GetComponent<TextMeshProUGUI>(); // Obtiene el componente TextMeshPro
        if (interactText == null)
        {
            Debug.LogError("El componente TextMeshProUGUI no se encontr� en este GameObject.");
            return; // Sale del m�todo si no se encuentra el componente
        }
        
        interactText.gameObject.SetActive(false); // Desactiva el texto al inicio
    }

    void Update()
    {
        if (playerCamera == null || player == null) 
        {
            Debug.LogError("Player o PlayerCamera no est�n asignados.");
            return; // Sale del m�todo si falta alguna referencia
        }

        // Calcula la posici�n para que el texto siga al jugador
        transform.LookAt(playerCamera.transform);
        
        // Mantiene el texto visible si el jugador est� cerca del caldero
        if (IsPlayerNear())
        {
            interactText.gameObject.SetActive(true); // Activa el texto si el jugador est� cerca
        }
        else
        {
            interactText.gameObject.SetActive(false); // Desactiva el texto si el jugador est� lejos
        }
    }

    private bool IsPlayerNear()
    {
        // Ajusta la distancia seg�n sea necesario
        float distance = Vector3.Distance(player.position, transform.position);
        return distance < 5f; // Cambia este valor para ajustar la distancia de activaci�n
    }
}
