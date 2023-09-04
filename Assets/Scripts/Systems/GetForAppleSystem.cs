using UnityEngine;

public class GetForAppleSystem : MonoBehaviour
{
    [SerializeField] GameObject textForSmoulBtn;
    [SerializeField] GameObject textForBigBtn;
    public MatchData _data;
    public KnifesMenu knifesMenu;
    public MainMenu mainMenu;
    public UserData data;
    [SerializeField] GameObject GetBtn;
    private BtnScript currentScript;
    private int price;
    private int lowPrice = 500;
    private int mediumPrice = 1000;
    private int hiPrice = 1500;
   

    public void SetKnife(BtnScript script)
    {
        price = script.parentId == 0 ? lowPrice : script.parentId == 1 ? mediumPrice : hiPrice;
        currentScript = script;
        GetBtn.Show();
        GetBtn.GetComponent<UnluckNowBtnScript>().knifeCost.text = price.ToString();
    }

    public void TryGetKnifeForApple( )
    {
        if (data.apple.Value < price)
        {
            var popUp = Instantiate(textForSmoulBtn, GetBtn.transform.position, Quaternion.identity, GetBtn.transform);
            Destroy(popUp, 1f);
            Invoke(nameof(ResetPopUp), 1f);
        }
        else
        {
            data.apple.Value -= price;
            switch (price)
            {
                case 500:
                    PlayerPrefs.SetInt(Constants.APPLE_1_DATA + currentScript.id, 1);
                    break;
                case 1000:
                    PlayerPrefs.SetInt(Constants.APPLE_2_DATA + currentScript.id, 1);
                    break;
                case 1500:
                    PlayerPrefs.SetInt(Constants.APPLE_3_DATA + currentScript.id, 1);
                    break;
            }
            
            currentScript.knifeImg.color = Color.white;
            data.currentKnife = currentScript.knifeImg.sprite;
            knifesMenu.UpgradeKnifeImage();
            mainMenu.knifeImg.sprite = currentScript.knifeImg.sprite;
        }
    }

    private void ResetPopUp()
    {
        GetBtn.Hide();
    }
}
