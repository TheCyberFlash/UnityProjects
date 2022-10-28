using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public int upgradeLevel = 1;
    public float upgradePrice;
    [SerializeField] private float damage;
    public float range;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private TextMeshProUGUI statsText;
    [SerializeField] private SpriteRenderer radius;
    private GameObject[] otherRadius;
    
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

        var roll = Random.Range(0, 100);

        if (roll < 30)
        {
            damage += 1f;
        }
        else if (roll >= 30 && roll < 60)
        {
            range += 1f;
        }
        else if (roll >= 60 && roll <= 100)
        {
            reloadSpeed += 1f;
        }

        SelectTower();
    }

    public void SelectTower()
    {
        RadiusDisplay();
        if (statsText != null)
        {
            statsText.text = "Upgrade Level: " + upgradeLevel + "\n\n" + "Damage: " + Mathf.RoundToInt(damage) + "\n" + "Reload Speed: " + Mathf.RoundToInt(reloadSpeed) + "\n" + "Range: " + Mathf.RoundToInt(range) + "\n" + "Price: " + Mathf.RoundToInt(upgradePrice);
        }
    }

    private void RadiusDisplay()
    {
        otherRadius = GameObject.FindGameObjectsWithTag("Radius");

        foreach (var other in otherRadius)
        {
            var rend = other.GetComponent<SpriteRenderer>();
            rend.enabled = false;
        }
        radius.enabled = !radius.enabled;
    }


}
