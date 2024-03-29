using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Manager_Script : MonoBehaviour
{
    public int brutality;
    public int clickEffectiveness;
    public int _level;
    public int sliderValue;

    [SerializeField] private List<UpgradeWindow> _heroUpgrades = new List<UpgradeWindow>();

    public float soundVolume;
    public float musicVolume;

    public UnityEvent<int> _levelUpdater = new UnityEvent<int>();

    public bool _sportsman1IsActive = false;
    public bool _sportsman2IsActive = false;

    private void Start()
    {
        //��������� ������ �� �����
    }

    public void LevelUpdate(int level)
    {
        _levelUpdater.Invoke(level);
    }
}

