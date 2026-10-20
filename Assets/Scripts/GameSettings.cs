using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Audio")]
    public AudioClip winSound;
    public AudioClip loseSound;

    [Header("Camera Obstacle")]
    public float cameraSpeed = 5;

    [Header("Wall Obstacle")]
    public Material activeMaterial;
    public Material inactiveMaterial;
}
