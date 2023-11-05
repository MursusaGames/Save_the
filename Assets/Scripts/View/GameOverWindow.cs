using UnityEngine;
using TMPro;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI numberOfKnifesText;
    [SerializeField] private MatchData matchData;
    [SerializeField] private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        stageText.text = "Stage " + matchData.stage.ToString();
        numberOfKnifesText.text =  matchData.numberOffKnifes.ToString();
        matchData.numberOffKnifes = 0;
        if(matchData.sound) 
            audioSource.Play();
    }
    
}
