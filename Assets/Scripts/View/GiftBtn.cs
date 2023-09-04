using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftBtn : MonoBehaviour
{
    [SerializeField] MatchData data;
    Image btnImg;
    bool startTimer;
    bool colorCh;
    [SerializeField] float delay = 0.5f;
    float temp;
    private string date;

    private void Awake()
    {
        btnImg = GetComponent<Image>();
    }

    private void Start()
    {
        date = DateTime.Now.DayOfYear.ToString();
        if(date == PlayerPrefs.GetString("Date", "0"))
        {
            data.isGift = false;
        }
        else
        {
            data.isGift = true;
        }
    }

    private void FixedUpdate()
    {
        if (data.isGift && !startTimer )
        {
            ChangeColor();
            startTimer = true;
            temp = delay;
        }
        if (startTimer)
        {
            temp -= 0.02f;
            if(temp <= 0)
            {
                startTimer = false;
            }
        }
    }

    private void ChangeColor()
    {
        colorCh = !colorCh;
        btnImg.color = colorCh ? Color.white : Color.cyan;
    }
}
