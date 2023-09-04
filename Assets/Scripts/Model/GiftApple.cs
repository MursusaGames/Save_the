using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftApple : MonoBehaviour
{
    Rigidbody2D rg;
    Vector2 startPos;
    [SerializeField] float force=200;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        startPos = transform.position;
        Vector2 pos = transform.position;
        pos += new Vector2(Random.Range(-4f, 4f), 0);
        rg.AddForceAtPosition(new Vector2(Random.Range(-1f,1f), Random.Range(1f, 3f ))*force, pos);
        Invoke(nameof(Hide), 2f);
    }

    void Hide()
    {
        gameObject.transform.position = startPos;
        this.gameObject.Hide();        
    }
}
