using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomsSection : MonoBehaviour
{
    [SerializeField] GameObject customsWindow;
    [SerializeField] TMP_Text coins;
    [SerializeField] GameObject swipeHand;
    [SerializeField] MatchData data;
    [SerializeField] UserData userData;



    public void ShowCustomWindow()
    {
        Debug.Log("Click");
        customsWindow.SetActive(true);
        UpdateCoins();
        bool showSwipeHand = !PlayerPrefs.HasKey("SwipeHelp");
        swipeHand.SetActive(showSwipeHand);
    }

    public void UpdateCoins()
    {
        var coin = userData.apple;
        coins.text = coin.ToString();
    }

    public void HideCustomWindow()
    {
        customsWindow.SetActive(false);
    }
}
