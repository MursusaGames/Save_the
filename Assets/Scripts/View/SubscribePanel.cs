using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubscribePanel : MonoBehaviour
{
    [SerializeField] private CustomPrefab _panPrefab;
    [SerializeField] private CustomChoiceSystem _customSystem;
    [SerializeField] private BrainScrolling _scrollingSystem;

    private CustomPrefab _customInfoPanel;
    private const int BUYED_SKIN = 1;
    private string _zero = "0";


    private void Start()
    {
        _customInfoPanel = Instantiate(_panPrefab, transform, false);
        
    }
    public void ShowPanel(int id)
    {
        _customInfoPanel.customImage.sprite = _customSystem.customsSprites[id];
        _customInfoPanel.customPrice.text = PlayerPrefs.HasKey("PlayerSprites") && BUYED_SKIN == PlayerPrefs.GetInt("id" + id.ToString())? _zero :
            _customSystem.customsPrices[id];

        _customInfoPanel.customSubscribe.text = LocalizationSystem.GetCurrentLang() == Language.Russian ? _customSystem.customsSubscribe[id]
            : _customSystem.customsSubscribeEN[id];

        _customInfoPanel.customName.text = LocalizationSystem.GetCurrentLang() == Language.Russian ? _customSystem.customsNames[id]
            : _customSystem.customsNamesEN[id];
        
    }


    public string GetBrainName(int id )
    {
        return _customInfoPanel.customName.text = LocalizationSystem.GetCurrentLang() == Language.Russian ? _customSystem.customsNames[id]
            : _customSystem.customsNamesEN[id];
    }
        
}
