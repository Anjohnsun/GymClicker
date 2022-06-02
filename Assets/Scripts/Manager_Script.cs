using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Script : MonoBehaviour
{
    public int brutality;
    public int clickEffectiveness;
    public int level;
    public int sliderValue;

    [SerializeField] private List<UpgradeWindow> _heroUpgrades = new List<UpgradeWindow>();

    public float soundVolume;
    public float musicVolume;

    private void Start()
    {
        //загрузить данные из файла
    }
}

