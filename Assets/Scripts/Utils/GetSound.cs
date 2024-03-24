using UnityEngine;

public class GetSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private MatchData data;
    public bool bomb;
    void OnEnable()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat(Constant.SOUND);
        if (bomb)
        {
            PlaySound();
        }
    }

    public void PlaySound()
    {
        if(data.sound)
            audioSource.Play();
    }
    public void StopSound()
    {
        audioSource.Stop();
    }
}
