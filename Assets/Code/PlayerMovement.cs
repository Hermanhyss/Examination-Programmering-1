using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float tiltAmount = 20f; // Adjust the tilt amount as needed
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input values for horizontal and vertical axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Move the object based on the input
        rb.velocity = movement * moveSpeed;

        // Calculate the tilt angle based on vertical movement
        float tiltAngle = -moveVertical * tiltAmount;

        // Apply the tilt to the player's rotation
        transform.rotation = Quaternion.Euler(0f, 0f, tiltAngle);
    }
}
