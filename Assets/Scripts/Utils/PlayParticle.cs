using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] private GameObject partikle;
    [SerializeField] private GameObject gasPart;
    [SerializeField] private GameObject greenLine;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private MatchData data;
    public bool bomb;
    private float vol;


    private void Start()
    {
       vol = PlayerPrefs.GetFloat(Constants.SOUND);
    }
    public void PlayPart()
    {
        partikle.SetActive(true);
        if (bomb)
        {
            greenLine.SetActive(false);
        }        
    }
    public void ShowGas()
    {
        gasPart.SetActive(true);
    }
    public void PlaySound()
    {
        audioSource.volume = vol;
        if (data.sound)
        {
            audioSource.Play();
        }        
    }
}
