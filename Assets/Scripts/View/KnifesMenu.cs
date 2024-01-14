using UnityEngine;
using UnityEngine.UI;

public class KnifesMenu : MonoBehaviour
{
    [SerializeField] private Image knifeImg;
    [SerializeField] private MatchData data;

    private void OnEnable()
    {
        UpgradeKnifeImage();
    }
    public void UpgradeKnifeImage()
    {
        knifeImg.sprite = data.currentKnife;
    }    
}
