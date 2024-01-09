using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // How much health 
    public int maxHealth = 3;
    public int currenHealth; 
    public HealthBar healthBar;
    public GameManager gameManager;

    private bool isDead;
    //movement 
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float tiltAmount = 20f; // Adjust the tilt amount as needed
    private Rigidbody2D rb;

    // Set boundaries for the screen
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;




    void Start()
    {
        
            rb = GetComponent<Rigidbody2D>();
        
        
        
            currenHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    
    }
    public void TakeDamage(int damage)
    {
        currenHealth -= damage;

        healthBar.SetHealth(currenHealth);



    }
    

    void Update()
    {
        {   // Get input values for horizontal and vertical axes
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

        // Clamp the player's position within screen boundaries
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // Update the player's position
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        if (currenHealth <= 0 && !isDead)
            {
                isDead = true;
                gameManager.gameOver();
                    Debug.Log("dead");
            }
           

        }

    }

}

