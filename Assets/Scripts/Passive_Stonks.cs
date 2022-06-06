using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Passive_Stonks : MonoBehaviour
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

    // Audio
    [SerializeField] private AudioSource AudioSounds;
    [SerializeField] private List<AudioClip> AudioSoundsList;

    [SerializeField] private GameObject _sportEquipment;

    public int UpgradeCost { get => _upgradeCost; }
    public int UpgradeImprovement { get => _upgradeImprovement; }
    public int LevelRequired { get => _levelRequired; }
    public int ImprovementLevel { get => _improvementLevel; }

    public void BuyUpgrade()
    {
        if (sportsman.brutality >= _upgradeCost)
        {
            AudioSounds.PlayOneShot(AudioSoundsList[Random.Range(0, AudioSoundsList.Count - 1)]);

            sportsman._sportsmenBoost += UpgradeImprovement;
            sportsman.brutality -= _upgradeCost;
            _upgradeCost *= costCoef;

            sportsman.RefreshBrutalityInfo();

            cost.text = _upgradeCost.ToString();

            _improvementLevel++;
            lvlImprovement.text = _improvementLevel.ToString();
            _sportEquipment.SetActive(true);
        }
        else
        {
            LeanTween.moveLocalX(gameObject, 30f, 0.05f);
            LeanTween.moveLocalX(gameObject, -30f, 0.1f).setDelay(0.05f);
            LeanTween.moveLocalX(gameObject, 0f, 0.05f).setDelay(0.15f);
        }
    }

    private void Start()
    {
        _gameManager._levelUpdater.AddListener(CheckLevel);
        //загрузка данных

        lockImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _levelRequired.ToString();
        cost.text = _upgradeCost.ToString();
        if (_levelRequired > _gameManager._level)
        {
            HideMask();
        }
        _gameManager.LevelUpdate(_gameManager._level);
    }

    public void ShowMask() => transform.GetComponent<Button>().interactable = true;

    public void HideMask() => transform.GetComponent<Button>().interactable = false;

    private void CheckLevel(int level)
    {
        if (level >= _levelRequired)
        {
            lockImage.SetActive(false);
            ShowMask();
        }
    }

}
