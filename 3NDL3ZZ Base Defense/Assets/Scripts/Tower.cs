using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public int upgradeLevel = 1;
    public float upgradePrice;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private TextMeshProUGUI statsText;
    // Start is called before the first frame update
    void Start()
    {
        statsText = GameObject.FindGameObjectWithTag("StatsText").GetComponent<TextMeshProUGUI>();
        SelectTower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeTower()
    {
        upgradeLevel++;
        upgradePrice *= 1.2f;
        damage *= 1.1f;
        range *= 1.1f;
        reloadSpeed *= 1.1f;

        SelectTower();
    }

    public void SelectTower()
    {
        Debug.Log("Tower Clicked");
        if (statsText != null)
        {
            statsText.text = "Upgrade Level: " + upgradeLevel + "\n\n" + "Damage: " + Mathf.RoundToInt(damage) + "\n" + "Reload Speed: " + Mathf.RoundToInt(reloadSpeed) + "\n" + "Price: " + Mathf.RoundToInt(upgradePrice);
        }
    }



}
