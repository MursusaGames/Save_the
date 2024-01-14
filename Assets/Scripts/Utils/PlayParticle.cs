using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] private GameObject partikle;
    [SerializeField] private GameObject gasPart;
    [SerializeField] private GameObject greenLine;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource cactusSound;
    [SerializeField] private MatchData data;
    private Animator animator;
    public bool bomb;
    private float vol;


    private void Start()
    {
        animator = GetComponent<Animator>();
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
    public void CactusSound()
    {
        if (data.sound)
        {
            cactusSound.Play();            
        }        
    }
    public void CactusEnd()
    {
        animator.SetBool("Cactus", false);
    }
    public void PapirEnd()
    {
        animator.SetBool("Papir", false);
    }
    public void StoneEnd()
    {
        //animator.SetBool("Stone", false);
    }
}
