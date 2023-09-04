using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;




public class CustomChoiceSystem : MonoBehaviour
{
    //[SerializeField] CustomsSection customSection;
    //[SerializeField] SkinSaver skinSaver;
  
    public Sprite[] customsSprites;
    public string[] customsSubscribe;
    public string[] customsNames;
    public string[] customsSubscribeEN;
    public string[] customsNamesEN;
    public string[] customsPrices;
    public int simulator1SpriteIndex;
    public int simulator2SpriteIndex;
    [SerializeField] MatchData data;

    private int _id;

    

    

    private void InitializeData()
    {
        //Через список можно нечаянно стереть данные из SO, поэтому на прямую из data
        int amount = data.CustomDataContainer.CustomsItems.Count;

        customsSprites = new Sprite[amount];
        customsSubscribe = new string[amount];
        customsNames = new string[amount];
        customsSubscribeEN = new string[amount];
        customsNamesEN = new string[amount];
        customsPrices = new string[amount];

        for (int i = 0; i < amount; i++)
        {
            customsSprites[i] = data.CustomDataContainer.CustomsItems[i].CustomSprites;
            customsSubscribe[i] = data.CustomDataContainer.CustomsItems[i].CustomSubscribe;
            customsNames[i] = data.CustomDataContainer.CustomsItems[i].CustomNames;
            customsSubscribeEN[i] = data.CustomDataContainer.CustomsItems[i].CustomSubscribeEN;
            customsNamesEN[i] = data.CustomDataContainer.CustomsItems[i].CustomNamesEN;
            customsPrices[i] = data.CustomDataContainer.CustomsItems[i].CustomPrices.ToString();
        }
    }

    public void BayCustom(int id)
    {
        _id = id;
        if(PlayerPrefs.GetInt("id" + id.ToString()) == 0) data.moneyData.CreateOrder(int.Parse(customsPrices[id]));
        else data.moneyData.CreateOrder(0);
    }
    
    /*public async UniTask BuyCustom(int id)
    {
        //data.moneyData.CreateOrder(int.Parse(customsPrices[id]));

        await UniTask.WaitUntil(() =>
            MoneyData.State.Accept == data.moneyData.state.Value ||
            MoneyData.State.Failed == data.moneyData.state.Value);

        Debug.Log(data.moneyData.state.Value);
        if (MoneyData.State.Accept == data.moneyData.state.Value)
        {
            skinSaver.ChangeSkin(id);
            PlayerPrefs.SetInt("PlayerSprites", id);
        }
        
        customSection.UpdateCoins();
        data.moneyData.state.Value = MoneyData.State.None; 
    }*/
}
