using UnityEngine;

[CreateAssetMenu(menuName = "Data/StageInfo")]
public class StageInfo : ScriptableObject
{
    public int weaponID;
    public int score;
    public int stage;
    public int tryCount;
    public Sprite ring;
    public Sprite prizKnife;
    public Sprite bossSprite;
    public Sprite monsterSprite;
    public Sprite monsterHalf1;
    public Sprite monsterHalf2;
    public int id;
    public bool changeRotate;
    public int timeToEnd;
    public string monsterTag;
}
