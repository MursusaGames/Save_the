using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GiftSystem : MonoBehaviour
{
    [SerializeField] TimerSystem timerSystem;
    [SerializeField] GameObject giftWindow;
    [SerializeField] MatchData data;
    [SerializeField] GameObject blockerWindow;
    [SerializeField] TextMeshProUGUI blockerText;
    [SerializeField] Image giftBtnImg;
    [SerializeField] private UserData userData;
    private string date;

    private void OnEnable()
    {
        date = DateTime.Now.DayOfYear.ToString();
    }
    public void StartGiftMode()
    {
        var _date = PlayerPrefs.GetString("Date", "0");
        if (date == _date)
        {
            blockerWindow.Show();
            blockerText.text =  "IN NEXT DAY";
            Invoke(nameof(HideBlockerWindow), 1.3f);
            return;
        }
        
        giftWindow.Show();
    }
    public void StopGiftMode()
    {
        PlayerPrefs.SetInt(Constants.SCORE, userData.apple.Value);
        data.isGift = false;
        giftWindow.Hide();
        timerSystem.StartTimer();
        giftBtnImg.color = Color.cyan;
        PlayerPrefs.SetString("Date", date);
    }
    
    void HideBlockerWindow()
    {
        blockerWindow.Hide();
    }
}
