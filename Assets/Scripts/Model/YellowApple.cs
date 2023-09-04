using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowApple : MonoBehaviour
{
    
    Rigidbody2D rgLeft;
    Rigidbody2D rgRight;
   
    [SerializeField] float power;
    [SerializeField] Transform leftApple;
    [SerializeField] Transform rightApple;
    Transform parent;

    private void Awake()
    {
        rgLeft = leftApple.GetComponent<Rigidbody2D>();
        rgRight = rightApple.GetComponent<Rigidbody2D>();
        parent = FindObjectOfType<Parent>().transform;
    }
    public void StartFall()
    {
        transform.SetParent(parent);
        rgLeft.AddForce(Vector2.left * power, ForceMode2D.Impulse);
        
        rgRight.AddForce(Vector2.right * power, ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }
    
}
