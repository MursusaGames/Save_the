using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GetForAppleSystem : MonoBehaviour
{
    [SerializeField] private List<BtnScript> scriptList;
    [SerializeField] private GameObject randomBtn;
    [SerializeField] GameObject textForSmoulBtn;
    [SerializeField] GameObject textForBigBtn;
    [SerializeField] private TextMeshProUGUI subscribe;
    [SerializeField] private SubscribeDataContainer subscribeData;
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
    private int appleForAD = 50;
    private int randId =20;
    //private int _randId = 20;
    //private int idCount = 0;
    private List<int> idList = new List<int>();


    public void SetKnife(BtnScript script)
    {
        price = script.parentId == 0 ? lowPrice : script.parentId == 1 ? mediumPrice : hiPrice;
        currentScript = script;
        GetBtn.Show();
        GetBtn.GetComponent<UnluckNowBtnScript>().knifeCost.text = price.ToString();
    }
    public void AddScript(BtnScript _script)
    {
        scriptList.Add(_script);
    }
    public void GetRandomWeapon()
    {
        if (data.apple.Value < 250)
        {
            var popUp = Instantiate(textForSmoulBtn, randomBtn.transform.position, Quaternion.identity, randomBtn.transform);
            Destroy(popUp, 1f);
            Invoke(nameof(ResetPopUp), 1f);
        }
        else
        {
            var id = SelectRandomId();
            if (id > 15)
            {
                return;
            }
            else
            {
                price = 250;
                currentScript = scriptList[id];
                data.apple.Value -= 250;
                PlayerPrefs.SetInt(Constant.SCORE, data.apple.Value);
                PlayerPrefs.SetInt(Constant.APPLE_1_DATA + id, 1);
                currentScript.knifeImg.color = Color.white;
                currentScript.ShowBtn();
                data.currentKnife = currentScript.knifeImg.sprite;
                knifesMenu.UpgradeKnifeImage();
                mainMenu.knifeImg.sprite = currentScript.knifeImg.sprite;
            }
        }
    }
    private int SelectRandomId()
    {
        randId = 20;
        for (int i = 0; i < 16; i++)
        {
            if (!PlayerPrefs.HasKey(Constant.APPLE_1_DATA + i))
            {
                idList.Add(i);
            }
        }
        if (idList.Count > 0)
        {
            int rand = Random.Range(0, idList.Count);
            randId = idList[rand];

        }
        idList.Clear();
        return randId;

    }
    public void SetSubscribe(int id, int index)
    {
        subscribe.text = subscribeData.CustomsItems[id].Subscribe[index];
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
            PlayerPrefs.SetInt(Constant.SCORE, data.apple.Value);
            switch (price)
            {
                case 500:
                    PlayerPrefs.SetInt(Constant.APPLE_1_DATA + currentScript.id, 1);
                    break;
                case 1000:
                    PlayerPrefs.SetInt(Constant.APPLE_2_DATA + currentScript.id, 1);
                    break;
                case 1500:
                    PlayerPrefs.SetInt(Constant.APPLE_3_DATA + currentScript.id, 1);
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
    public void GetAppleForADS()
    {
        data.apple.Value += appleForAD;
        PlayerPrefs.SetInt(Constant.SCORE, data.apple.Value);
    }
}
