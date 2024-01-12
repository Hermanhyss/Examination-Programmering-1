using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerData playerData;
    public float speed;
    private Rigidbody2D rb;
    public int damage = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
      EnemyController enemyComp = collision.gameObject.GetComponent<EnemyController>();
        if (enemyComp != null)
        {
            enemyComp.TakeDamage(1);
            playerData.CurrentScore += 1;
            GameObject.Destroy(gameObject);
     
        }
    }



}

