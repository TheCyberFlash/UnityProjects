using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private int upgradeLevel = 1;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private int price;
    [SerializeField] private TextMeshProUGUI statsText;
    // Start is called before the first frame update
    void Start()
    {
        statsText = GameObject.FindGameObjectWithTag("StatsText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTower()
    {
        Debug.Log("Tower Clicked");
        if (statsText != null)
        {
            statsText.text = "Upgrade Level: " + upgradeLevel + "\n\n" + "Damage: " + damage + "\n" + "Reload Speed: " + reloadSpeed + "\n" + "Price: " + price;
        }
    }



}
