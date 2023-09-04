using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    ScoreAndAppleCountSystem scoreSystem;
    [SerializeField] GameObject checkApplePrefab;
    GameObject checkApple;
    YellowApple yellowApple;
   

    private void Awake()
    {
        scoreSystem = FindObjectOfType<ScoreAndAppleCountSystem>();
    }
    private void OnEnable()
    {
        scoreSystem = FindObjectOfType<ScoreAndAppleCountSystem>();
        checkApple = Instantiate(checkApplePrefab, transform.position, Quaternion.identity,this.transform);
        yellowApple = checkApple.GetComponent<YellowApple>();
        checkApple.Hide();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife"))
        {
            scoreSystem.AddApple();
            checkApple.Show();
            yellowApple.StartFall();
            Invoke(nameof(ResetGO), 0.1f);
        }
    }
    private void ResetGO()
    {
        this.gameObject.Hide();
    }
    
}
