using UnityEngine;

/**
 * Put on the camera and set the die object.
 * The camera will follow the die as it falls, giving the illusion that it's not falling.
 * The camera will also spin, making the die look more active than it is.
 * Camera stops after a certain threshold to prevent bounce.
 */

public class CameraFollowDie : MonoBehaviour
{
    public Transform die; // Reference to the die's transform
    public float rotationSpeed = 30f; // Speed of the Z-axis rotation
    private Vector3 offset; // Initial offset from the die
    private float previousYPosition; // To track the previous Y position of the die

    void Start()
    {
        if (die == null)
        {
            Debug.LogError("Die Transform is not assigned.");
            return;
        }

        // Calculate and store the offset
        offset = transform.position - die.position;
        // Initialize the previous Y position
        previousYPosition = die.position.y;
    }

    void LateUpdate()
    {
        if (die == null)
        {
            return;
        }

        // Maintain the initial offset position relative to the die
        transform.position = die.position + offset;

        // Check if the Y position of the die has changed
        if (Mathf.Abs(die.position.y - previousYPosition) > 0.01f) // Using a small threshold to detect change
        {
            // Rotate the camera around the Z axis if its Y position is 4 or above
            if (transform.position.y >= 4)
            {
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            }
        }

        // Update the previous Y position
        previousYPosition = die.position.y;
    }
}

