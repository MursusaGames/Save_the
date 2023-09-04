using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private bool isRotate;   
    private bool increace;
    private float speed;
    public bool isRevers;
    void OnEnable()
    {
        Invoke(nameof(Rotate), Random.Range(0f, 1f));
    }
    private void OnDisable()
    {
        isRotate = false;
    }

    private void Rotate()
    {
        isRotate = true;
    }
    
    void FixedUpdate()
    {
        if (isRotate)
        {
            if (this.gameObject.transform.localScale.x < 0) increace = true;
            else if (this.gameObject.transform.localScale.x > 1) increace = false;
            if(!isRevers) this.gameObject.transform.Rotate(Vector3.forward);
            else this.gameObject.transform.Rotate(Vector3.back);
            if (!increace)  this.gameObject.transform.localScale -= new Vector3(0.02f,0.02f,0.02f);
            else this.gameObject.transform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
        }
    }
}
