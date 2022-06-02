using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Script : MonoBehaviour
{
    private int brutality;
    private int clickEffectiveness;
    private int level;
    private int sliderValue;

    [SerializeField] private List<UpgradeWindow> _heroUpgrades = new List<UpgradeWindow>();

    private float soundVolume;
    private float musicVolume;

    private void Start()
    {
        //загрузить данные из файла
    }
}

