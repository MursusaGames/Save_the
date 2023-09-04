using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
using UniRx.Extensions;

public class ScoreAndAppleCountSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TMP_Text appleText;
    [SerializeField] UserData userData;
    AudioSource audioS;

    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }
    private void Start()
    {
        //data.userData.coins.SubscribeToText(_goldText);
        userData.apple.SubscribeToText(appleText);
        appleText.text = userData.apple.ToString();
        //scoreText.text = userData.score.ToString();
    }
    public void AddApple()
    {
        userData.apple.Value++;
        appleText.text = userData.apple.ToString();
        audioS.Play();
    }
}
