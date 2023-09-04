using UnityEngine;
using UnityEngine.UI;
using UniRx;

[CreateAssetMenu(menuName = "Data/UserData")]
public class UserData : ScriptableObject
{
    //public int score;    
    public IntReactiveProperty apple;
    public Sprite currentKnife;
}
