using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;

    void LateUpdate()
    {
        Vector3 newPosition = target.position;
        newPosition.z = -10; // Pulls the camera back on the z-axis so we can actually see the scene

        transform.position = newPosition;
    }
}