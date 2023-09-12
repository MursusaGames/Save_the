using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private Image bar;
    [SerializeField] private TextMeshProUGUI seconds;    
    private bool startTimer;
    private float timeToEnd;
    private float increaseTime;
    private bool pause;

    public void GetPause()
    {
        pause = true;
    }

    public void LetsPlay()
    {
        pause = false;
    }
    public void SetTime()
    {
        timeToEnd = levelController.timeToEnd;
        increaseTime = 0f;
        startTimer = true;
    }    

    void Update()
    {
        if (pause) return;
        if (startTimer)
        {
            increaseTime += Time.deltaTime;
            bar.fillAmount = 1f - (increaseTime / timeToEnd);
            seconds.text = (timeToEnd - increaseTime).ToString("0");
            if(bar.fillAmount > 0.5f)
            {
                bar.color = Color.green;
            }
            else if(bar.fillAmount < 0.2f)
            {
                bar.color = Color.red;                
            }
            else
            {
                bar.color = Color.yellow;
            }
            if(increaseTime >= timeToEnd)
            {
                increaseTime = 0f;
                startTimer = false;                
                levelController.IsTime();
            }
        }
    }
}
