using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [HideInInspector] public Button button;

    public int CostPref
    {
        get
        {
            return PlayerPrefs.GetInt("Cost" + gameObject.name) + 50;
        }
        private set
        {
            PlayerPrefs.SetInt("Cost" + gameObject.name, value);
        }
    }
    void Awake()
    {
        button = GetComponent<Button>();
    }
    public void Upgrade()
    {
        GameEconomy.Instance.Money -= CostPref;
        CostPref += 50;
        GameEconomy.Instance.ControlUpgradeActivenes();
        GameEconomy.Instance.DollarUpdate();
    }
}
