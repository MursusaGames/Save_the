using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotHalfs : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float speed;
    private bool isRotate;
    public bool left;
    public Vector3 startPos;
    
    private void OnEnable()
    {
        startPos = transform.localPosition;
        if (left)
        {
            rg.AddForce(Vector2.left * speed, ForceMode2D.Impulse);            
        }
        else
        {
            rg.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
        isRotate = true;        
    }
    private void OnDisable()
    {
        transform.localPosition = startPos;
    }
    private void FixedUpdate()
    {
        if (isRotate)
        {
            rg.gameObject.transform.Rotate(Vector3.forward, 30f);
        }        
    }
    
}
