using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameEconomy : MonoBehaviour
{

    public int Money
    {
        get
        {
            return PlayerPrefs.GetInt("Money");
        }
        set
        {
            PlayerPrefs.SetInt("Money", value);
        }
    }
    [SerializeField] TextMeshProUGUI _dollarCountText;
    [SerializeField] UpgradeButton[] _upgrades;

    public static GameEconomy Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        DollarUpdate();
    }
    public void DollarUpdate()
    {
        _dollarCountText.text = Money.ToString();
    }
    public void ControlUpgradeActivenes()
    {
        foreach (UpgradeButton upgrade in _upgrades)
        {
            if (Money < upgrade.CostPref)
            {
                upgrade.button.interactable = false;
            }
        }
    }
}
