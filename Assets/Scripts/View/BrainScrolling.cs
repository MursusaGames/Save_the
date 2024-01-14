using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrainScrolling : MonoBehaviour
{
    [Range(1, 10)]
    [Header("Contollers")]
    private int panCount;
    [Range(0, 700)]
    public int panSpace;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 5f)]
    public float scaleOffset;
    [Header("Other Objects")]
    public GameObject panPrefab;
    [SerializeField]  CustomChoiceSystem customSystem;
    //[SerializeField]  TextMeshProUGUI bayBtnText;
    [SerializeField] TextMeshProUGUI subscribeText;
    [SerializeField]  List<Image> rings;
    [SerializeField] Image bgTopText;
    [SerializeField] GameObject aplesBag;
    
    [SerializeField] GameObject bossesBag;
    [SerializeField] GameObject challengeBag;
    [SerializeField] GameObject packsBag;
    GameObject[] instPans;
    Vector2[] panPos;
    Vector2[] panScale;
    Vector2 contentVector;
    private int bossKnifes;
    private int prizeKnifes;

    RectTransform contentRect;
    int selectedPanID;
    public bool isScrolling;
    public string buyBtnTitle = "BUY";

    public ScrollRect scrollRect;    
    [SerializeField] private TextMeshProUGUI bossBagKnifeNumber;    
    
    [SerializeField] private TextMeshProUGUI prizeBagKnifeNumber;
    [SerializeField] private CustomsDataContainer bossKnife_1_Container;
    [SerializeField] private CustomsDataContainer bossKnife_2_Container;
    [SerializeField] private CustomsDataContainer prizeKnife_1_Container;
    [SerializeField] private CustomsDataContainer appleKnife_1_Container;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey(Constants.APPLE_1_DATA + 0)) PlayerPrefs.SetInt(Constants.APPLE_1_DATA + 0, 1);
    }
    private void OnDisable()
    {
        foreach (var item in instPans)
        {
            Destroy(item);
        }
    }
    private void OnEnable()
    {
        bossKnifes = 0;
        prizeKnifes = 0;
        /*if(!PlayerPrefs.HasKey(Constants.PRIZE_BAG + 0))
        {
            PlayerPrefs.SetString(Constants.PRIZE_BAG + 0, "yes");
        }*/
        panCount = 4; //System.Enum.GetValues(typeof(SkinType)).Length;       
        panScale = new Vector2[panCount];
        contentRect = GetComponent<RectTransform>();
        panPos = new Vector2[panCount];
        instPans = new GameObject[panCount];

        for (int i = 0; i < panCount; i++)
        {
            instPans[i] = Instantiate(panPrefab, transform, false);
            var panelScript = instPans[i].GetComponent<BGPrefabScript>();
            panelScript.id = i;
            switch (i)
            {
                case 0:
                    for (int j = 0; j < appleKnife_1_Container.CustomsItems.Count; j++)
                    {
                        panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.sprite = appleKnife_1_Container.CustomsItems[j].CustomSprites;
                        panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.gameObject.tag = appleKnife_1_Container.CustomsItems[j].CustomNames;
                        if (PlayerPrefs.HasKey(Constants.APPLE_1_DATA+j))
                        {
                            panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.color = Color.white;                            
                        }
                    }
                    break;                
                case 1:
                    bgTopText.color = Color.red;
                    bossBagKnifeNumber.text = PlayerPrefs.GetInt(Constants.BOSS_BAG).ToString();
                    for(int j = 0; j < bossKnife_1_Container.CustomsItems.Count; j++)
                    {
                        panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.sprite = bossKnife_1_Container.CustomsItems[j].CustomSprites;
                        panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.gameObject.tag = bossKnife_1_Container.CustomsItems[j].CustomNames;
                        if (PlayerPrefs.HasKey(Constants.BOSS_BAG+j) )
                        {
                            panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.color = Color.white;
                            panelScript.buttonsImg[j].gameObject.GetComponent<Button>().interactable = true;
                            bossKnifes++;
                        }
                        else
                        {
                            panelScript.buttonsImg[j].gameObject.GetComponent<Button>().interactable = false;
                        }
                    }
                    break;
                case 2:
                    bgTopText.color = Color.red;
                    bossBagKnifeNumber.text = PlayerPrefs.GetInt(Constants.BOSS_BAG1).ToString();
                    for (int j = 0; j < bossKnife_2_Container.CustomsItems.Count; j++)
                    {
                        panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.sprite = bossKnife_2_Container.CustomsItems[j].CustomSprites;
                        panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.gameObject.tag = bossKnife_2_Container.CustomsItems[j].CustomNames;
                        if (PlayerPrefs.HasKey(Constants.BOSS_BAG1 + j))
                        {
                            panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.color = Color.white;
                            panelScript.buttonsImg[j].gameObject.GetComponent<Button>().interactable = true;
                            bossKnifes++;
                        }
                        else
                        {
                            panelScript.buttonsImg[j].gameObject.GetComponent<Button>().interactable = false;
                        }
                    }
                    break;                
                case 3:
                    bgTopText.color = Color.cyan;
                    prizeBagKnifeNumber.text = PlayerPrefs.GetInt(Constants.PRIZE_BAG).ToString();
                    for (int j = 0; j < prizeKnife_1_Container.CustomsItems.Count; j++)
                    {
                        panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.sprite = prizeKnife_1_Container.CustomsItems[j].CustomSprites;
                        panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.gameObject.tag = prizeKnife_1_Container.CustomsItems[j].CustomNames;
                        if (PlayerPrefs.HasKey(Constants.PRIZE_BAG + j))
                        {
                            panelScript.buttonsImg[j].gameObject.GetComponent<BtnScript>().knifeImg.color = Color.white;
                            panelScript.buttonsImg[j].gameObject.GetComponent<Button>().interactable = true;
                            prizeKnifes++;
                        }
                        else
                        {
                            panelScript.buttonsImg[j].gameObject.GetComponent<Button>().interactable = false;
                        }
                    }
                    break;
            }
            if (i == 0) continue;

            var tmpX = instPans[i - 1].transform.localPosition.x + panPrefab.GetComponent<RectTransform>().sizeDelta.x/2 + panSpace;
            instPans[i].transform.localPosition = new Vector2(tmpX, instPans[i].transform.localPosition.y);
            panPos[i] = -instPans[i].transform.localPosition;
        }
        bossBagKnifeNumber.text = bossKnifes.ToString();
        prizeBagKnifeNumber.text = prizeKnifes.ToString();
    }

    private void FixedUpdate()
    {
        /*if(isScrolling && !PlayerPrefs.HasKey("SwipeHelp"))
        {
            PlayerPrefs.SetString("SwipeHelp", "Used");
            swipeHand.SetActive(false);
        }*/

        if (!isScrolling && (contentRect.anchoredPosition.x >= panPos[0].x || contentRect.anchoredPosition.x <= panPos[panPos.Length - 1].x))
        {
            scrollRect.inertia = false;
        }
            

        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - panPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanID = i;
            }

            float scale = Mathf.Clamp(1 / (distance / panSpace) * scaleOffset, .5f, 1f);
            panScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale, 10 * Time.fixedDeltaTime);
            panScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale, 10 * Time.fixedDeltaTime);
            instPans[i].transform.localScale = panScale[i];
        }

        float scrollVelosity = Mathf.Abs(scrollRect.velocity.x);

        if (scrollVelosity < 1000 && !isScrolling)
            scrollRect.inertia = false;

        if (isScrolling || scrollVelosity > 1000)
            return;

        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, panPos[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
        UpgradePanel();
    }

    public void UpgradePanel()
    {
        if (0 <= selectedPanID && 10 >= selectedPanID)
        {
            subscribeText.text = customSystem.customsSubscribe[selectedPanID];
            foreach(var ring in rings)
            {
                ring.color = Color.white;
            }
            rings[selectedPanID].color = Color.green;
            aplesBag.SetActive(selectedPanID < 1);
            bossesBag.SetActive(selectedPanID > 0 && selectedPanID < 3);
            //challengeBag.SetActive(selectedPanID > 6 && selectedPanID < 9);
            packsBag.SetActive(selectedPanID > 2);
            switch (selectedPanID){
                case 0:
                    bgTopText.color = Color.green;                    
                    break;                
                case 1:
                    bgTopText.color = Color.red;
                    //bossBagKnifeNumber.text = PlayerPrefs.GetInt(Constants.BOSS_BAG).ToString();
                    break;
                case 2:
                    bgTopText.color = Color.red;
                    //bossBagKnifeNumber.text = PlayerPrefs.GetInt(Constants.BOSS_BAG).ToString();
                    break;               
                case 3:
                    bgTopText.color = Color.cyan;
                    break;
            }
            
            


            //buyBtnImage.color = Color.yellow;
            //buyBtnImage.gameObject.GetComponent<Button>().interactable = true;

            //bayBtnText.text = PlayerPrefs.HasKey("PlayerSprites") && 1 == PlayerPrefs.GetInt("id" + selectedPanID.ToString()) ||
                //PlayerPrefs.HasKey("PlayerSprites") && 0 == selectedPanID ? "CHOICE" : buyBtnTitle;            
        }
        else
            Debug.Log("Number out of range");
    }

    public void Scroll(bool scroll)
    {
        isScrolling = scroll;

        if (scroll)
            scrollRect.inertia = true;
    }
    public void BayCustom()
    {
        customSystem.BayCustom(selectedPanID);
    }

}
