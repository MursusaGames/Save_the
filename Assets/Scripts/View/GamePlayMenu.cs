using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private MatchData matchData;
    
    void Start()
    {
        UpdateScore();
    }

    
    public void UpdateScore()
    {
        score.text = matchData.numberOffKnifes.ToString();
    }
}
