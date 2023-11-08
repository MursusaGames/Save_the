using UnityEngine;

public class GetSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private MatchData data;
    public bool bomb;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat(Constants.SOUND);
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
}
