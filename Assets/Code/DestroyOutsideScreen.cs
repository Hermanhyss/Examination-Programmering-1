using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutsideScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        CheckIfOutsideScreen();
    }

    void CheckIfOutsideScreen()
    {
        // Get the screen boundaries in world coordinates
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Check if the GameObject is outside the screen
        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x ||
            transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y)
        {
            // If outside, destroy the GameObject
            Destroy(gameObject);
        }
    }
}

