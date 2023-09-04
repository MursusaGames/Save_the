using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SomeCustomsData", menuName = "Data/CustomData")]
public class CustomData : ScriptableObject
{
    
    [SerializeField] private Sprite _customSprites;
    [SerializeField] private string _customSubscribe;
    [SerializeField] private string _customNames;
    [SerializeField] private string _customSubscribeEN;
    [SerializeField] private string _customNamesEN;
    [SerializeField] private int _customPrices;

    
    public Sprite CustomSprites => _customSprites;
    public string CustomSubscribe => _customSubscribe;
    public string CustomNames => _customNames;
    public string CustomSubscribeEN => _customSubscribeEN;
    public string CustomNamesEN => _customNamesEN;
    public int CustomPrices => _customPrices;
}
