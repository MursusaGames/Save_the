using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StageControllerSystem : MonoBehaviour
{
    [SerializeField] Transform _forcePoint;
    [SerializeField] Wheel wheel;
    [SerializeField] GameObject stagePrefabGO;
    StagePrefab stagePrefab;
    [SerializeField] GamePlaySystem playSystem;
    [SerializeField] AppleSpawnSystem spawnSystem;
    [SerializeField] List<Image> levelsIcons = new List<Image>();
    [SerializeField] List<StageInfo> stages = new List<StageInfo>();
    [SerializeField] List<Image> tryCountIcons = new List<Image>();
    [SerializeField] TextMeshProUGUI stageText;
    [SerializeField] MatchData matchData;
    [SerializeField] GameObject winWindow;
    [SerializeField] private GameObject bonusWindow;
    [SerializeField] GameObject gamePlayWindow;
    private List<Rigidbody2D> rgList = new List<Rigidbody2D>();
    int currentStage = 0;
    int tryCount = 0;
    int currentLevel = 0;
    int tryCurrentCount = 0;
    int maxLevel = 4;

    private void Awake()
    {
        currentStage = matchData.stage;
        //if (!PlayerPrefs.HasKey(Constants.STAGE))
       // {
       //     PlayerPrefs.SetInt(Constants.STAGE, 0);
        //}
        matchData.tryCount = stages[currentStage].tryCount;
        matchData.level = 0;
        
    }

    private void GetRg()
    {
        foreach(var apple in stagePrefab.apples)
        {
            var appleRg = apple.GetComponent<Rigidbody2D>();
            rgList.Add(appleRg);
        }
        foreach (var knife in stagePrefab.knifes)
        {
            var knifeRg = knife.GetComponent<Rigidbody2D>();
            rgList.Add(knifeRg);
        }
    }
    public void GetStagePrefab(StagePrefab _stagePrefab)
    {
        stagePrefab = _stagePrefab;
        spawnSystem.GetStagePrefab(_stagePrefab);
        SetStageInfo();
    }
    public void TrueTry()
    {
        tryCountIcons[tryCurrentCount].color = Color.gray;
        tryCurrentCount++;
        /*if (tryCurrentCount >= tryCount)
        {
            GetRg();
            Invoke(nameof(Explosion),0.1f);
            Invoke(nameof(WinLevel), 1.1f);
        }*/
    }

    private void Explosion()
    {
        wheel.noRotate = true;
        foreach(var rg in rgList)
        {
            rg.gravityScale = 1;
        }
        foreach (var knifeRg in playSystem.knifeRG)
        {
            knifeRg.gravityScale = 1;
            knifeRg.AddForceAtPosition(Vector2.left * Random.Range(-5f, 5f) + Vector2.up * Random.Range(1f, 5f),
                _forcePoint.position,ForceMode2D.Impulse);
        }
        stagePrefab._ring.SetActive(false);
        stagePrefab.ringTiles.SetActive(true);
    }
    private void WinLevel()
    {
        rgList.Clear();
        tryCurrentCount = 0;
        winWindow.Show();
        matchData.level++;
        matchData.tryCount++;
        Destroy(stagePrefab.gameObject);
        Instantiate(stagePrefabGO, wheel.gameObject.transform);
        playSystem.DeletKnifesInGame();
        //spawnSystem.ReloadLevel();
        playSystem.CreateKnife();
        //stagePrefab._ring.SetActive(true);
        //foreach (var rg in rgList)
        //{
        //    rg.simulated = false;
        //}
        wheel.noRotate = false;        
        
    }
    public void NewLevel()
    {
        if (currentLevel == maxLevel)
        {
            currentStage++;
            PlayerPrefs.SetInt(Constants.BOSS_BAG,currentStage);
            //PlayerPrefs.SetInt(Constants.STAGE, currentStage);
            matchData.level = 0;
            matchData.tryCount = 0;
            Debug.Log("NewStage");
            winWindow.Hide();
            bonusWindow.Show();
            return;
        }
        winWindow.Hide();
        spawnSystem.ReloadLevel();
        stagePrefab.OnEnable();
        currentLevel++;
        levelsIcons[currentLevel].color = Color.yellow;
        matchData.tryCount = 0;
        OnEnable();
        SetStageInfo();
    }
    void OnEnable()
    {
        //currentStage = PlayerPrefs.GetInt(Constants.STAGE);
        matchData.stage = currentStage;
       
        //matchData.appleSpawnChance = stages[currentStage].appleSpawnChance;
        
        //currentStage = PlayerPrefs.GetInt(Constants.STAGE);
        matchData.stage = currentStage;
        matchData.ringSprite = stages[currentStage].ring;
        matchData.bossSprite = stages[currentStage].bossSprite;
        levelsIcons[currentLevel].color = Color.yellow;
        tryCount = matchData.tryCount;
        
    }    

    public void NewStage()
    {

    }
    private void SetStageInfo()
    {
        stageText.text = "STAGE" + currentStage;
        for(int i = 0; i < tryCount; i++)
        {
            tryCountIcons[i].gameObject.Show();
            tryCountIcons[i].color = Color.white;
        }
        
    }
    

}
