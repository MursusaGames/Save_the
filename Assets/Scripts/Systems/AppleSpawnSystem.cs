using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleSpawnSystem : MonoBehaviour
{
    [SerializeField] MatchData matchData;
    StagePrefab stagePrefab;
    int apples;
    int knifes;
    int bossStage = 4;
    private Sprite ring;
    bool isStagePrefab;
    private void Start()
    {
        InitData();
    }
    
    public void GetStagePrefab(StagePrefab _stagePrefab)
    {
        stagePrefab = _stagePrefab;
        isStagePrefab = true;
        stagePrefab.GameStart += InitStage;
    }
    private void InitData()
    {
        
        ring = matchData.ringSprite;
        if (matchData.level < bossStage)
        {
            knifes = matchData.level;
            if (GetAppleCount())
            {
                apples = matchData.level;
            }
        }
        else
        {
            knifes = 0;
            apples = 0;
            ring = matchData.bossSprite;
        }
    } 
    public void ReloadLevel()
    {
        InitData();
        //InitStage();
    }
    void OnDisable()
    {
        if(isStagePrefab) stagePrefab.GameStart -= InitStage;
    }

    private bool GetAppleCount()
    {
        bool isApple = false;
        int rand = Random.Range(0, 100);        //100%
        if (rand < matchData.appleSpawnChance) isApple = true;        
        return isApple;
    }
    private void InitStage()
    {
        stagePrefab.InitStage(knifes, apples, ring);
    }    
}
