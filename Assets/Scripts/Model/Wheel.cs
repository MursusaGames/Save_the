using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool noRotate;
           
    void FixedUpdate()
    {
        if(!noRotate) this.transform.Rotate(Vector3.forward, 1f);        
    }
}
