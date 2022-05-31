using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Script : MonoBehaviour
{
    private int brutality;
    private int activeBoost;

    [SerializeField] TMP_Text stat;

    public void Click()
    {
        brutality = brutality + 1 + activeBoost;
    }

    public void ActiveFirstUpgrade()
    {
        activeBoost++;
        brutality = brutality - 5;
    }

    public void ActiveSecondUpgrade()
    {
        activeBoost = activeBoost + 3;
        brutality = brutality - 15;
    }

    void Start()
    {
        brutality = 0;
        activeBoost = 0;
    }

    void Update()
    {
        stat.text = "Brutality - " + brutality;
    }
}
