using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private int openingDirection;

    private RoomTemplates templates;
    private int randomIndex;
    private bool spawned = false;

    public float waitTime = 4f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        Invoke("Spawn", 0.3f);
    }

    private void Spawn()
    {
        if (!spawned)
        {
            switch (openingDirection)
            {
                case 1:
                    randomIndex = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[randomIndex], transform.position, templates.bottomRooms[randomIndex].transform.rotation);
                    break;
                case 2:
                    randomIndex = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[randomIndex], transform.position, templates.topRooms[randomIndex].transform.rotation);
                    break;
                case 3:
                    randomIndex = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[randomIndex], transform.position, templates.leftRooms[randomIndex].transform.rotation);
                    break;
                case 4:
                    randomIndex = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[randomIndex], transform.position, templates.rightRooms[randomIndex].transform.rotation);
                    break;
            }

            spawned = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }

}
