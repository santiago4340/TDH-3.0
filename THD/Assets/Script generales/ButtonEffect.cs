using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale; // Almacena la escala original del botón
    public float hoverScaleFactor = 1.1f; // Factor de escala al hacer hover

    void Start()
    {
        originalScale = transform.localScale; // Guardar la escala original
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Aumentar el tamaño del botón al hacer hover
        transform.localScale = originalScale * hoverScaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Restaurar el tamaño original del botón al salir del hover
        transform.localScale = originalScale;
    }
}
