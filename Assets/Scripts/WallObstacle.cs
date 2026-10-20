using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WallObstacle : MonoBehaviour
{
    [SerializeField] private GameSettings settings;

    public bool IsActive { get; set; } = true;

    private Renderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive && Physics.CheckBox(transform.position + transform.up * 2.5f, new Vector3(5, 2.5f, 0.5f), transform.rotation, LayerMask.GetMask("Player"))) GameManager.Instance.Lose();

        renderer.sharedMaterial = IsActive ? settings.activeMaterial : settings.inactiveMaterial;
    }
}
