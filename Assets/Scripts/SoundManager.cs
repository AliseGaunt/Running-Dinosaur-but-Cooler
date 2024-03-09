using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    Slider bgmSlider, sfxSlider;
    [SerializeField]
    AudioSource bgm, buttonClick, startButtonClick;

    // Start is called before the first frame update

    void Start()
    {
        bgmSlider.value = PlayerPrefs.GetInt("BGM");
        sfxSlider.value = PlayerPrefs.GetInt("SFX");
    }

    // Update is called once per frame
    void Update()
    {
        bgm.volume = bgmSlider.value / 10f;
        buttonClick.volume = sfxSlider.value / 10f;
        startButtonClick.volume = sfxSlider.value / 10f;
    }

    public void SetBGM()
    {
        PlayerPrefs.SetInt("BGM", (int)bgmSlider.value);
    }
    
    public void SetSFX()
    {
        PlayerPrefs.SetInt("SFX", (int)sfxSlider.value);
    }    

    public void PlaySliderSFX()
    {
        buttonClick.Play();
    }    
}
