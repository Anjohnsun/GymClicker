using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Main_Character : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject stats;
    public Image sliderLV;

    public int brutality = 0;
    public float toNextLv = 50;
    public float realProgress = 0;
    public int level = 0;
    public int boost = 1;
    public float coeffToNextLv = 2f;

    public int firstCost = 5;
    public int secondCost = 15;

    [SerializeField] private Sprite sittingSprite;
    [SerializeField] private Sprite stayingSprite;

    [SerializeField] Manager_Script _GameManager;

    void Start()
    {
        // Тут подгрузка из json

        sliderLV.fillAmount = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        brutality += boost;
        _GameManager.brutality = brutality;
        realProgress++;
        RefreshBrutalityInfo();
        transform.GetChild(0).GetComponent<Image>().sprite = sittingSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = stayingSprite;
    }

    public void LVLUp()
    {
        level++;
        toNextLv *= coeffToNextLv;
        realProgress = 0;
        _GameManager.LevelUpdate(level);
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

    public void RefreshBrutalityInfo()
    {

        brutality = _GameManager.brutality;
        stats.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = brutality.ToString();

        sliderLV.fillAmount = (realProgress / 100) * (100 / toNextLv);
        if (realProgress >= toNextLv)
        {
            LVLUp();
            stats.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = level.ToString();
            stats.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = (level+ 1).ToString();
        }
    }
}
