using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Main_Character : MonoBehaviour
{
    public TMP_Text BrutalityText;
    public Slider sliderLV;

    public int brutality = 0;
    public float toNextLv = 50;
    public float realProgress = 0;
    public int level = 0;
    public int boost = 0;
    public float coeffToNextLv = 1.2f;

    public int firstCost = 5;
    public int secondCost = 15;
    


    void Start()
    {
        // Тут подгрузка из json

        sliderLV.value = 0;
        // Также исправил косяк с BrutalityText. В него зачем-то передавали компонент
    }

    void Update()
    {
        BrutalityText.text = brutality.ToString();

        sliderLV.value = (realProgress / 100) * (100 / toNextLv);
        if (realProgress >= toNextLv) { LVUp(); }
        
    }

    public void Click()
    {
        brutality += 1 + boost;
        realProgress++;
    }

    public void LVUp()
    {
        level++;
        toNextLv = toNextLv * coeffToNextLv;
        realProgress = 0;
    }

    public void BuyFirst()
    {
        if (brutality >= firstCost)
        {
            boost++;
            brutality -= firstCost;
        }
    }
    public void BuySecond()
    {
        if (brutality >= secondCost)
        {
            boost += 3;
            brutality -= secondCost;
        }
    }


    
}
