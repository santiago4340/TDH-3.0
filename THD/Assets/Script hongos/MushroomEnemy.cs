using UnityEngine;

public class MushroomEnemy : MonoBehaviour
{
    public float speed = 3f; // Velocidad a la que huir� el hongo
    public float detectionRange = 5f; // Rango en el que detectar� al jugador
    private Transform player; // Referencia al jugador

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
            Vector3 fleeDirection = directionToPlayer.normalized; // Huye en direcci�n opuesta al jugador
            transform.position += fleeDirection * speed * Time.deltaTime;
        }
    }
}
