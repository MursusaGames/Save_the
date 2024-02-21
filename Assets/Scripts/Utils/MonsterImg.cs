using UnityEngine.UI;
using UnityEngine;

public class MonsterImg : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private Image monster;
    void OnEnable()
    {
        monster.sprite = data.currentMonster;
    }
}
    
