using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moneyPerKill;
    private float speed;
    private Waypoints waypoints;
    private LevelManager levelManager;

    private int waypointNumber;
    public float healthPoints;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        levelManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();

        speed = Random.Range(1, 4);
        moneyPerKill = Random.Range(10, 50);
        var wave = levelManager.waves;
        healthPoints = Random.Range((3 * wave), (10 * wave));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints.waypoints[waypointNumber].position, speed * Time.deltaTime);

        Vector3 direction = waypoints.waypoints[waypointNumber].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Vector2.Distance(transform.position, waypoints.waypoints[waypointNumber].position) < 0.1f)
        {            
            if(waypointNumber < waypoints.waypoints.Length - 1)
            {
                waypointNumber++;
            } else
            {
                Destroy(gameObject);
                levelManager.enemyCount--;
            }
        }
    }
}
