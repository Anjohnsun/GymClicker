using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWindow : MonoBehaviour
{
    [SerializeField] private int _upgradeCost;
    [SerializeField] private int _upgradeImprovement;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private int _levelRequired;
    [SerializeField] private TextMeshProUGUI lvlImprovement;
    [SerializeField] private int _improvementLevel;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private int costCoef = 2;

    [SerializeField] private Main_Character sportsman;
    [SerializeField] private Manager_Script _gameManager;

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
        if (_gameManager.brutality >= _upgradeCost)
        {
            sportsman.boost += UpgradeImprovement;
            _gameManager.brutality -= _upgradeCost;
            _upgradeCost *= costCoef;

            sportsman.RefreshBrutalityInfo();

            cost.text = _upgradeCost.ToString();
            Debug.Log("�������!");

            _improvementLevel++;
            lvlImprovement.text = _improvementLevel.ToString();
        }

    }


    
    private void Start()
    {
        _gameManager._levelUpdater.AddListener(CheckLevel);
        //�������� ������

        cost.text = _upgradeCost.ToString();
        if (_levelRequired > _gameManager._level)
        {
            HideMask();
        } else
        {
            _gameManager.LevelUpdate(_gameManager._level);
        }

        _gameManager.LevelUpdate(_gameManager._level);
    }

    public void ShowMask() => transform.GetComponent<Button>().interactable = true;

    public void HideMask() => transform.GetComponent<Button>().interactable = false;

    private void CheckLevel(int level)
    {
        if(level >= _levelRequired)
        {
            lockImage.SetActive(false);
            ShowMask();
            Debug.LogWarning(level + "   " + _levelRequired + "   " + _upgradeCost);
        }
    }

}
