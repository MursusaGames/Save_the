using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchScreenSystem : MonoBehaviour 
{
    RectTransform knifeParent;    
    [SerializeField] GamePlaySystem playSystem;
    [SerializeField] private GamePlayMenu playMenu;
    [SerializeField] private GameObject winWindow;    
    [SerializeField] private MatchData data;
    [SerializeField] private StageControllerSystem stageController;
    public GameObject _halfMonster;
    private Knife _knife;
    private int count;
    private bool win;
    
    public void GetKnifeParent(RectTransform _knifeParent)
    {
        knifeParent = _knifeParent;
    }
    public void GetKnife(Knife knife)
    {
        _knife = knife;        
    }
    public void SetKnifeParent(Knife knife)
    {
        knife.gameObject.transform.SetParent(knifeParent);
        
    }
   /* public void Win()
    {
        win = true;
        if(data.level == 4)
        {
            stageController.NewLevel();
        }
        else
        {
            winWindow.SetActive(true);
        }        
    }*/
    /*public void GameOver()
    {
        playSystem.GameOver();
    }*/
    /*public void KnifeIn()
    {
        //playSystem.matchData.numberOffKnifes++;
        //playMenu.UpdateScore();
        Invoke(nameof(CheckWin), 1f);
       
    }
    private void CheckWin()
    {
        if(!win)
        {
            count++;
        }
        else
        {
            win = false;
        }
            
        if (count == 3)
        {
            GameOver();
        }
        playSystem.KnifeIsGo();
        Invoke(nameof(NewKnife), 0.01f);
    }*/
    public void Go()
    {
        _knife.KnifeGo();
    }  
    
    /*private void NewKnife()
    {
        playSystem.CreateKnife();        
    }*/

}
