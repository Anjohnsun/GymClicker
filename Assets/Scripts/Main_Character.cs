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

    private bool musicHasntPlayed = true;

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

    //other sportsmen
    [SerializeField] private GameObject sportsman1;
    [SerializeField] private GameObject sportsman2;
    [SerializeField] private Image sportsman1Slider;
    [SerializeField] private Image sportsman2Slider;
    [SerializeField] private GameObject sp1Mask;
    [SerializeField] private GameObject sp2Mask;
    public int _sportsmenBoost = 1;

    [SerializeField] private Sprite _handsDown;
    [SerializeField] private Sprite _handsUp;

    void Start()
    {
        // ??? ????????? ?? json

        sliderLV.fillAmount = 0;
    }

    private void FixedUpdate()
    {
        if (_GameManager._sportsman1IsActive)
        {
            sportsman1Slider.fillAmount += Time.fixedDeltaTime / 5;
            if (sportsman1Slider.fillAmount == 1)
            {
                sportsman1Slider.fillAmount = 0;
                brutality += _sportsmenBoost;
                RefreshBrutalityInfo();
            }
        }
        if (_GameManager._sportsman2IsActive)
        {
            sportsman2Slider.fillAmount += Time.fixedDeltaTime / 5;
            if (sportsman2Slider.fillAmount == 1)
            {
                sportsman2Slider.fillAmount = 0;
                brutality += _sportsmenBoost;
                RefreshBrutalityInfo();
            }
        }
        if (AudioMusic.isPlaying || musicHasntPlayed) return;
        AudioMusic.PlayOneShot(AudioMusicList[Random.Range(0, AudioMusicList.Count)]);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioMoans.PlayOneShot(AudioMoansList[Random.Range(0, AudioMoansList.Count)]);
        brutality += boost;
        _GameManager.brutality = brutality;
        realProgress++;
        RefreshBrutalityInfo();
        transform.GetChild(0).GetComponent<Image>().sprite = sittingSprite;
        musicHasntPlayed = false;
        if (_GameManager._sportsman1IsActive)
        {
            if (sportsman1.GetComponent<Image>().sprite == _handsDown)
            {
                sportsman1.GetComponent<Image>().sprite = _handsUp;
            }
            else
            {
                sportsman1.GetComponent<Image>().sprite = _handsDown;
            }
        }
        if (_GameManager._sportsman2IsActive)
        {
            if (sportsman2.GetComponent<Image>().sprite == _handsDown)
            {
                sportsman2.GetComponent<Image>().sprite = _handsUp;
            }
            else
            {
                sportsman2.GetComponent<Image>().sprite = _handsDown;
            }
        }
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
        stats.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = brutality.ToString();

        sliderLV.fillAmount = (realProgress / 100) * (100 / toNextLv);
        if (realProgress >= toNextLv)
        {
            LVLUp();
            stats.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = level.ToString();
            stats.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = (level + 1).ToString();
        }
    }

    public void MakeSportsman1Active()
    {
        if (brutality >= 2000 && !_GameManager._sportsman1IsActive)
        {
            _GameManager._sportsman1IsActive = true;
            sportsman1.SetActive(true);
            brutality -= 2000;
            RefreshBrutalityInfo();
            sp1Mask.SetActive(false);
        }
    }
    public void MakeSportsman2Active()
    {
        if (brutality >= 4000 && !_GameManager._sportsman2IsActive)
        {
            _GameManager._sportsman2IsActive = true;
            sportsman2.SetActive(true);
            brutality -= 4000;
            RefreshBrutalityInfo();
            sp2Mask.SetActive(false);
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