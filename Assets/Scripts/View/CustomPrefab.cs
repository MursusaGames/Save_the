using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomPrefab : MonoBehaviour
{
    public TMP_Text customName;
    public Image customImage;
    public TMP_Text customSubscribe;
    public TMP_Text customPrice;
    public Button leftArrowButton;
    public Button rightArrowButton;

    private BrainScrolling _brainScolling;

    

    public void ButtonsUnsub()
    {
        leftArrowButton.onClick.RemoveAllListeners();
        rightArrowButton.onClick.RemoveAllListeners();
    }


}
