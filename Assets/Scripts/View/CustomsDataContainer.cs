using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomDataContainer", menuName = "Data/CustomDataContainer")]
public class CustomsDataContainer : ScriptableObject
{
    [SerializeField] private List<CustomData> _customsItems;
    public List<CustomData> CustomsItems => _customsItems;
}

