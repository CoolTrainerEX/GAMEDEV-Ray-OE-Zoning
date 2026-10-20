using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private AudioSource uiAudio;
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawn;

    public static GameManager Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    /// <summary>
    /// Game win trigger.
    /// </summary>
    public void Win()
    {
        uiAudio.PlayOneShot(settings.winSound);
        ResetGame();
    }

    /// <summary>
    /// Game lose trigger.
    /// </summary>
    public void Lose()
    {
        uiAudio.PlayOneShot(settings.loseSound);
        ResetGame();
    }

    /// <summary>
    /// Reset game.
    /// </summary>
    private void ResetGame()
    {
        var controller = player.GetComponent<CharacterController>();

        foreach (var wallObstacle in FindObjectsByType<WallObstacle>()) wallObstacle.IsActive = true;

        controller.enabled = false;
        player.SetPositionAndRotation(spawn.position, spawn.rotation);
        controller.enabled = true;
    }
}
