using UnityEngine;

public class TomateEnemy : MonoBehaviour
{
    public float speed = 3f; // Velocidad a la que huir� el tomate
    public float jumpForce = 5f; // Fuerza del salto
    public float detectionRange = 5f; // Rango en el que detectar� al jugador
    private Transform player; // Referencia al jugador
    private bool isJumping = false; // Controla si el tomate est� saltando

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encuentra al jugador por su Tag
    }

    void Update()
    {
        Vector3 directionToPlayer = transform.position - player.position; // Direcci�n opuesta al jugador
        float distanceToPlayer = directionToPlayer.magnitude; // Calcula la distancia

        if (distanceToPlayer < detectionRange)
        {
            // Movimiento hacia el jugador
            Vector3 fleeDirection = directionToPlayer.normalized; // Huye en direcci�n opuesta al jugador
            transform.position += fleeDirection * speed * Time.deltaTime;

            // L�gica de salto
            if (!isJumping)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        isJumping = true; // Indica que el tomate est� saltando
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Aplica la fuerza de salto

        // Regresa a la normalidad despu�s de un tiempo
        Invoke("ResetJump", 1f); // Cambia el tiempo seg�n lo que necesites
    }

    private void ResetJump()
    {
        isJumping = false; // Permite que el tomate salte nuevamente
    }
}
