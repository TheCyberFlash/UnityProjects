using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private MousePointer mousePointer;
    [SerializeField] private bool isTile;
    private bool canPlace;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        canPlace = true;
        levelManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (mousePointer.buttonId != 0)
        {
            if (isTile && canPlace)
            {
                var buttonId = mousePointer.buttonId;

                switch (buttonId)
                {
                    case 1:
                        PlaceTurret(0);
                        break;
                    case 2:
                        PlaceTurret(1);
                        break;
                    case 3:
                        PlaceTurret(2);
                        break;
                }
            }
        }

        if (!canPlace)
        {
            Tower tower = GetComponentInChildren<Tower>();
            if (tower != null)
            {
                levelManager.ShowTowerStats();
                tower.SelectTower();
            }
        }
    }

    private void PlaceTurret(int index)
    {
        var turret = Instantiate(levelManager.turrets[index], transform.position, Quaternion.identity);
        turret.transform.parent = gameObject.transform;
        canPlace = false;
        ResetMouse();
    }

    private void ResetMouse()
    {
        mousePointer.spriteRenderer.sprite = null;
        mousePointer.buttonId = 0;
    }
}
