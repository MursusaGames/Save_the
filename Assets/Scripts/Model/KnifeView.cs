using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeView : MonoBehaviour
{
    [SerializeField] UserData userData;
    Image knifeimg;
    private void Awake()
    {
        knifeimg = GetComponent<Image>();
    }
    void Start()
    {
        knifeimg.sprite = userData.currentKnife;
    }

    
}
