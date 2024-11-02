using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale; // Almacena la escala original del bot�n
    public float hoverScaleFactor = 1.1f; // Factor de escala al hacer hover

    void Start()
    {
        originalScale = transform.localScale; // Guardar la escala original
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Aumentar el tama�o del bot�n al hacer hover
        transform.localScale = originalScale * hoverScaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Restaurar el tama�o original del bot�n al salir del hover
        transform.localScale = originalScale;
    }
}
