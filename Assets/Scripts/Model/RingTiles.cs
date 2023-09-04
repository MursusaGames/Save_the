using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTiles : MonoBehaviour
{
    Rigidbody2D rg;
    Vector3 _forcePoint;
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        _forcePoint = FindObjectOfType<ForcePoint>().gameObject.transform.position;
    }
    void Start()
    {
        rg.AddForceAtPosition(Vector2.left * Random.Range(-5f, 5f)+Vector2.up*Random.Range(1f, 5f),_forcePoint, ForceMode2D.Impulse);
        
    }

    
}
