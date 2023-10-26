using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnluckNowBtnScript : MonoBehaviour
{
    public TextMeshProUGUI knifeCost;
    private void OnEnable()
    {
        Invoke(nameof(ResetGO), 3f);
    }

    private void ResetGO()
    {
        gameObject.SetActive(false);
    }
}
