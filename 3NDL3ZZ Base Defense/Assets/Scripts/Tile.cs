using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private MousePointer mousePointer;
    [SerializeField] private bool isTile;
    public bool canPlace;
    public bool blockBarricade;
    public bool rotBarricade;
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
            var buttonId = mousePointer.buttonId;


            if (isTile && canPlace)
            {

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
            else if (!isTile && canPlace)
            {
                switch (buttonId)
                {
                    case 4:
                        if (!blockBarricade)
                        {
                            PlaceTrap(0);
                        }
                        break;
                    case 5:
                        PlaceTrap(1);
                        break;
                }
            }
        } 

        if (!canPlace)
        {
            Tower tower = GetComponentInChildren<Tower>();
            if (tower != null)
            {
                var turret = tower.gameObject;
                levelManager.ShowTowerStats(turret);
                tower.SelectTower();
            }
        }
    }

    private void PlaceTurret(int index)
    {
        canPlace = false;

        var turret = Instantiate(levelManager.turrets[index], transform.position, Quaternion.identity);
        turret.transform.parent = gameObject.transform;

        var tower = turret.GetComponent<Tower>();
        tower.upgradePrice = mousePointer.price;
        tower.SelectTower();

        levelManager.money -= mousePointer.price;
        ResetMouse();
    }

    private void PlaceTrap(int index)
    {
        canPlace = false;

        var trap = Instantiate(levelManager.traps[index], transform.position, Quaternion.identity);
        trap.transform.parent = gameObject.transform;

        if (index == 0 && rotBarricade)
        {
            trap.transform.localEulerAngles = new Vector3(0, 0, 90);
        }

        levelManager.money -= mousePointer.price;

        ResetMouse();
    }

    private void ResetMouse()
    {
        mousePointer.spriteRenderer.sprite = null;
        mousePointer.buttonId = 0;
        mousePointer.price = 0;
    }
}
