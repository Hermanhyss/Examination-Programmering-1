using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    // Set boundaries for the screen
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    void Update()
    {
        // Get input for player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position based on input and speed
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        // Clamp the position to stay within screen boundaries
        float clampedX = Mathf.Clamp(newPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(newPosition.y, minY, maxY);

        // Update the player's position
        transform.position = new Vector3(clampedX, clampedY, 0);
    }
}

