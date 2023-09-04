using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePrefab : MonoBehaviour
{
    public event Action GameStart;
    [SerializeField] public List<GameObject> knifes;
    [SerializeField] public List<GameObject> apples;
    [SerializeField] public GameObject ringTiles;
    [SerializeField] public GameObject _ring;
    [SerializeField] RectTransform _knifeParent;
    private StageControllerSystem stageController;
    private TouchScreenSystem touchScreenSystem;
    public void OnEnable()
    {
        stageController = FindObjectOfType<StageControllerSystem>();
        touchScreenSystem = FindObjectOfType<TouchScreenSystem>();
        GameStart?.Invoke();
    }
    private void Start()
    {
        stageController.GetStagePrefab(this);
        touchScreenSystem.GetKnifeParent(_knifeParent);
    }
    public void DeletLevel()
    {
        for(int i = 0; i < knifes.Count; i++)
        {
            knifes[i].Hide();
        }
        for (int i = 0; i < apples.Count; i++)
        {
            apples[i].Hide();
        }
    }

    public void InitStage(int knifeCount, int appleCount, Sprite ring)
    {
        //_ring.GetComponent<Image>().sprite = ring;
        /*if(knifeCount > 0)
        {
            int rand = UnityEngine.Random.Range(1, 3);
            for(int i = 0; i< knifeCount; i++)
            {
                knifes[i + rand].Show();
            }
        }
        if(appleCount > 0)
        {
            for (int i = 0; i < appleCount; i++)
            {
                apples[i].Show();
            }
        }*/
    }
    
}
