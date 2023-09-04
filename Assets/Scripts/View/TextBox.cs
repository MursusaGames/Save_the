using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI numberApplesText;
    [SerializeField] ScoreAndAppleCountSystem data;
    int apples;
    int count = 0;
    bool isCheck;
    void Start()
    {
        apples = Random.Range(50, 200);
        StartCoroutine(nameof(ShowGiftApples));
        isCheck = true;
    }

    IEnumerator ShowGiftApples()
    {
        while(count < apples)
        {
            count++;
            numberApplesText.text = count.ToString();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void FixedUpdate()
    {
        if (isCheck && count >= apples)
        {
            Invoke(nameof(InBank), 1f);
            isCheck = false;
        }
    }

    void InBank()
    {
        StartCoroutine(nameof(GiftApplesInBank));
    }
    IEnumerator GiftApplesInBank()
    {
        while (count > 0)
        {
            count--;
            //numberApplesText.text = count.ToString();
            data.AddApple();
            yield return new WaitForSeconds(0.01f);
        }
    }
}
