using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GiftSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private List<Button> giftBtns;    
    [SerializeField] private UserData userData;
    private int date;
    private int index;

    private void OnEnable()
    {
        date = DateTime.Now.DayOfYear;
        if (!PlayerPrefs.HasKey("DateOfYear"))
        {
            PlayerPrefs.SetInt("DateOfYear", date);
            PlayerPrefs.SetInt("FirstDay", date);
            data.firstDay = date;
        }
        else
        {
            data.firstDay = PlayerPrefs.GetInt("FirstDay");
            index = date - data.firstDay;
            if (index > 15)
            {
                index = 15;
            }
        }
        for (int i = 0; i <= index; i++)
        {
            giftBtns[i].gameObject.SetActive(true);
            giftBtns[i].interactable = true;
        } 
    }
    
    
    public void GetPrize(int id)
    {
        PlayerPrefs.SetString(Constant.PRIZE_BAG + id, "yes");
        data.isGift = false;
    }
   
}
