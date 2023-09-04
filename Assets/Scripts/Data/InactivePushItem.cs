using UnityEngine;


[CreateAssetMenu(menuName = "Data/Inactive Push Data")]
public class InactivePushItem : ScriptableObject
{
    [Header("Inactive time in seconds")]
    [SerializeField]
    private int _inactiveTime;

    [SerializeField]
    private string _titleMessage;

    [SerializeField]
    private string _textMessage;

    public int InactiveTime => _inactiveTime;
    public string TitleMessage => _titleMessage;
    public string TextMessage => _textMessage;
}
