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

    public GameObject[] turrets;
    public int money;
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
        moneyCountText.text = money.ToString();
    }

    public void ShowTowerStats()
    {
        towerInitial.SetActive(false);
        towerStats.SetActive(true);
    }

    public void ShowTowerInit(string buttonDescription)
    {
        towerInitial.SetActive(true);
        TextMeshProUGUI towerInitialText = towerInitial.GetComponent<TextMeshProUGUI>();
        towerInitialText.text = buttonDescription;
        towerStats.SetActive(false);
    }
}
