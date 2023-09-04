using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI numberOfKnifesText;
    [SerializeField] private MatchData matchData;
    // Start is called before the first frame update
    void Start()
    {
        stageText.text = "Stage " + matchData.stage.ToString();
        numberOfKnifesText.text =  matchData.numberOffKnifes.ToString();
        matchData.numberOffKnifes = 0;
    }
    
}
