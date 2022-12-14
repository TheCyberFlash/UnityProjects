using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] string button;
    [SerializeField] Sprite sprite;
    [SerializeField] MousePointer mousePointer;
    [SerializeField] LevelManager levelManager;
    [SerializeField] float scaleSize;
    [SerializeField] int buttonId;
    [SerializeField] int price;

    string buttonDescription;

    // Start is called before the first frame update
    void Start()
    {
        buttonDescription = SetButtonDescription();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log(levelManager.money);
        Debug.Log(price);
        if (levelManager.money >= price)
        {
            mousePointer.buttonId = buttonId;
            mousePointer.price = price;
            mousePointer.spriteRenderer.sprite = sprite;
            mousePointer.spriteRenderer.enabled = true;
            mousePointer.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
            Debug.Log(button + " has been pressed");
        }

    }

    private void OnMouseEnter()
    {
        levelManager.ShowTowerInit(buttonDescription);
    }

    private string SetButtonDescription()
    {
        var buttonDescription = string.Empty;
        switch (buttonId)
        {
            case 1:
                buttonDescription = "Gun \n\n Faster Reload \n Less damage \n Shoots bullets \n\n Price: " + price;
                break;
            case 2:
                buttonDescription = "Flame \n\n Medium Reload \n Fireballs \n You want more? \n\n Price: " + price;
                break;
            case 3:
                buttonDescription = "Missile \n\n Slower Reload \n Most damage \n BOOM BABY! \n\n Price: " + price;
                break;
            case 4:
                buttonDescription = "Wall \n\n Big Stone Wall \n Enemy Go Boom \n All Falls Down \n\n Price: " + price;
                break;
            case 5:
                buttonDescription = "Oil \n\n Oil Slick \n Slows Enemies \n Slip N Slide \n\n Price: " + price;
                break;
        }

        return buttonDescription;
    }
}
