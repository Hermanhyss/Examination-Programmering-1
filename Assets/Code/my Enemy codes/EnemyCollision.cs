using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damageAmount = 10;
    PlayerMovement playerHealth;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerHealth script from the player object
            playerHealth = collision.gameObject.GetComponent<PlayerMovement>();

            // Inflict damage on the player

            PlayerMovement playerhealth = FindObjectOfType<PlayerMovement>();
            if (playerhealth != null)
            {
                playerhealth.TakeDamage(damageAmount);
                Debug.Log("take dammage");
            }
          
        }

    }
}

