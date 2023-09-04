using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHalf : MonoBehaviour
{
    private Rigidbody2D rg;
    public bool first;
    public float power;
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        if (first)
        {
            rg.AddForce(Vector2.left * power, ForceMode2D.Impulse);
        }
        else
        {
            rg.AddForce(Vector2.right * power, ForceMode2D.Impulse);
        }
    }
}
