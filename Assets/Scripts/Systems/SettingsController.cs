using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Image _soundToggleIcon;
    [SerializeField] private Image _musicToggleIcon;
    [SerializeField] private TMP_Dropdown _langDropdown;
    //[SerializeField] private TMP_Dropdown _resDropdown;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;
    [Space]
    [Tooltip("First sprite unmuted")]
    [SerializeField] private Sprite[] _soundIcons;
    [SerializeField] private Sprite[] _musicIcons;


    private Resolution[] _resolutions;
    private int _currentResolutionIndex;

    private void Awake()
    {
        //CheckPlatform();
        LoadSettings();
    }

    /*private void CheckPlatform()
    {
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _resDropdown.gameObject.SetActive(false);
            return;
        }
        GetResolutions();
    }

    public void GetResolutions()
    {
        _resDropdown.gameObject.SetActive(true);
        _resDropdown.ClearOptions();
        _resolutions = Screen.resolutions;

        List<string> screens = new List<string>();

        for (int i = 0; i < _resolutions.Length; i++)
        {
            var res = _resolutions[i].width + "x" + _resolutions[i].height;
            screens.Add(res);

            if (_resolutions[i].width == Screen.currentResolution.width &&
                _resolutions[i].height == Screen.currentResolution.height)
                _currentResolutionIndex = i;
        }
        _resDropdown.AddOptions(screens);
        _resDropdown.value = _currentResolutionIndex;
        _resDropdown.RefreshShownValue();
    }*/

    public void SetResolution(int index)
    {
        var desiredResolution = _resolutions[index];
        Screen.SetResolution(desiredResolution.width, desiredResolution.height, true);
        PlayerPrefs.SetInt("Resolution", index);
    }

    public void LoadSettings()
    {
        LoadAudio(_soundSlider,_musicSlider);
        //LoadResolution();
        //LoadLanguage();
    }

    public void LoadAudio(Slider soundSlider, Slider musicSlider)
    {
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Sound, PlayerPrefs.GetFloat("Sound", 0.5f));
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Music, PlayerPrefs.GetFloat("Music", 0.5f));

        if (PlayerPrefs.HasKey("Sound"))
            soundSlider.value = PlayerPrefs.GetFloat("Sound", 0.5f);

        if (PlayerPrefs.HasKey("Music"))
            musicSlider.value = PlayerPrefs.GetFloat("Music", 0.5f);
    }

    private void LoadLanguage()
    {
        _langDropdown.value = PlayerPrefs.GetInt("Language", 0);
        //ChangeLanguage();
    }

    /*private void LoadResolution()
    {
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
            return;

            if (!PlayerPrefs.HasKey("Resolution"))
            return;

        int resIndex = PlayerPrefs.GetInt("Resolution");
        var desiredResolution = _resolutions[resIndex];
        Screen.SetResolution(desiredResolution.width, desiredResolution.height, true);
        _resDropdown.value = resIndex;
    }*/

    public void ToggleSound()
    {
        SoundDesigner.SoundMuted = !SoundDesigner.SoundMuted;
        SoundDesigner.SetMuteByBaseType(SoundBaseType.Sound, SoundDesigner.SoundMuted);
        _soundToggleIcon.sprite = SoundDesigner.SoundMuted ? _soundIcons[0] : _soundIcons[1];
    }

    public void ToggleMusic()
    {
        SoundDesigner.MusicMuted = !SoundDesigner.MusicMuted;
        SoundDesigner.SetMuteByBaseType(SoundBaseType.Music, SoundDesigner.MusicMuted);
        _musicToggleIcon.sprite = SoundDesigner.MusicMuted ? _musicIcons[0] : _musicIcons[1];
    }

    public void ChangeSoundVolume()
    {
        float value = _soundSlider.GetComponent<Slider>().value;
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Sound, value);
        PlayerPrefs.SetFloat("Sound", value);
    }

    public void ChangeMusicVolume()
    {
        float value = _musicSlider.GetComponent<Slider>().value;
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Music, value);
        PlayerPrefs.SetFloat("Music", value);
    }


    /*public void ChangeLanguage()
    {
        Language language = (Language)Enum.Parse(typeof(Language), _langDropdown.value.ToString(), true);
        LocalizationSystem.SetLanguage(language);
        PlayerPrefs.SetInt("Language", Convert.ToInt32(LocalizationSystem.GetCurrentLang()));
    }*/

    public void OnBackButton()
    {
        this.gameObject.SetActive(false);
    }
}
