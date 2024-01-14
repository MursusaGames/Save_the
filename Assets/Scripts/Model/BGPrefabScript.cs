using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGPrefabScript : MonoBehaviour
{
    public List<Image> buttonsImg;
    public int id;
    private int _id;
    void Start()
    {
        if(id <1)
        {
            foreach(var img in buttonsImg)
            {
                img.color = Color.green;
            }
        }
        else if(id > 0 && id < 3)
        {
            foreach (var img in buttonsImg)
            {
                img.color = Color.red;
            }
        }
        else if (id > 2)
        {
            foreach (var img in buttonsImg)
            {
                img.color = Color.cyan;
            }
        }       
        
        foreach (var img in buttonsImg)
        {
            img.gameObject.GetComponent<BtnScript>().parentId = id;
            img.gameObject.GetComponent<BtnScript>().id = _id;
            _id++;
        }

    }
    
}
