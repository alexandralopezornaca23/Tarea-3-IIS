using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // The player or object to follow.

    [Header("Camera Settings")]
    public float smoothSpeed = 0.125f; // Speed of camera smoothing.
    public float xOffset = 2.5f; // Fixed horizontal offset from the target.

    [Header("Bounds Settings")]
    public bool useBounds = false; // Enable or disable bounds.
    public Vector2 minBounds; // Minimum bounds (x, y).
    public Vector2 maxBounds; // Maximum bounds (x, y).

    private Camera cam;
    private float camHalfHeight;
    private float camHalfWidth;

    private void Start()
    {
        cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not assigned to CameraFollow script.");
            return;
        }

        // Desired camera position with fixed horizontal offset and no vertical movement.
        Vector3 desiredPosition = new Vector3(target.position.x + xOffset, transform.position.y, transform.position.z);

        // Smooth camera transition.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Apply bounds if enabled.
        if (useBounds)
        {
            float clampedX = Mathf.Clamp(smoothedPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
            smoothedPosition.x = clampedX;
        }

        // Update camera position.
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }

    private void OnDrawGizmosSelected()
    {
        if (useBounds)
        {
            // Draw bounds for visualization in the editor.
            Gizmos.color = Color.green;
            Gizmos.DrawLine(new Vector3(minBounds.x, minBounds.y, 0), new Vector3(maxBounds.x, minBounds.y, 0));
            Gizmos.DrawLine(new Vector3(minBounds.x, maxBounds.y, 0), new Vector3(maxBounds.x, maxBounds.y, 0));
            Gizmos.DrawLine(new Vector3(minBounds.x, minBounds.y, 0), new Vector3(minBounds.x, maxBounds.y, 0));
            Gizmos.DrawLine(new Vector3(maxBounds.x, minBounds.y, 0), new Vector3(maxBounds.x, maxBounds.y, 0));
        }
    }
}
