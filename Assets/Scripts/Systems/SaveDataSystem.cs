using UnityEngine;
using UniRx;

public class SaveDataSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private UserData userData;
    [SerializeField] private Sprite defoultSprite;
    [SerializeField] private GetForAppleSystem getForAppleSystem;

    private void Start()
    {
        LoadPlayerData();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            SavePlayerData();
    }

    private void OnApplicationQuit() => SavePlayerData();
    private void OnDestroy()
    {
        SavePlayerData();
    }
    public void SaveData() => SavePlayerData();

    #region LOADS
    private void SavePlayerData()
    {
        //PlayerPrefs.SetInt(Constants.STAGE, data.stage);
        
    }

   
    #endregion

    #region LOADS
    private void LoadPlayerData()
    {
        data.gameStage = PlayerPrefs.GetInt(Constants.GAMESTAGE,0);
        data.technoStage = PlayerPrefs.GetInt(Constants.TECHNOSTAGE, 0);
        data.forestStage = PlayerPrefs.GetInt(Constants.FORESTSTAGE, 0);
        data.fermStage = PlayerPrefs.GetInt(Constants.FERMSTAGE, 0);
        data.hellStage = PlayerPrefs.GetInt(Constants.HELLSTAGE, 0);
        data.oceanStage = PlayerPrefs.GetInt(Constants.OCEANSTAGE, 0);
        userData.apple.Value = PlayerPrefs.GetInt(Constants.SCORE);
        if (PlayerPrefs.HasKey("FirstDay"))
        {
            data.firstDay = PlayerPrefs.GetInt("FirstDay");
        }
        data.currentTag = PlayerPrefs.GetString("CurentTag", "Knife");
        /*data.currentKnife = defoultSprite;
        data.currentTag = "Knife";
        getForAppleSystem.data.currentKnife = defoultSprite;
        getForAppleSystem.knifesMenu.UpgradeKnifeImage();
        getForAppleSystem.mainMenu.knifeImg.sprite = defoultSprite;*/
    }
   
    #endregion
}
