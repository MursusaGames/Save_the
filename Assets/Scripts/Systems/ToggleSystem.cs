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
    [SerializeField] private MatchData data;
    public bool isVibro;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(Constant.SOUND))
        {
            PlayerPrefs.SetFloat(Constant.SOUND, 0.5f);
            sound.color = Color.green;
            soundCheckmark.Show();
        }
        if (!PlayerPrefs.HasKey(Constant.MUSIC))
        {
            PlayerPrefs.SetFloat(Constant.MUSIC, 0.5f);
            music.color = Color.green;
            musicCheckmark.Show();
        }
        if (!PlayerPrefs.HasKey(Constant.VIBRO))
        {
            PlayerPrefs.SetFloat(Constant.VIBRO, 1);
            vibration.color = Color.green;
            vibrationCheckmark.Show();
        }
        LoadAudio(_soundSlider, _musicSlider);
    }
    public void LoadAudio(Slider soundSlider, Slider musicSlider)
    {
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Sound, PlayerPrefs.GetFloat(Constant.SOUND, 0.5f));
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Music, PlayerPrefs.GetFloat(Constant.MUSIC, 0.5f));

        if (PlayerPrefs.HasKey(Constant.SOUND))
            soundSlider.value = PlayerPrefs.GetFloat(Constant.SOUND, 0.5f);

        if (PlayerPrefs.HasKey(Constant.MUSIC))
            musicSlider.value = PlayerPrefs.GetFloat(Constant.MUSIC, 0.5f);
    }
    private void OnEnable()
    {
        if (PlayerPrefs.GetFloat(Constant.SOUND) > 0)
        {
            sound.color = Color.green;
            soundCheckmark.Show();
            data.sound = true;
        }
        else
        {
            sound.color = Color.red;
            soundCheckmark.Hide();
            data.sound = false;
        }

        if (PlayerPrefs.GetFloat(Constant.MUSIC) > 0)
        {
            music.color = Color.green;
            musicCheckmark.Show();
            data.music = true;
        }
        else
        {
            music.color = Color.red;
            musicCheckmark.Hide();
            data.music = false;
        }

        if (PlayerPrefs.GetFloat(Constant.VIBRO) == 1)
        {
            vibration.color = Color.green;
            vibrationCheckmark.Show();
            isVibro = true;
            data.vibro = true;
        }
        else
        {
            vibration.color = Color.red;
            vibrationCheckmark.Hide();
            isVibro = false;
            data.vibro = false;
        }
        _soundSlider.value = PlayerPrefs.GetFloat(Constant.SOUND);
        _musicSlider.value = PlayerPrefs.GetFloat(Constant.MUSIC);
    }
    public void ChangeSoundVolume()
    {
        float value = _soundSlider.GetComponent<Slider>().value;
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Sound, value);
        PlayerPrefs.SetFloat(Constant.SOUND, value);
        if (value == 0)
        {
            sound.color = Color.red;
            soundCheckmark.Hide();
            data.sound = false;
        }
        else
        {
            sound.color = Color.green;
            soundCheckmark.Show();
            data.sound = true;
        }
    }

    public void ChangeMusicVolume()
    {
        float value = _musicSlider.GetComponent<Slider>().value;
        SoundDesigner.SetVolumeAudioSource(SoundBaseType.Music, value);
        PlayerPrefs.SetFloat(Constant.MUSIC, value);
        if(value == 0)
        {
            music.color = Color.red;
            musicCheckmark.Hide();
            data.music = false;
        }
        else
        {
            music.color = Color.green;
            musicCheckmark.Show();
            data.music = true;
        }
    }
    public void ChangeSound()
    {
        if(PlayerPrefs.GetFloat(Constant.SOUND) == 0)
        {
            PlayerPrefs.SetFloat(Constant.SOUND, 1);
            sound.color = Color.green;
            soundCheckmark.Show();
            data.sound = true;
            _soundSlider.value = 1;
            return;
        }
        else
        {
            PlayerPrefs.SetFloat(Constant.SOUND, 0);
            sound.color = Color.red;
            soundCheckmark.Hide();
            data.sound = false;
            _soundSlider.value = 0;
        }        
    }
    public void ChangeMusic()
    {
        if (PlayerPrefs.GetFloat(Constant.MUSIC) == 0)
        {
            PlayerPrefs.SetFloat(Constant.MUSIC, 1);
            music.color = Color.green;
            musicCheckmark.Show();
            data.music = true;
            _musicSlider.value = 1;
            return;
        }
        else
        {
            PlayerPrefs.SetFloat(Constant.MUSIC, 0);
            music.color = Color.red;
            musicCheckmark.Hide();
            data.music = false;
            _musicSlider.value = 0;
        }
    }
    public void ChangeVibration()
    {
        if (PlayerPrefs.GetFloat(Constant.VIBRO) == 0)
        {
            PlayerPrefs.SetFloat(Constant.VIBRO, 1);
            vibration.color = Color.green;
            vibrationCheckmark.Show();
            data.vibro = true;
            isVibro = true;
            return;
        }
        else
        {
            PlayerPrefs.SetFloat(Constant.VIBRO, 0);
            vibration.color = Color.red;
            vibrationCheckmark.Hide();
            data.vibro = false;
            isVibro = false;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
