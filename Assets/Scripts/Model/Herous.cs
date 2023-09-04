using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System;

public class Herous : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI helpText;
    [SerializeField] private List<string> words;
    [SerializeField] private float board;
    [SerializeField] private float boardY;
    [SerializeField] private float boardYm;
    [SerializeField] private float speed;
    [SerializeField] private MatchData data;
    private float speedY;
    private bool upDown;
    private bool isGoLeft;
    private bool isGoRight;
    private Vector3 pos;
    void OnEnable()
    {
        GetWords();
        isGoLeft = true;
        speed = 300 +100*data.level;
        speedY = speed * UnityEngine.Random.Range(-1f, 1f);
        pos = transform.localPosition;
    }
    private void GetWords()
    {
        int rand = UnityEngine.Random.Range(0, words.Count);
        helpText.text = words[rand];
        var trans = gameObject.transform.localScale;
        var textGO = helpText.gameObject.transform.localScale;
        textGO.x = trans.x;
        helpText.gameObject.transform.localScale = textGO;
    }
    private void Flip()
    {
        var trans = gameObject.transform.localScale;
        trans.x *= -1;
        gameObject.transform.localScale = trans;
        speedY = speed * UnityEngine.Random.Range(-1f, 1f);
        GetWords();
    }
    void Update()
    {
        CheckScale();
        if (isGoLeft)
        {
            pos.x -= Time.deltaTime * speed;
            pos.y += Time.deltaTime * speedY;
            transform.localPosition = pos;
            if (pos.x <= -board)
            {
                Flip();
                isGoLeft = false;
                isGoRight = true;
            }
        }

        if (isGoRight)
        {
            pos.x += Time.deltaTime * speed;
            transform.localPosition = pos;
            pos.y += Time.deltaTime * speedY;
            if (pos.x >= board)
            {
                Flip();
                isGoRight = false;
                isGoLeft = true;
            }
        }
        if (pos.y <= -boardYm )
        {
            if (!upDown)
            {
                speedY = speed;
                upDown = true;
            }
        }
        if ( pos.y >= boardY)
        {
            if (!upDown)
            {
                speedY = -speed;
                upDown = true;
            }
        }
        else
        {
            upDown = false;
        }
        
    }
    private void CheckScale()
    {
        var posT = transform.localPosition;
        var scaleT = transform.localScale;
        scaleT.x = Math.Abs(posT.y - 200f) / 1500f + 0.6f;
        if (isGoRight)
        {
            scaleT.x *= -1;
        }
        
        
        scaleT.y = Math.Abs( scaleT.x);        
        transform.localScale = scaleT;
    }
    
}
