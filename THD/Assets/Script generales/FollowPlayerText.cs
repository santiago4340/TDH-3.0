using UnityEngine;
using TMPro;

public class FollowPlayerText : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public Camera playerCamera; // Referencia a la cámara del jugador
    private TextMeshProUGUI interactText; // Referencia al texto

    void Start()
    {
        interactText = GetComponent<TextMeshProUGUI>(); // Obtiene el componente TextMeshPro
        if (interactText == null)
        {
            Debug.LogError("El componente TextMeshProUGUI no se encontró en este GameObject.");
            return; // Sale del método si no se encuentra el componente
        }
        
        interactText.gameObject.SetActive(false); // Desactiva el texto al inicio
    }

    void Update()
    {
        if (playerCamera == null || player == null) 
        {
            Debug.LogError("Player o PlayerCamera no están asignados.");
            return; // Sale del método si falta alguna referencia
        }

        // Calcula la posición para que el texto siga al jugador
        transform.LookAt(playerCamera.transform);
        
        // Mantiene el texto visible si el jugador está cerca del caldero
        if (IsPlayerNear())
        {
            interactText.gameObject.SetActive(true); // Activa el texto si el jugador está cerca
        }
        else
        {
            interactText.gameObject.SetActive(false); // Desactiva el texto si el jugador está lejos
        }
    }

    private bool IsPlayerNear()
    {
        // Ajusta la distancia según sea necesario
        float distance = Vector3.Distance(player.position, transform.position);
        return distance < 5f; // Cambia este valor para ajustar la distancia de activación
    }
}
