using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Script : MonoBehaviour
{
    private int brutality;
    private int activeBoost;
    private int level;



}

public abstract class ImprovingState
{
    private int _upgradeCost;
    private int _upgradeImprovement;
    private int _levelRequired;
    private int _improvementLevel;

    public ImprovingState(int upgradeCost, int upgradeImprovement, int levelRequired, int improvementLevel)
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
}

