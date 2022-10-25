using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLooping : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    public float speed = 1f;
    public float size = 1f;

    private Vector3 leftSide;
    private Vector3 rightSide;

    private void Start()
    {
        leftSide = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightSide = Camera.main.ViewportToWorldPoint(Vector3.right);
    }

    private void Update()
    {
        if (direction.x > 0 && (transform.position.x - size) > rightSide.x)
        {
            Vector3 position = transform.position;
            position.x = (leftSide.x - size);
            transform.position = position;
        } else if (direction.x < 0 && (transform.position.x + size) < leftSide.x)
        {
            Vector3 position = transform.position;
            position.x = (rightSide.x + size);
            transform.position = position;
        } else
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
