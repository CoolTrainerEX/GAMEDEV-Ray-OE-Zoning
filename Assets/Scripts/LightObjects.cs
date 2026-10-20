using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightObjects : MonoBehaviour
{
    private Light light;
    private Renderer target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, light.range, LayerMask.GetMask("Lighted")))
        {
            target = hitInfo.transform.GetComponent<Renderer>();
            target.enabled = true;
        }
        else if (target) target.enabled = false;
    }
}
