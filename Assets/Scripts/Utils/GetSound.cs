using UnityEngine;

public class GetSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private MatchData data;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat(Constants.SOUND);
    }

    public void PlaySound()
    {
        if(data.sound)
            audioSource.Play();
    }
}
