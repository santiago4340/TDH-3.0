using UnityEngine;
using UnityEngine.UI;

public class AdjustUI : MonoBehaviour
{
    // Referencia a la imagen de fondo
    public Image backgroundImage;
    // Referencia a los botones
    public Button playButton;
    public Button quitButton;

    void Start()
    {
        // Ajustar la imagen de fondo para que ocupe toda la pantalla
        AdjustBackground();

        // Ajustar los botones
        AdjustButtons();
    }

    void AdjustBackground()
    {
        // Asegúrate de que la imagen de fondo cubra toda la pantalla
        RectTransform rt = backgroundImage.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, 0);
        rt.anchorMax = new Vector2(1, 1);
        rt.offsetMin = new Vector2(0, 0); // Esto hará que el fondo empiece desde la esquina inferior izquierda
        rt.offsetMax = new Vector2(0, 0); // Esto hará que el fondo llegue hasta la esquina superior derecha
    }

    void AdjustButtons()
    {
        // Ajustar el botón de Play
        RectTransform playRT = playButton.GetComponent<RectTransform>();
        playRT.anchorMin = new Vector2(0.5f, 0.5f);
        playRT.anchorMax = new Vector2(0.5f, 0.5f);
        playRT.anchoredPosition = new Vector2(0, 50); // Posición vertical del botón de Play

        // Ajustar el botón de Quit
        RectTransform quitRT = quitButton.GetComponent<RectTransform>();
        quitRT.anchorMin = new Vector2(0.5f, 0.5f);
        quitRT.anchorMax = new Vector2(0.5f, 0.5f);
        quitRT.anchoredPosition = new Vector2(0, -50); // Posición vertical del botón de Quit
    }
}
