using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private bool isReversed = false;
    private float rotationSpeed = 5f; // Adjust the rotation speed as needed
    public float rotationTimer = 0.8f; // Time taken for the rotation

    void Update()
    {
        // Check for the "E" key press to toggle rotation
        if (Input.GetKeyDown(KeyCode.E))
        {
            isReversed = !isReversed;

            // Start the coroutine for rotation
            StartCoroutine(RotateCoroutine());
        }
    }

    private System.Collections.IEnumerator RotateCoroutine()
    {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        // Calculate the target rotation based on whether it's reversed or not
        Quaternion targetRotation = Quaternion.Euler(isReversed ? 180f : 0f, 0f, 0f);

        while (elapsedTime < rotationTimer)
        {
            // Interpolate between the start and target rotations
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / rotationTimer);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the final rotation is exactly the target rotation
        transform.rotation = targetRotation;
    }
}
