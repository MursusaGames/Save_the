using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BonusWindow : MonoBehaviour
{
    [SerializeField] private Image weaponImg;
    [SerializeField] private LevelController levelController;
    private int currentStage;
    private int currentID;
    private void OnEnable()
    {
        currentStage = levelController.currentStage;
        if (currentStage == levelController.stages.Count) 
            return;
        weaponImg.sprite = levelController.stages[currentStage].prizKnife;
        currentID = levelController.stages[currentStage].weaponID;
        if (currentID < 16)
        {
            PlayerPrefs.SetString(Constants.BOSS_BAG + currentID, "yes");
        }            
        else
        {
            PlayerPrefs.SetString(Constants.BOSS_BAG1 + (currentID-16), "yes");
        }
    }
    public void GetKnife()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
    }
    public void RestartStage()
    {
        switch (levelController.thisStageName)
        {
            case "Game":
                levelController.data.gameStage =0;
                PlayerPrefs.SetInt(Constants.GAMESTAGE, 0);
                break;
            case "WildOcean":
                levelController.data.gameStage = 0;
                PlayerPrefs.SetInt(Constants.OCEANSTAGE, 0);
                break;
            case "WildFerm":
                levelController.data.gameStage = 0;
                PlayerPrefs.SetInt(Constants.FERMSTAGE, 0);
                break;
            case "WildForest":
                levelController.data.gameStage = 0;
                PlayerPrefs.SetInt(Constants.FORESTSTAGE, 0);
                break;
            case "Hell":
                levelController.data.gameStage = 0;
                PlayerPrefs.SetInt(Constants.HELLSTAGE, 0);
                break;
            case "Technopolis":
                levelController.data.gameStage = 0;
                PlayerPrefs.SetInt(Constants.TECHNOSTAGE, 0);
                break;
        }
        GetKnife();
    }
}
