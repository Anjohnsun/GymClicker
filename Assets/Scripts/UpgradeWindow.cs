using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWindow : MonoBehaviour
{
    [SerializeField] private int _upgradeCost;
    [SerializeField] private int _upgradeImprovement;
    [SerializeField] private int _levelRequired;
    [SerializeField] private int _improvementLevel;
    [SerializeField] private TextMeshProUGUI name;
    public UpgradeWindow(int upgradeCost, int upgradeImprovement, int levelRequired, int improvementLevel)
    {
        _upgradeCost = upgradeCost;
        _upgradeImprovement = upgradeImprovement;
        _levelRequired = levelRequired;
        _improvementLevel = improvementLevel;
    }

    public int UpgradeCost { get => _upgradeCost; }
    public int UpgradeImprovement { get => _upgradeImprovement; }
    public int LevelRequired { get => _levelRequired; }
    public int ImprovementLevel { get => _improvementLevel; }

    public void BuyUpgrade()
    {

    }

    public void ShowMask() => gameObject.GetComponent<Button>().interactable = true;

    public void HideMask() => gameObject.GetComponent<Button>().interactable = false;
}
