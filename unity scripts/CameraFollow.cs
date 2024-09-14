using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;         // Reference to the player's transform
    public Vector3 offset;           // Offset between the camera and the player
    public float smoothSpeed = 0.125f; // Smoothing speed for camera movement
    public float minX, maxX, minY, maxY; // Boundaries for camera movement

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position based on player position and offset
            Vector3 desiredPosition = player.position + offset;
            
            // Clamp the desired position to ensure the camera stays within the specified boundaries
            float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);
            
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
            
            // Update the camera position
            transform.position = smoothedPosition;
        }
    }
}
