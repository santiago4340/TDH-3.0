using UnityEngine;

[CreateAssetMenu(fileName = "NewDashSettings", menuName = "ScriptableObjects/DashSettings")]
public class DashSettings : ScriptableObject
{
    public float dashDistance = 5f; // Distancia del dash
    public float dashDuration = 0.2f; // Duración del dash
    public float cooldown = 1f; // Cooldown entre dashes
}
