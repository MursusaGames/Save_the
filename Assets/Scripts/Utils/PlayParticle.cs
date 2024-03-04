using UnityEngine;
using System.Collections.Generic;

public class PlayParticle : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private List<AudioSource> runSounds;
    [SerializeField] private AudioSource veterSound;
    [SerializeField] private AudioSource gromSound;
    [SerializeField] private AudioSource glasSound;
    [SerializeField] private GameObject glue2;
    [SerializeField] private GameObject glue;
    [SerializeField] private Transform parentGlue;
    [SerializeField] private GameObject peel;
    [SerializeField] private GameObject peel2;
    [SerializeField] private Transform parentPeel;
    [SerializeField] private GameObject partikle;
    [SerializeField] private GameObject gasPart;
    [SerializeField] private GameObject pepperGasPart;
    [SerializeField] private GameObject greenLine;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceCrick;
    [SerializeField] private AudioSource cactusSound;
    [SerializeField] private AudioSource blyakSound;
    [SerializeField] private AudioSource hahaSound;
    [SerializeField] private AudioSource treeSound;
    [SerializeField] private MatchData data;
    private Animator animator;
    private Vector3 peelPos;
    public bool bomb;
    private float vol;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        vol = PlayerPrefs.GetFloat(Constants.SOUND);
    }
    public void RunSoundsPlay()
    {
        var rand = Random.Range(0, 6);
        if(rand < 3)
        {
            if (data.sound)
            {
                runSounds[rand].volume = vol;
                runSounds[rand].Play();
            }            
        }
    }
    public void PlayPart()
    {
        partikle.SetActive(true); 
        if (bomb)
        {
            greenLine.SetActive(false);
        }        
    }
    public void StopRunSound()
    {
        levelController.StopRunSound();
    }
    public void ShowGas()
    {
        gasPart.SetActive(true);
    }
    public void ShowPepperGas()
    {
        pepperGasPart.SetActive(true);
    }
    public void PlaySound()
    {
        audioSource.volume = vol;
        if (data.sound)
        {
            audioSource.Play();
        }        
    }
    public void PlayGlasSound()
    {
        glasSound.volume = vol;
        if (data.sound)
        {
            glasSound.Play();
        }
    }
    public void PlayVeterSound()
    {
        veterSound.volume = vol;
        if (data.sound)
        {
            veterSound.Play();
        }
    }
    public void PlayGromSound()
    {
        gromSound.volume = vol;
        if (data.sound)
        {
            gromSound.Play();
        }
    }
    public void Chespepper()
    {
        pepperGasPart.SetActive(true);
        hahaSound.volume = vol;
        if (data.sound)
        {
            hahaSound.Play();
        }
    }
    public void PlayCrick()
    {
        audioSourceCrick.volume = vol;
        if (data.sound)
        {
            audioSourceCrick.Play();
        }
    }
    public void CactusSound()
    {
        cactusSound.volume = vol;
        if (data.sound)
        {
            cactusSound.Play();            
        }        
    }
    public void BlyakSound()
    {
        blyakSound.volume = vol;
        if (data.sound)
        {
            blyakSound.Play();
        }
    }
    public void CactusEnd()
    {
        animator.SetBool("Cactus", false);
    }
    public void GlueEnd()
    {
        animator.SetBool("Glue", false);
    }
    public void BombEnd()
    {
        animator.SetBool("Bomb", false);
    }
    public void ChuchaEnd()
    {
        animator.SetBool("Chucha", false);
    }
    public void AttacEnd()
    {
        animator.SetBool("Stop", false);
        animator.SetBool("Attac", false);
    }
    public void FireworkEnd()
    {
        animator.SetBool("Firework", false);
    }
    public void PeelEnd()
    {
        animator.SetBool("Peel", false);
    }
    public void PapirEnd()
    {
        animator.SetBool("Papir", false);
    }
    public void GasEnd()
    {
        animator.SetBool("Gas", false);
    }
    public void StoneEnd()
    {
        //animator.SetBool("Stone", false);
    }
    public void PepperEnd()
    {
        animator.SetBool("PepperGas", false);
        pepperGasPart.SetActive(false);
    }
    public void TreeSound()
    {
        treeSound.volume = vol;
        if (data.sound)
        {
            treeSound.Play();
        }
    }
    public void StopTreeSound()
    {
        treeSound.Stop();
    }
    public void HahaSound()
    {
        hahaSound.volume = vol;
        if (data.sound)
        {
            hahaSound.Play();
        }
    }
    public void KeepGlue()
    {
        glue.transform.SetParent(parentGlue);
        glue2.transform.localPosition = glue.transform.localPosition;
        glue2.SetActive(true);
    }
    public void StopGlue()
    {
        animator.SetBool("Glue", false);        
    }
    public void MolotovEnd()
    {
        animator.SetBool("Molotov", false);
    }
    public void ScatEnd()
    {
        animator.SetBool("Scat", false);
    }

}
