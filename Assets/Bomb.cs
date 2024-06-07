using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component if not assigned
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Set initial position above the screen
        Vector3 initialPosition = transform.position;
        initialPosition.y = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y + 1.0f; // Adjust 1.0f as needed
        transform.position = initialPosition;
    }
}
