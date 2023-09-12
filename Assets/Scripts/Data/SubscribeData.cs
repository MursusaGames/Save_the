using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SomeSubscribeData", menuName = "Data/SubscribeData")]
public class SubscribeData : ScriptableObject
{
    [SerializeField] private List<string> _subscribe;
    public List<string> Subscribe => _subscribe;
}
