using UnityEngine;
using UnityEngine.UI;

public class BtnScript : MonoBehaviour
{
    public int parentId;
    public int id;
    private GetForAppleSystem getForAppleSystem;
    private GetForVideoSystem getForVideoSystem;
    private MatchData data;
    public Image knifeImg;
    private void Awake()
    {
        getForAppleSystem = FindObjectOfType<GetForAppleSystem>();        
        data = getForAppleSystem._data;
    }

    public void ClickBtn()
    {
        if(parentId < 1)
        {
            if (knifeImg.color == Color.white)
            {
                data.currentKnife = knifeImg.sprite;
                data.currentTag = knifeImg.gameObject.tag;
                getForAppleSystem.data.currentKnife = knifeImg.sprite;
                getForAppleSystem.knifesMenu.UpgradeKnifeImage();
                getForAppleSystem.mainMenu.knifeImg.sprite = knifeImg.sprite;
            }
            else
            {
                getForAppleSystem.SetSubscribe(parentId, id);
                getForAppleSystem.SetKnife(this);
                return;
            }
            
            //if (knifeImg.color != Color.white) getForAppleSystem.SetKnife(this);
            //else
            //{

            //}

        }
            
        
        if (parentId > 0 && parentId < 3)
        {
            data.currentKnife = knifeImg.sprite;
            data.currentTag = knifeImg.gameObject.tag;
            getForAppleSystem.data.currentKnife = knifeImg.sprite;
            getForAppleSystem.knifesMenu.UpgradeKnifeImage();
            getForAppleSystem.mainMenu.knifeImg.sprite = knifeImg.sprite;
        }
        if (parentId >  2)
        {
            data.currentKnife = knifeImg.sprite;
            data.currentTag = knifeImg.gameObject.tag;
            getForAppleSystem.data.currentKnife = knifeImg.sprite;
            getForAppleSystem.knifesMenu.UpgradeKnifeImage();
            getForAppleSystem.mainMenu.knifeImg.sprite = knifeImg.sprite;
        }
        getForAppleSystem.SetSubscribe(parentId, id);
        PlayerPrefs.SetString("CurentTag", data.currentTag);
        PlayerPrefs.SetInt("row", parentId);
        PlayerPrefs.SetInt("column", id);
    }
}
