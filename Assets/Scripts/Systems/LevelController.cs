using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using UniRx.Extensions;
using UnityEngine.Experimental.Rendering;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject firePartikl;
    [SerializeField] private GameObject fireworkPartikl;
    [SerializeField] private List<GameObject> magicAnimals;
    [SerializeField] private GameObject magicPartikl;
    [SerializeField] private Sprite star;
    [SerializeField] private GameObject magicWand;
    [SerializeField] private GameObject rocet;
    [SerializeField] private GameObject nuclear;
    [SerializeField] private List<GameObject> socks;    
    [SerializeField] private GameObject waterPartikl;
    [SerializeField] private GameObject yellowPartikl;
    [SerializeField] private Sprite water;
    [SerializeField] private GameObject acid;
    [SerializeField] private GameObject bulletParticles;
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject waterPistol;
    [SerializeField] private Sprite bullet;
    [SerializeField] private Sprite silverBullet;
    [SerializeField] private GameObject carrot;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject tomat;
    [SerializeField] private GameObject poop;
    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject gas;
    [SerializeField] private List<GameObject> cactuses;
    [SerializeField] private List<GameObject> arrows;
    [SerializeField] private List<GameObject> spears;    
    [SerializeField] private GameObject blessed;
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
    [SerializeField] public string thisStageName;
    [SerializeField] private Monster monster;
    [SerializeField] private Image monsterLeft;
    [SerializeField] private Image monsterRight;
    [SerializeField] public int thisSceneNumber;
    [SerializeField] private GameObject greenLine;
    [SerializeField] private GameObject yellowLine;
    [SerializeField] private GameObject ballGO;
    [SerializeField] private UserData userData;
    [SerializeField] private List<GameObject> bossAnim;
    [SerializeField] private List<GameObject> monsterAnim;
    [SerializeField] private List<GameObject> deathAnim;
    [SerializeField] private GameObject finishWindow;
    [SerializeField] private Herous player;
    public Animator currentAnim;
    public int currentStage;
    private int tryCount;
    public bool bossFight;
    public bool bossFirstFight;
    private bool lastStage;
    public int ballPower;

    private void Start()
    {
        userData.apple.SubscribeToText(score);
    }
    void OnEnable()
    {
        ballPower = 2;
        switch (thisStageName)
        {
            case "Game":
                stageNumber.text = "Stage " + data.gameStage.ToString();
                currentStage = data.gameStage;
                if (currentStage > 4)
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
                if (currentStage > 5)
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
            currentAnim = bossAnim[stages[currentStage].id].GetComponent<Animator>();
            bossAnim[stages[currentStage].id].SetActive(true);
            bossFight = true;
            greenLine.SetActive(true);
        }
        else
        {
            currentAnim = monsterAnim[stages[currentStage].id].GetComponent<Animator>();
            monsterAnim[stages[currentStage].id].SetActive(true);
        }
        monster.gameObject.tag = stages[currentStage].monsterTag;
        timeToEnd = stages[currentStage].timeToEnd;
        timeController.SetTime();
        monsterLeft.sprite = stages[currentStage].monsterHalf1;
        monsterRight.sprite = stages[currentStage].monsterHalf2;
        data.currentMonster = stages[currentStage].bossSprite;
        tryCount = stages[currentStage].tryCount;
        for (int i = 0; i <= data.level; i++)
        {
            levelIcons[i].color = Color.yellow;
        }        
        SetKnife();
    }
    #region Weapons

    public void IsChucha()
    {
        SetPause();
        currentAnim.SetBool("Chucha", true);
    }
    public void IsPoop()
    {

        PlaySound(6);
        SetPause();
        poop.SetActive(true);        
    }
    public void IsEgg()
    {
        //PlaySound(7);
        SetPause();
        egg.SetActive(true);
    }
    public void IsRocet(int id = 0)
    {
        SetPause();
        if (id == 0)
        {
            currentAnim.gameObject.SetActive(false);
        }        
        rocet.SetActive(true);
    }
    public void IsNuclear()
    {
        SetPause();
        currentAnim.gameObject.SetActive(false);
        rocet.SetActive(true);
        nuclear.SetActive(true);
    }
    public void IsForest()
    {
        PlaySound(2);
        SetPause();
        bomb.SetActive(true);
        //monsterAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Bomb", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Bomb", true);
    }
    public void IsBomb()
    {
        //PlaySound(2);
        SetPause();
        currentAnim.SetBool("Bomb", true);
    }
    public void IsMor()
    {
        //PlaySound(2);
        SetPause();
        currentAnim.SetBool("Attac", true);
    }
    public void VampirDy()
    {
        SetPause();
        currentAnim.SetBool("Dy", true);
    }
    public void IsPeel()
    {
        //PlaySound(2);
        SetPause();
        currentAnim.SetBool("Peel", true);
    }
    public void IsGas()
    {
        //PlaySound(2);
        SetPause();
        //bomb.SetActive(true);
        currentAnim.SetBool("Gas", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Gas", true);
    }
    public void IsPepperGas()
    {
        //PlaySound(2);
        SetPause();
        //bomb.SetActive(true);
        currentAnim.SetBool("PepperGas", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Gas", true);
    }
    public void IsCarrot()
    {
        carrot.SetActive(true );
        Invoke(nameof(ResetCarrotGO), 1f);
    }
    public void ShowSock()
    {
        socks[currentStage].SetActive(true);
    }
    public void IsCactus()
    {
        SetPause();
        cactuses[currentStage].SetActive(true);
        currentAnim.SetBool("Cactus", true);
        Invoke(nameof(ResetCactus), 1f);
    }
    private void ResetCactus()
    {
        cactuses[currentStage].SetActive(false);
    }
    public void IsBall()
    {
        ballPower--;
        if(ballPower <= 0)
        {
            SetPause();
            currentAnim.SetBool("Stone", true);            
        }
    }
    public void IsPapir()
    {
        PlaySound(1);
        SetPause();
        //cactuses[currentStage].SetActive(true);
        currentAnim.SetBool("Papir", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Cactus", true);
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
    public void JustTomate()
    {
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
        currentAnim.SetBool("Stone", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Stone", true);
        PlaySound(7);
        SetPause();        
        //monsterAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Stone", true);
        //bossAnim[stages[currentStage].id].GetComponent<Animator>().SetBool("Stone", true);
        stone.SetActive(true);
    }
    public void IsBullet()
    {
        tomat.SetActive(true);
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Bullet", true);
        Invoke(nameof(ResetTomatGO), 1f);
    }
    public void IsWord()
    {
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Word", true);
    }
    public void IsArrow(int id)
    {
        tomat.SetActive(true);
        arrows[currentStage].SetActive(true);
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        if(id == 0)
        {
            currentAnim.SetBool("Bullet", true);
        }
        else
        {
            currentAnim.SetBool("Poison", true);
        }
               
    }
    public void IsSpear()
    {
        tomat.SetActive(true);
        spears[currentStage].SetActive(true);
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Stone", true);
    }
    public void IsMolot()
    {
        tomat.SetActive(true);
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();        
    }
    public void IsAcid()
    {
        acid.SetActive(true);
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Acid", true);
    }
    public void IsWater()
    {
        waterPartikl.SetActive(true);
        SetPause();   
    }
    public void IsMagic()
    {
        magicPartikl.SetActive(true);
        SetPause();
        currentAnim.gameObject.SetActive(false);
        int rand = Random.Range(0, magicAnimals.Count);
        magicAnimals[rand].SetActive(true);
    }
    public void IsGlue()
    {
        yellowPartikl.SetActive(true);
        SetPause();
        currentAnim.SetBool("Glue", true);
    }
    public void IsScat()
    {
        SetPause();
        currentAnim.SetBool("Scat", true);
    }
    public void IsMolotov()
    {
        SetPause();
        currentAnim.SetBool("Molotov", true);
    }
    public void IsFirework(int id =0 )
    {
        fireworkPartikl.SetActive(true);
        SetPause();
        if (id == 1)
        {
            IsChes();
        }
        else
        {
            currentAnim.SetBool("Firework", true);
        }            
    }
    public void IsSilverBullet()
    {
        tomat.SetActive(true);
        timeController.GetPause();
        player.GetPause();
        monster.GetPause();
        currentAnim.SetBool("Bullet", true);        
        Invoke(nameof(ResetTomatGO), 1f);
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
    #endregion

    #region Utilits
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
        SetPause();
        monsterAnim[stages[currentStage].id].SetActive(false);
        bossAnim[stages[currentStage].id].SetActive(false);
    }
    public void PlaySound(int id)
    {
        if (data.sound)
        {
            audioSource.volume = PlayerPrefs.GetFloat(Constants.SOUND);
            audioSource.clip = clips[id];
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
        else if (data.currentTag == "bomb")
        {
            knife.GetComponent<Knife>()._bomb = true;
        }
        else if (data.currentTag == "churiken")
        {
            knife.GetComponent<Knife>()._churik = true;
        }
        else if (data.currentTag == "gas")
        {
            knife.GetComponent<Knife>()._gas = true;
        }
        else if (data.currentTag == "blessedSword")
        {
            knife.GetComponent<Knife>()._blessedSword = true;
            blessed.SetActive(true);
        }
        else if (data.currentTag == "Cactus")
        {
            knife.GetComponent<Knife>()._cactus = true;
        }
        else if (data.currentTag == "stone")
        {
            knife.GetComponent<Knife>()._stone = true;
        }
        else if (data.currentTag == "Papir")
        {
            knife.GetComponent<Knife>()._papir = true;
        }
        else if (data.currentTag == "lightsaber")
        {
            knife.GetComponent<Knife>()._lightsaber = true;
        }
        else if (data.currentTag == "Ball")
        {
            knife.GetComponent<Knife>().SetBall();
            ballGO.SetActive(true);
        }
        else if (data.currentTag == "Arrow")
        {
            knife.GetComponent<Knife>()._arrow = true;
        }
        else if (data.currentTag == "Spear")
        {
            knife.GetComponent<Knife>()._spear = true;
        }
        else if (data.currentTag == "PoisonArrow")
        {
            knife.GetComponent<Knife>()._pArrow = true;
        }
        else if (data.currentTag == "Molot")
        {
            knife.GetComponent<Knife>()._molot = true;
        }
        else if (data.currentTag == "Acid")
        {
            knife.GetComponent<Knife>()._acid = true;
        }
        else if (data.currentTag == "WaterGun")
        {
            knife.GetComponent<Knife>()._waterGun = true;
            waterPistol.SetActive(true);
            knife.GetComponent<Image>().sprite = water;
            knife.gameObject.transform.localScale = Vector3.zero;
        }
        else if (data.currentTag == "Glue")
        {
            knife.GetComponent<Knife>()._glue = true;
        }
        else if (data.currentTag == "Molotov")
        {
            knife.GetComponent<Knife>()._molotov = true;
        }
        else if (data.currentTag == "PepperGas")
        {
            knife.GetComponent<Knife>()._pepperGas = true;
        }
        else if (data.currentTag == "SmellySock")
        {
            knife.GetComponent<Knife>()._smellySock = true;
        }
        else if (data.currentTag == "rocet")
        {
            knife.GetComponent<Knife>()._rocet = true;
        }
        else if (data.currentTag == "BananaPeel")
        {
            knife.GetComponent<Knife>()._peel = true;
        }
        else if (data.currentTag == "MagicWand")
        {
            knife.GetComponent<Knife>()._magic = true;
            magicWand.SetActive(true);
            knife.GetComponent<Image>().sprite = star;
            knife.gameObject.transform.localScale = Vector3.zero;            
        }
        else if (data.currentTag == "Word")
        {
            knife.GetComponent<Knife>()._word = true;
        }
        else if (data.currentTag == "Firework")
        {
            knife.GetComponent<Knife>()._firework = true;
        }
        else if (data.currentTag == "nuclear")
        {
            knife.GetComponent<Knife>()._nuclear = true;
        }
        else if (data.currentTag == "Ches")
        {
            knife.GetComponent<Knife>()._ches = true;
        }
        else if (data.currentTag == "Water")
        {
            knife.GetComponent<Knife>()._water = true;
        }
        else if (data.currentTag == "Forest")
        {
            knife.GetComponent<Knife>()._forest= true;
        }
        else if (data.currentTag == "Air")
        {
            knife.GetComponent<Knife>().SetAir();
        }
        else if (data.currentTag == "Godzy")
        {
            knife.GetComponent<Knife>()._godzy = true;
        }
        else if (data.currentTag == "Light")
        {
            knife.GetComponent<Knife>().SetLight();
        }
        else if (data.currentTag =="Fire")
        {
            knife.GetComponent<Knife>()._fire = true;
        }
    }
    public void ResetBlessedPartikl()
    {
        blessed.SetActive(false);
    }
    public void Bullet()
    {
        bulletParticles.SetActive(true);
    }
    public void WaterElement()
    {
        waterPartikl.SetActive(true);        
    }
    public void AcidWater()
    {
        waterPartikl.SetActive(true);
        SetPause();
        currentAnim.SetBool("Acid", true);
    }
    public void FireElement(int id = 0)
    {
        firePartikl.SetActive(true);        
        if (id == 1)
        {
            waterPartikl.SetActive(true);
            SetPause();
            currentAnim.SetBool("FireDy", true);
            ResetGreenLine();
        }
    }
    public void AirElement()
    {
        SetPause();
        currentAnim.SetBool("Attac", true);
    }
    public void AirDy()
    {
        SetPause();
        ResetGreenLine();
        currentAnim.SetBool("Dy", true);
    }
    public void IsAir()
    {
        SetPause();
        currentAnim.SetBool("Air", true);
    }
    public void Light()
    {
        SetPause();
        currentAnim.SetBool("Attac", true);
    }
    public void IsChost()
    {
        SetPause();
        currentAnim.SetBool("Attac", true);
    }
    public void LightDy()
    {
        SetPause();
        currentAnim.SetBool("Dy", true);
    }
    public void Dark()
    {

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
    public void ResetGreenLine()
    {
        greenLine.SetActive(false);
    }
    public void Fall()
    {
        bomb.SetActive(false);
        gas.SetActive(false);
        rocet.SetActive(false);
        ballPower = 2;
        waterPartikl.SetActive(false);
        firePartikl.SetActive(false);
        fireworkPartikl.SetActive(false);
        acid.SetActive(false);
        ballGO.SetActive(false);
        poop.SetActive(false);
        egg.SetActive(false);
        //arrows[currentStage].SetActive(true);
        player.LetsPlay();
        monster.LetsPlay();
        timeController.LetsPlay();
        currentAnim.SetBool("Stop", false);              
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
        ballPower = 2;
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

    #endregion
}
