using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float healthPoints;
    private Transform target;
    public float smoothTime = 5f;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        healthPoints = Random.Range(3, 10);
        smoothTime = Random.Range(2f, 8f);
        target = GameObject.Find("Player").transform;
        Debug.Log(healthPoints + " remaining");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name.Contains("Bullet"))
        {
            healthPoints -= Random.Range(3f, 5.5f);
            Debug.Log(healthPoints + " remaining");
        }
    }

    private void Update()
    {
        if (healthPoints < 0)
        {
            Destroy(gameObject);
        }

        Vector3 goalPos = target.position;
        goalPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}
