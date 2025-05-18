using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The object the camera should follow
    public float smoothSpeed = 0.125f;  // The speed at which the camera follows the target
    public Vector3 offset;  // The offset position relative to the target

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target is not set!");
            return;
        }

        // Calculate the desired position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}