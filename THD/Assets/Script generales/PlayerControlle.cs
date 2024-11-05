using System.Collections; // Agrega esta línea
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DashSettings dashSettings; // Referencia al Scriptable Object

    private bool isDashing = false;
    private float dashCooldownTimer = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isDashing && dashCooldownTimer <= 0)
        {
            StartCoroutine(Dash());
        }

        // Maneja el cooldown
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;

        // Guarda la posición inicial
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + transform.forward * dashSettings.dashDistance;

        float startTime = Time.time;

        while (Time.time < startTime + dashSettings.dashDuration)
        {
            float t = (Time.time - startTime) / dashSettings.dashDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        isDashing = false;
        dashCooldownTimer = dashSettings.cooldown; // Reinicia el cooldown
    }
}
