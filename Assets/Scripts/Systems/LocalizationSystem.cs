using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class LocalizationSystem : MonoBehaviour
{
    [SerializeField] private LocalizationObject[] _manualLocalizationObjects;
    [SerializeField] MatchData matchData;
    private static LocalizationSystem _instance;
    private LocalizationObject[] _globalLocalizationObjects;

    private void Awake()
    {
        if (_instance != null) Destroy(_instance.gameObject);
        _instance = this;
    }

    private void Start()
    {
        LocalizeEverything();

        matchData.state
           .Where(x => x == MatchData.State.ClosingMainMenu)
           .Subscribe(_ => LocalizeEverything());
    }

    private static void FindLocalizationObjects()
    {
        _instance._globalLocalizationObjects =  FindObjectsOfType<LocalizationObject>();
    }

    private static void InitialLocalizationObjects()
    {
        LocalizationData locData = _instance.matchData.localizationData;
        InitObjectsArray(_instance._globalLocalizationObjects, locData);
        InitObjectsArray(_instance._manualLocalizationObjects, locData);
    }

    private static void InitObjectsArray(LocalizationObject[] objetcsArray, LocalizationData locData)
    {
        Debug.Log(objetcsArray.Length);

        foreach (var localizationObject in objetcsArray)
        {
            if (locData.itemsDict.ContainsKey(localizationObject.Key))
                localizationObject.Init(locData.itemsDict[localizationObject.Key].dict[locData.lang.Value]);
            else
                Debug.LogError($"LocalizationSystem.InitialLocalizationObjects: Key - {localizationObject.Key} doesnt exist in data");
        }
    }

    public static void LocalizeEverything()
    {
        FindLocalizationObjects();
        InitialLocalizationObjects();
    }

    public static void SetLanguage(Language type)
    {
        _instance.matchData.localizationData.lang.Value = type;
        LocalizeEverything();
    }

    public static Language GetCurrentLang()
    {
        return _instance.matchData.localizationData.lang.Value;
    }
}
