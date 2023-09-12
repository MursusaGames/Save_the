using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SubscribeDataContainer", menuName = "Data/SubscribeDataContainer")]
public class SubscribeDataContainer : ScriptableObject
{
    [SerializeField] private List<SubscribeData> _subscribeItems;
    public List<SubscribeData> CustomsItems => _subscribeItems;
}
