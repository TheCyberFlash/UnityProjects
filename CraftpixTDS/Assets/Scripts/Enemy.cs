using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float healthPoints;
    private Transform target;
    public float speed;
    private Vector2 movement;
    [SerializeField] private float angleOffset;


    private void Awake()
    {
        healthPoints = Random.Range(3, 10);
        target = GameObject.Find("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            healthPoints -= Random.Range(3f, 5.5f);
        }
    }

    private void Update()
    {
        if (healthPoints < 0)
        {
            Destroy(gameObject);
        }

        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + angleOffset);
        direction.Normalize();
        movement = direction;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //transform.Translate(target.position * speed * Time.deltaTime);
    }
}
