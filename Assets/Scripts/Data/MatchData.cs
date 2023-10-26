using UnityEngine;
using UniRx;

[CreateAssetMenu(menuName = "Data/MatchData")]
public class MatchData : ScriptableObject
{
    public LocalizationData localizationData;    
    public int appleSpawnChance;    
    public int level;
    public int levelNumber;
    public int stage;
    public int gameStage;
    public int oceanStage;
    public int fermStage;
    public int forestStage;
    public int hellStage;
    public int technoStage;
    public int numberOffKnifes;
    public int tryCount;
    public bool isGift;
    public int firstDay;
    public Sprite ringSprite;
    public Sprite bossSprite;
    public MoneyData moneyData;
    public CustomsDataContainer CustomDataContainer;
    public Sprite currentKnife;
    public string currentTag;
    public bool sound;
    public bool music;
    public bool vibro;
    public enum State
    {
        MainMenu,
        ClosingMainMenu,
        Initializing,
        StartAnimation,
        ShowQuestion,
        Question,
        EnemyQuestion,
        WaitForResult,
        Result,
        Fight,
        SetHealth,
        Movement,
        CheckHealth,
        EndGame,
        Observer,
        Finish,
        PlayerDeath,
    }
    public ReactiveProperty<State> state = new ReactiveProperty<State>(State.MainMenu);
}
