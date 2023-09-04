using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    DateTime expiryTime;
    [SerializeField] MatchData data;
    
    private void OnEnable()
    {
        ReadTimestamp("timer");
    }
    private void Start()
    {
        if(!PlayerPrefs.HasKey("timer")) data.isGift = true;
    }
    public void StartTimer()
    {
        this.ScheduleTimer();
    }
    void Update()
    {
        if(data.isGift != true)
        {
            if (DateTime.Now > expiryTime)
            {
                Debug.Log(expiryTime.ToString());
                data.isGift = true;
                this.ScheduleTimer();
            }
        } 
        
    }
    void ScheduleTimer()
    {
        expiryTime = DateTime.Now.AddHours(24.0);
        this.WriteTimestamp("timer");
    }
    private bool ReadTimestamp(string key)
    {
        long tmp = Convert.ToInt64(PlayerPrefs.GetString(key, "0"));
        if (tmp == 0)
        {
            return false;
        }
        expiryTime = DateTime.FromBinary(tmp);
        return true;
    }

    private void WriteTimestamp(string key)
    {
        PlayerPrefs.SetString(key, expiryTime.ToBinary().ToString());
    }
    public string GetTime()
    {
        TimeSpan countdown = expiryTime - DateTime.Now;
        return countdown.Hours.ToString() + ":" + countdown.Minutes.ToString()
                            + ":" + countdown.Seconds.ToString();
    }
}
