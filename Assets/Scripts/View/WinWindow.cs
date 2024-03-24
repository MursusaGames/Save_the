using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI numberOfKnifesText;
    [SerializeField] private MatchData matchData;
    [SerializeField] private UserData userData;
    [SerializeField] private LevelController levelController;
    private AudioSource source;
    // Start is called before the first frame update
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat(Constant.SOUND);
    }
    void OnEnable()
    {
        if (matchData.sound)
        {
            source.Play();
        }
        stageText.text = "Stage " + matchData.stage.ToString();
        userData.apple.Value += levelController.stages[levelController.currentStage].score;
        PlayerPrefs.SetInt(Constant.SCORE, userData.apple.Value);
        numberOfKnifesText.text = levelController.stages[levelController.currentStage].score.ToString();
    }
}
