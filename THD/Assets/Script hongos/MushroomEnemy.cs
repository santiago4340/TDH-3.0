using UnityEngine;

public class MushroomEnemy : MonoBehaviour
{
    public float speed = 3f; // Velocidad a la que huirá el hongo
    public float detectionRange = 5f; // Rango en el que detectará al jugador
    private Transform player; // Referencia al jugador

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
            Vector3 fleeDirection = directionToPlayer.normalized; // Huye en dirección opuesta al jugador
            transform.position += fleeDirection * speed * Time.deltaTime;
        }
    }
}
