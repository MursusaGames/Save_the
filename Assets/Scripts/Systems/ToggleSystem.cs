using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToggleSystem : MonoBehaviour
{
    [SerializeField] Image sound;
    [SerializeField] GameObject soundCheckmark;
    [SerializeField] Image music;
    [SerializeField] GameObject musicCheckmark;
    [SerializeField] Image vibration;
    [SerializeField] GameObject vibrationCheckmark;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;
    public bool isVibro;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(Constants.SOUND))
        {
            PlayerPrefs.SetFloat(Constants.SOUND, 1);
            sound.color = Color.green;
            soundCheckmark.Show();
        }
        if (!PlayerPrefs.HasKey(Constants.MUSIC))
        {
            PlayerPrefs.SetFloat(Constants.MUSIC, 1);
            music.color = Color.green;
            musicCheckmark.Show();
        }
        if (!PlayerPrefs.HasKey(Constants.VIBRO))
        {
            PlayerPrefs.SetFloat(Constants.VIBRO, 1);
            vibration.color = Color.green;
            vibrationCheckmark.Show();
        }
        LoadAudio(_soundSlider, _musicSlider);
    }
    public void LoadAudio(Slider soundSlider, Slider musicSlider)
    {
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Sound, PlayerPrefs.GetFloat(Constants.SOUND, 0.5f));
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Music, PlayerPrefs.GetFloat(Constants.MUSIC, 0.5f));

        if (PlayerPrefs.HasKey(Constants.SOUND))
            soundSlider.value = PlayerPrefs.GetFloat(Constants.SOUND, 0.5f);

        if (PlayerPrefs.HasKey(Constants.MUSIC))
            musicSlider.value = PlayerPrefs.GetFloat(Constants.MUSIC, 0.5f);
    }
    private void OnEnable()
    {
        if (PlayerPrefs.GetFloat(Constants.SOUND) > 0)
        {
            sound.color = Color.green;
            soundCheckmark.Show();
            
        }
        else
        {
            sound.color = Color.red;
            soundCheckmark.Hide();
        }

        if (PlayerPrefs.GetFloat(Constants.MUSIC) > 0)
        {
            music.color = Color.green;
            musicCheckmark.Show();
            
        }
        else
        {
            music.color = Color.red;
            musicCheckmark.Hide();
        }

        if (PlayerPrefs.GetFloat(Constants.VIBRO) == 1)
        {
            vibration.color = Color.green;
            vibrationCheckmark.Show();
            isVibro = true;
        }
        else
        {
            vibration.color = Color.red;
            vibrationCheckmark.Hide();
            isVibro = false;
        }
        _soundSlider.value = PlayerPrefs.GetFloat(Constants.SOUND);
        _musicSlider.value = PlayerPrefs.GetFloat(Constants.MUSIC);
    }
    public void ChangeSoundVolume()
    {
        float value = _soundSlider.GetComponent<Slider>().value;
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Sound, value);
        PlayerPrefs.SetFloat(Constants.SOUND, value);
        if (value == 0)
        {
            sound.color = Color.red;
            soundCheckmark.Hide();
        }
        else
        {
            sound.color = Color.green;
            soundCheckmark.Show();
        }
    }

    public void ChangeMusicVolume()
    {
        float value = _musicSlider.GetComponent<Slider>().value;
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Music, value);
        PlayerPrefs.SetFloat(Constants.MUSIC, value);
        if(value == 0)
        {
            music.color = Color.red;
            musicCheckmark.Hide();
        }
        else
        {
            music.color = Color.green;
            musicCheckmark.Show();
        }
    }
    public void ChangeSound()
    {
        if(PlayerPrefs.GetFloat(Constants.SOUND) == 0)
        {
            PlayerPrefs.SetFloat(Constants.SOUND, 1);
            sound.color = Color.green;
            soundCheckmark.Show();
            _soundSlider.value = 1;
            return;
        }
        else
        {
            PlayerPrefs.SetFloat(Constants.SOUND, 0);
            sound.color = Color.red;
            soundCheckmark.Hide();
            _soundSlider.value = 0;
        }        
    }
    public void ChangeMusic()
    {
        if (PlayerPrefs.GetFloat(Constants.MUSIC) == 0)
        {
            PlayerPrefs.SetFloat(Constants.MUSIC, 1);
            music.color = Color.green;
            musicCheckmark.Show();
            _musicSlider.value = 1;
            return;
        }
        else
        {
            PlayerPrefs.SetFloat(Constants.MUSIC, 0);
            music.color = Color.red;
            musicCheckmark.Hide();
            _musicSlider.value = 0;
        }
    }
    public void ChangeVibration()
    {
        if (PlayerPrefs.GetFloat(Constants.VIBRO) == 0)
        {
            PlayerPrefs.SetFloat(Constants.VIBRO, 1);
            vibration.color = Color.green;
            vibrationCheckmark.Show();
            isVibro = true;
            return;
        }
        else
        {
            PlayerPrefs.SetFloat(Constants.VIBRO, 0);
            vibration.color = Color.red;
            vibrationCheckmark.Hide();
            isVibro = false;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
