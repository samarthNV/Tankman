using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{
    private float objectWidth;
    private float objectHeight;
    private float screenBottomY;
    private float screenLeftX;
    private float screenRightX;

    public float movementSpeed = 5f;

    void Start()
    {
        // Calculate the object's size (width and height)
        objectWidth = GetComponent<Collider2D>().bounds.extents.x;
        objectHeight = GetComponent<Collider2D>().bounds.extents.y;

        // Find the boundaries of the screen in world coordinates
        screenBottomY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        screenLeftX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        screenRightX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    void Update()
    {
        // Move left when left arrow key is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveHorizontal(-1f);
        }
        // Move right when right arrow key is pressed
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveHorizontal(1f);
        }

        // Ensure the object stays at the bottom of the screen and within the screen bounds
        Vector3 newPos = transform.position;
        newPos.y = Mathf.Clamp(newPos.y, screenBottomY + objectHeight, Mathf.Infinity);
        newPos.x = Mathf.Clamp(newPos.x, screenLeftX + objectWidth, screenRightX - objectWidth);
        transform.position = newPos;
    }

    void MoveHorizontal(float direction)
    {
        // Calculate the new position based on the direction and movement speed
        Vector3 newPos = transform.position + Vector3.right * direction * movementSpeed * Time.deltaTime;

        // Clamp the new position to stay within the screen bounds
        newPos.x = Mathf.Clamp(newPos.x, screenLeftX + objectWidth, screenRightX - objectWidth);

        // Update the position
        transform.position = newPos;
    }
}
