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
    private bool blue;
    [SerializeField] float delay = 0.5f;
    float temp;
    private int date;

    private void Awake()
    {
        btnImg = GetComponent<Image>();
    }

    private void OnEnable()
    {
        date = DateTime.Now.DayOfYear;
        int firstDay = data.firstDay;
        int sub = date - firstDay;
        if (sub > 15) 
            sub = 15;
        for (int i = 0; i <= sub; i++)
        {
            if(!PlayerPrefs.HasKey(Constant.PRIZE_BAG + i))
            {
                data.isGift = true;
            }
            else
            {
                data.isGift = false;
                btnImg.color = Color.cyan;
            }
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
        if(!data.isGift && !blue)
        {
            btnImg.color = Color.cyan;
            blue = true;
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
