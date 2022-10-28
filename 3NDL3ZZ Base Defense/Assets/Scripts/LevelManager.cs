using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveCountText;
    [SerializeField] TextMeshProUGUI liveCountText;
    [SerializeField] TextMeshProUGUI moneyCountText;
    [SerializeField] GameObject towerStats;
    [SerializeField] GameObject towerInitial;
    [SerializeField] GameObject sellButton;
    [SerializeField] GameObject upgradeButton;

    public bool showTowerUIButtons = false;
    public GameObject selectedTowerObject;
    public Tower selectedTower;

    public GameObject[] turrets;
    public GameObject[] traps;

    public float money;
    public int waves;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        waves = 1;
    }

    // Update is called once per frame
    void Update()
    {
        waveCountText.text = "WAVE: " + waves;
        liveCountText.text = lives.ToString();
        moneyCountText.text = Mathf.RoundToInt(money).ToString();
        sellButton.SetActive(showTowerUIButtons);
        upgradeButton.SetActive(showTowerUIButtons);
    }

    public void ShowTowerStats(GameObject tower)
    {
        selectedTowerObject = tower;
        selectedTower = selectedTowerObject.GetComponent<Tower>();
        towerInitial.SetActive(false);
        towerStats.SetActive(true);
        showTowerUIButtons = true;
    }

    public void ShowTowerInit(string buttonDescription)
    {
        towerInitial.SetActive(true);
        TextMeshProUGUI towerInitialText = towerInitial.GetComponent<TextMeshProUGUI>();
        towerInitialText.text = buttonDescription;
        towerStats.SetActive(false);
        showTowerUIButtons = false;
    }

    public void UpgradeTower()
    {
        if (money >= selectedTower.upgradePrice)
        {
            money -= selectedTower.upgradePrice;
            selectedTower.UpgradeTower();
        }

    }

    public void SellTower()
    {
        var sellValue = selectedTower.upgradePrice / 2;

        money += sellValue;

        var tile = selectedTower.GetComponentInParent<Tile>();
        tile.canPlace = true;
        Destroy(selectedTowerObject);
    }
}
