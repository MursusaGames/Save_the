using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class AirImg : MonoBehaviour
{
    [SerializeField] private Image weaponImg;
    [SerializeField] private MatchData data;
    [SerializeField] private Sprite bullet;
    [SerializeField] private Sprite waterBullet;
   
    void OnEnable()
    {
        if(data.currentTag == "WaterGun")
        {
            weaponImg.sprite = waterBullet;
        }
        else if (data.currentTag == "bullet")
        {
            weaponImg.sprite = bullet;
        }
        else if (data.currentTag == "silverBullet")
        {
            weaponImg.sprite = bullet;
        }
        else
        {
            weaponImg.sprite = data.currentKnife;
        }
        
    }    
}
