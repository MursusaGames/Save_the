using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSaver : MonoBehaviour
{
    public void ChangeSkin(int id)
    {
        if (!PlayerPrefs.HasKey("PlayerSprites"))
            for (int i = 0; i < System.Enum.GetValues(typeof(SkinType)).Length; i++)
                PlayerPrefs.SetInt("id" + i.ToString(), 0);  //0 индекс скина если он не куплен, меняются на 1 (скин куплен) 
        else
            PlayerPrefs.SetInt("id" + id.ToString(), 1);
    }
}
