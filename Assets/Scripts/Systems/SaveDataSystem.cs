using UnityEngine;
using UniRx;

public class SaveDataSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private UserData userData;

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
    }
   
    #endregion
}
