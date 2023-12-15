using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public void TakeDamage()
    {
        GameObject.Destroy(gameObject);
    }


    void Update()
    {
        MoveEnemy();

        // Check if the enemy is beyond the left boundary
        if (transform.position.x < GetLeftBoundary())
        {
            // Destroy the enemy upon reaching the left boundary
            Destroy(gameObject);
        }
    }

    void MoveEnemy()
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
}




