using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int health = 1;
    private int damageAmount = 1;
    public GameManager gamemanager;




    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        // if enemy has less than 1 it get destory 
        if (health <= 0)
        {
            GameObject.Destroy(gameObject);

        }

    }






    private void Start()
    {
        gamemanager = GameObject.Find("Gamemanager").GetComponent<GameManager>();
    }



    void Update()
    {
        MoveEnemy();

        // Check if the enemy is beyond the left boundary 
        if (transform.position.x < GetLeftBoundary())
        {
            // Destroy the enemy upon reaching the left boundary and deal one damage on player 
            Destroy(gameObject);

            PlayerMovement playerhealth = FindObjectOfType<PlayerMovement>();
            if (playerhealth != null)
            {
                playerhealth.TakeDamage(damageAmount);
            }
        }
    }

    private void MoveEnemy()
    {
        // Move the enemy from right to left
        var RBPos = GetComponent<Rigidbody2D>().position;
        RBPos += (Vector2.left * moveSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().position = RBPos;
    }


    float GetLeftBoundary()
    {
        // Calculate left boundary based on the screen size
        float leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        return leftBoundary;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            TakeDamage(bullet.damage);
            Destroy(collision.gameObject);
        }


    }
}
