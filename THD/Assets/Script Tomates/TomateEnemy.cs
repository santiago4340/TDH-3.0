using UnityEngine;

public class TomateEnemy : MonoBehaviour
{
    public float speed = 3f; // Velocidad a la que huirá el tomate
    public float jumpForce = 5f; // Fuerza del salto
    public float detectionRange = 5f; // Rango en el que detectará al jugador
    private Transform player; // Referencia al jugador
    private bool isJumping = false; // Controla si el tomate está saltando

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encuentra al jugador por su Tag
    }

    void Update()
    {
        Vector3 directionToPlayer = transform.position - player.position; // Dirección opuesta al jugador
        float distanceToPlayer = directionToPlayer.magnitude; // Calcula la distancia

        if (distanceToPlayer < detectionRange)
        {
            // Movimiento hacia el jugador
            Vector3 fleeDirection = directionToPlayer.normalized; // Huye en dirección opuesta al jugador
            transform.position += fleeDirection * speed * Time.deltaTime;

            // Lógica de salto
            if (!isJumping)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        isJumping = true; // Indica que el tomate está saltando
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Aplica la fuerza de salto

        // Regresa a la normalidad después de un tiempo
        Invoke("ResetJump", 1f); // Cambia el tiempo según lo que necesites
    }

    private void ResetJump()
    {
        isJumping = false; // Permite que el tomate salte nuevamente
    }
}
