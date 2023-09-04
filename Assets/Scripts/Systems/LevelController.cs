using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using UniRx.Extensions;


public class LevelController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private TimeController timeController;
    public int timeToEnd;
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject winWindow;
    [SerializeField] private GameObject loseWindow;
    [SerializeField] private GameObject bonusWindow;
    [SerializeField] private Transform knifeParent;
    [SerializeField] private Transform knifePos;
    [SerializeField] private List<Image> levelIcons;
    [SerializeField] private List<Image> tryIcons;
    public List<StageInfo> stages;
    [SerializeField] private TextMeshProUGUI stageNumber;
    [SerializeField] private TMP_Text score;
    [SerializeField] private MatchData data;
    [SerializeField] private string thisStageName;
    [SerializeField] private Image monster;
    [SerializeField] private Image monsterLeft;
    [SerializeField] private Image monsterRight;
    [SerializeField] private int thisSceneNumber;
    [SerializeField] private GameObject greenLine;
    [SerializeField] private GameObject yellowLine;
    [SerializeField] private UserData userData;
    [SerializeField] private List<GameObject> bossAnim;
    [SerializeField] private List<GameObject> monsterAnim;

    public int currentStage;
    private int tryCount;
    public bool bossFight;
    public bool bossFirstFight;

    private void Start()
    {
        userData.apple.SubscribeToText(score);
    }
    void OnEnable()
    {
        switch (thisStageName)
        {
            case "Game":
                stageNumber.text = "Stage " + data.gameStage.ToString();
                currentStage = data.gameStage;
                break;
            case "WildOcean":
                stageNumber.text = "Stage " + data.oceanStage.ToString();
                currentStage = data.oceanStage;
                break;
            case "WildFerm":
                stageNumber.text = "Stage " + data.fermStage.ToString();
                currentStage = data.fermStage;
                break;
            case "WildForest":
                stageNumber.text = "Stage "+ data.forestStage.ToString();
                currentStage = data.forestStage;
                break;
            case "Hell":
                stageNumber.text = "Stage "+data.hellStage.ToString();
                currentStage = data.hellStage;
                break;
            case "Technopolis":
                stageNumber.text = "Stage "+data.technoStage.ToString();
                currentStage = data.technoStage;
                break;
        }
        if (data.level == 4)
        {
            monster.enabled = false;
            bossAnim[stages[currentStage].id].SetActive(true);
            bossFight = true;
            greenLine.SetActive(true);
        }
        else
        {
            monster.enabled = false;
            monsterAnim[stages[currentStage].id].SetActive(true);
        }
        monster.gameObject.tag = stages[currentStage].monsterTag;
        timeToEnd = stages[currentStage].timeToEnd;
        timeController.SetTime();
        monsterLeft.sprite = stages[currentStage].monsterHalf1;
        monsterRight.sprite = stages[currentStage].monsterHalf2;
        tryCount = stages[currentStage].tryCount;
        for (int i = 0; i <= data.level; i++)
        {
            levelIcons[i].color = Color.yellow;
        }
        
        /*for (int i = 0; i < tryCount ; i++)
        {
            tryIcons[i].gameObject.SetActive(true);
        }*/
        SetKnife();
    }
    public void ResetAnim()
    {
        monsterAnim[stages[currentStage].id].SetActive(false);
        bossAnim[stages[currentStage].id].SetActive(false);
    }

    public void PlaySound(int id)
    {
        audioSource.clip = id ==0 ? clips[0] : id == 1 ? clips[1] : id == 1?clips[3] : clips[2];
        audioSource.Play();
    }
    private void SetKnife()
    {
        var knife = Instantiate(knifePrefab, knifePos.position, Quaternion.identity, knifeParent);
        knife.GetComponent<Image>().sprite = data.currentKnife;
        knife.tag = data.currentTag;
        if(data.currentTag == "Knife")
        {
            knife.GetComponent<Knife>()._knife = true;
        }
    }
    public void IsTime()
    {
        audioSource.clip = clips[4];
        audioSource.Play();
        tryCount = 1;
        Fall();
    }
    public void Fall()
    {
        if (bossFirstFight)
        {
            greenLine.SetActive(false);
            yellowLine.SetActive(true);
        }
        tryCount--;
        tryIcons[tryCount].color = Color.gray;
        if (tryCount == 0)
        {
            GameOver();
            return;
        }
        SetKnife();
    }
    private void GameOver()
    {
        loseWindow.SetActive(true);
    }
    public void Win()
    {
        if (bossFight)
        {
            bonusWindow.SetActive(true);
            switch (thisStageName)
            {
                case "Game":
                    data.gameStage++;
                    PlayerPrefs.SetInt(Constants.GAMESTAGE, data.gameStage);
                    break;
                case "WildOcean":
                    data.oceanStage++;
                    PlayerPrefs.SetInt(Constants.OCEANSTAGE, data.oceanStage);
                    break;
                case "WildFerm":
                    data.fermStage++;
                    PlayerPrefs.SetInt(Constants.FERMSTAGE, data.fermStage);
                    break;
                case "WildForest":
                    data.forestStage++;
                    PlayerPrefs.SetInt(Constants.FORESTSTAGE, data.forestStage);
                    break;
                case "Hell":
                    data.hellStage++;
                    PlayerPrefs.SetInt(Constants.HELLSTAGE, data.hellStage);
                    break;
                case "Technopolis":
                    data.technoStage++;
                    PlayerPrefs.SetInt(Constants.TECHNOSTAGE, data.technoStage);
                    break;
            }
            return;
        }
        winWindow.SetActive(true);
    }
    public void NextLevel()
    {
        data.level++;
        SceneManager.LoadScene(thisSceneNumber);
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
