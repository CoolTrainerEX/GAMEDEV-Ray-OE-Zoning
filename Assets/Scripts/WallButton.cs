using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WallButton : MonoBehaviour
{
    [SerializeField] WallObstacle wallObstacle;
    [SerializeField] PlayerInput playerInput;

    private AudioSource audio;
    private bool toggled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, 2.5f, LayerMask.GetMask("Player")) && playerInput.IsAttacking)
        {
            if (!toggled)
            {
                wallObstacle.IsActive = !wallObstacle.IsActive;
                audio.Play();
                toggled = true;
            }
        }
        else toggled = false;
    }
}
