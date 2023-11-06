using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using UniRx.Extensions;


public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject bulletParticles;
    [SerializeField] private GameObject pistol;
    [SerializeField] private Sprite bullet;
    [SerializeField] private Sprite silverBullet;
    [SerializeField] private GameObject carrot;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject tomat;
    [SerializeField] private GameObject poop;
    [SerializeField] private GameObject egg;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource boomSource;
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private TimeController timeController;
    public int timeToEnd;
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject winWindow;
    [SerializeField] private GameObject loseWindow;
    [SerializeField] private GameObject gameWindow;
    [SerializeField] private GameObject bonusWindow;
    [SerializeField] private Transform knifeParent;
    [SerializeField] private Transform knifePos;
    [SerializeField] private List<Image> levelIcons;
    [SerializeField] private List<Image> tryIcons;
    public List<StageInfo> stages;
    [SerializeField] private TextMeshProUGUI stageNumber;
    [SerializeField] private TMP_Text score;
    public MatchData data;
    [SerializeField] private string thisStageName;
    [SerializeField] private Monster monster;
    [SerializeField] private Image monsterLeft;
    [SerializeField] private Image monsterRight;
    [SerializeField] private int thisSceneNumber;
    [SerializeField] private GameObject greenLine;
    [SerializeField] private GameObject yellowLine;
    [SerializeField] private UserData userData;
    [SerializeField] private List<GameObject> bossAnim;
    [SerializeField] private List<GameObject> monsterAnim;
    [SerializeField] private List<GameObject> deathAnim;
    [SerializeField] private GameObject finishWindow;
    [SerializeField] private Herous player;

    public int currentStage;
    private int tryCount;
    public bool bossFight;
    public bool bossFirstFight;
    private bool lastStage;

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
                if (currentStage > 5)
                {
                    lastStage = true;
                }
                break;
            case "WildOcean":
                stageNumber.text = "Stage " + data.oceanStage.ToString();
                currentStage = data.oceanStage;
                if (currentStage > 4)
                {
                    lastStage = true;
                }
                break;
            case "WildFerm":
                stageNumber.text = "Stage " + data.fermStage.ToString();
                currentStage = data.fermStage;
                if(currentStage > 5)
                {
                    lastStage = true;
                }
                break;
            case "WildForest":
                stageNumber.text = "Stage "+ data.forestStage.ToString();
                currentStage = data.forestStage;
                if (currentStage > 4)
                {
                    lastStage = true;
                }
                break;
            case "Hell":
                stageNumber.text = "Stage "+data.hellStage.ToString();
                currentStage = data.hellStage;
                if (currentStage > 4)
                {
                    lastStage = true;
                }
                break;
            case "Technopolis":
                stageNumber.text = "Stage "+data.technoStage.ToString();
                currentStage = data.technoStage;
                if (currentStage > 4)
                {
                    lastStage = true;
                }
                break;
        }
        if (lastStage)
        {
            ShowFinishWindow();
            return;
        }
        
        if (data.level == 4)
        {
            bossAnim[stages[currentStage].id].SetActive(true);
            bossFight = true;
            greenLine.SetActive(true);
        }
        else
        {
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
        SetKnife();
    }
    public void IsPoop()
    {

        PlaySound(6);
        SetPause();
        poop.SetActive(true);        
    }
    public void IsEgg()
    {
        PlaySound(7);
        SetPause();
        egg.SetActive(true);
    }
    public void IsCarrot()
    {
        carrot.SetActive(true );
        Invoke(nameof(ResetCarrotGO), 1f);
    }

    private void ResetCarrotGO()
    {
        carrot.SetActive(false);
    }
    public void IsTomate()
    {
        PlaySound(5);
        SetPause();
        tomat.SetActive(true);
        Invoke(nameof(ResetTomatGO), 1f);
    }
    private void ResetTomatGO()
    {
        tomat.SetActive(false);
    }
    public void IsStone()
    {
        
    }
    public void IsBullet()
    {
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        monsterAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Bullet", true);
        bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Bullet", true);
    }
    public void IsSilverBullet()
    {
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        monsterAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Bullet", true);
        bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Bullet", true);
    }
    public void IsStoneOut()
    {
        PlaySound(5);
        SetPause();
        stone.SetActive(true);
        Invoke(nameof(ResetStoneGO), 1f);
    }
    private void ResetStoneGO()
    {
        stone.SetActive(false);
    }
    public void IsChes()
    {
        SetPause();
        PlaySound(5);
    }
    private void SetPause()
    {
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        monsterAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Stop", true);
    }
    private void ShowFinishWindow()
    {
        finishWindow.SetActive(true);
    }
    public void ResetAnim()
    {
        monsterAnim[stages[currentStage].id].SetActive(false);
        bossAnim[stages[currentStage].id].SetActive(false);
    }

    public void PlaySound(int id)
    {
        if (data.sound)
        {
            audioSource.volume = PlayerPrefs.GetFloat(Constants.SOUND);
            audioSource.clip = id == 0 ? clips[0] : id == 1 ? clips[1] : id == 5 ? clips[5] : id == 6 ? clips[6] : clips[2];
            audioSource.Play();
        }        
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
        else if(data.currentTag == "superKnife")
        {
            knife.GetComponent<Knife>()._superKnife = true;
        }
        else if (data.currentTag == "Tomate")
        {
            knife.GetComponent<Knife>()._tomate = true;
        }
        else if (data.currentTag == "Carrot")
        {
            knife.GetComponent<Knife>()._carrot = true;
        }
        else if (data.currentTag == "stone")
        {
            knife.GetComponent<Knife>()._stone = true;
        }
        else if (data.currentTag == "poop")
        {
            knife.GetComponent<Knife>()._poop = true;
        }
        else if (data.currentTag == "Tykw")
        {
            knife.GetComponent<Knife>().SetTykw();
        }
        else if (data.currentTag == "Shark")
        {
            knife.GetComponent<Knife>()._shark = true;
        }
        else if (data.currentTag == "Meduza")
        {
            knife.GetComponent<Knife>()._meduza = true;
        }
        else if (data.currentTag == "bullet")
        {
            bulletParticles.SetActive(false);
            knife.GetComponent<Knife>()._bullet = true;
            pistol.SetActive(true);
            knife.GetComponent<Image>().sprite = bullet;
        }
        else if (data.currentTag == "silverBullet")
        {
            bulletParticles.SetActive(false);
            knife.GetComponent<Knife>()._silverBullet = true;
            pistol.SetActive(true);
            knife.GetComponent<Image>().sprite = silverBullet;
        }
        else if (data.currentTag == "egg")
        {
            knife.GetComponent<Knife>()._egg = true;
        }
    }
    public void Bullet()
    {
        bulletParticles.SetActive(true);
    }
    public void IsTime()
    {
        //audioSource.clip = clips[4];
        //audioSource.Play();
        tryCount = 1;
        Fall();
    }
    public void PlayBoom()
    {
        boomSource.Play();
    }
    public void ResetYellowLine()
    {
        yellowLine.SetActive(false);
    }
    public void Fall()
    {
        poop.SetActive(false);
        egg.SetActive(false);
        player.LetsPlay();
        monster.LetsPlay();
        timeController.LetsPlay();
        monsterAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Stop", false);              
        if (bossFirstFight)
        {
            greenLine.SetActive(false);
            yellowLine.SetActive(true);
        }
        if (tryCount > 0)
        {
            tryCount--;
        }        
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
        player.gameObject.SetActive(false);
        monster.gameObject.SetActive(false);
        deathAnim[currentStage].SetActive(true);
        Invoke(nameof(OpenLooseWindow), 3f);
    }
    private void OpenLooseWindow()
    {
        loseWindow.SetActive(true);
        gameWindow.SetActive(false);
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
