using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Nuclear : MonoBehaviour
{
    [SerializeField] private Image bg;
    [SerializeField] private Image man;
    [SerializeField] private Sprite bgSprite;
    [SerializeField] private Sprite manSprite;
    [SerializeField] private GameObject plata;

    public void ChangeSprites()
    {
        bg.sprite = bgSprite;
        man.sprite = manSprite;
        plata.SetActive(true);
    }
}
