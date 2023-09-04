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
        getForVideoSystem = FindObjectOfType<GetForVideoSystem>();
        data = getForAppleSystem._data;
    }

    public void ClickBtn()
    {
        if(parentId < 1)
        {
            if (knifeImg.color != Color.white) getForAppleSystem.SetKnife(this);
            else
            {
                data.currentKnife = knifeImg.sprite;
                data.currentTag = knifeImg.gameObject.tag;
                getForAppleSystem.data.currentKnife = knifeImg.sprite;
                getForAppleSystem.knifesMenu.UpgradeKnifeImage();
                getForAppleSystem.mainMenu.knifeImg.sprite = knifeImg.sprite;
            }
                
        }
            
        if (parentId > 0 && parentId < 2)
        {
            if(knifeImg.color != Color.white) getForVideoSystem.SetKnife(this);
            else
            {
                getForAppleSystem.data.currentKnife = knifeImg.sprite;
            }                
        }
        if (parentId > 1 && parentId < 4)
        {
            data.currentKnife = knifeImg.sprite;
            data.currentTag = knifeImg.gameObject.tag;
            getForAppleSystem.data.currentKnife = knifeImg.sprite;
            getForAppleSystem.knifesMenu.UpgradeKnifeImage();
            getForAppleSystem.mainMenu.knifeImg.sprite = knifeImg.sprite;
        }
    

    }
}
