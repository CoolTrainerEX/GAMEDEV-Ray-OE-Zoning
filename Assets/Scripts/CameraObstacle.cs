using System.Collections.Generic;
using UnityEngine;

public class CameraObstacle : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private List<Quaternion> rotations;

    private int currentRotation = 0;

    // Update is called once per frame
    void Update()
    {
        if (Quaternion.Angle(transform.rotation, rotations[currentRotation]) > float.Epsilon) transform.rotation = Quaternion.RotateTowards(transform.rotation, rotations[currentRotation], settings.cameraSpeed * Time.deltaTime);
        else currentRotation = (currentRotation + 1) % rotations.Count;

        if (Physics.Raycast(transform.position, transform.up, Mathf.Infinity, LayerMask.GetMask("Player"))) GameManager.Instance.Lose();
    }
}
