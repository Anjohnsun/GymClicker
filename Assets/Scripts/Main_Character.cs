using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
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

    [SerializeField] GameObject Background;
    [SerializeField] Sprite BGcartoon;
    [SerializeField] Sprite BGrtx;

    // Audio
    [SerializeField] private AudioSource AudioMusic;
    [SerializeField] private List<AudioClip> AudioMusicList;
    [SerializeField] private AudioSource AudioMoans;
    [SerializeField] private List<AudioClip> AudioMoansList;
    [SerializeField] private AudioMixer Mixer;

    void Start()
    {
        // ��� ��������� �� json

        sliderLV.fillAmount = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioMoans.PlayOneShot(AudioMoansList[Random.Range(0, AudioMoansList.Count - 1)]);
        brutality += boost;
        _GameManager.brutality = brutality;
        realProgress++;
        RefreshBrutalityInfo();
        transform.GetChild(0).GetComponent<Image>().sprite = sittingSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<Image>().sprite = stayingSprite;
        if (AudioMusic.isPlaying) return;
        AudioMusic.PlayOneShot(AudioMusicList[Random.Range(0, AudioMusicList.Count - 1)]);
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

    public void ToggleRTX(bool isToggle)
    {
        if (isToggle) Background.GetComponent<Image>().sprite = BGrtx;
        else Background.GetComponent<Image>().sprite = BGcartoon;
    }
    public void OnVolumeMaster(float vol)
    {
        Mixer.SetFloat("MasterVolume", Mathf.Log10(vol) * 20);
    }
    public void OnVolumeMusic(float vol)
    {
        Mixer.SetFloat("MusicVolume", Mathf.Log10(vol) * 20);
    }
    public void OnVolumeSounds(float vol)
    {
        Mixer.SetFloat("SoundsVolume", Mathf.Log10(vol) * 20);
    }
    public void OnVolumeMoans(float vol)
    {
        Mixer.SetFloat("MoansVolume", Mathf.Log10(vol) * 20);
    }
}
