using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class MouseController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public Boundary boundary;
    public GameObject Player;

    private Vector3 mousePosition;
    public float moveSpeed = 1f;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = transform.position.y;
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
            mousePosition.x = transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
    }
}
