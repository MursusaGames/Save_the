using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyKnife : MonoBehaviour
{
    [SerializeField] List<GameObject> lights = new List<GameObject>();
    int id = 0;
    bool isGame;
    [SerializeField] float delay = 0.5f;
    private void OnEnable()
    {
        isGame = true;
        StartCoroutine(nameof(SetBlick));
    }
    private void OnDisable()
    {
        isGame = false;
    }    

    private IEnumerator SetBlick()
    {
        while (isGame)
        {
            lights[id].Show();
            if (id > 0)
            {
                lights[id-1].Hide();
            }
            id++;
            if (id == lights.Count) id = 0;

            yield return new WaitForSeconds(delay);
        }
        
    }
}
