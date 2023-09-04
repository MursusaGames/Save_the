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
        weaponImg.sprite = levelController.stages[currentStage].prizKnife;
        currentID = levelController.stages[currentStage].weaponID;
        PlayerPrefs.SetString(Constants.BOSS_BAG + currentID, "yes");
    }
    public void GetKnife()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
    }
}
