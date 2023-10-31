using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCarrot : MonoBehaviour
{
    [SerializeField] private GameObject carrot;

    public void ShowCarrot()
    {
        carrot.SetActive(true);
    }
}
