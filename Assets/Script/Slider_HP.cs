using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_HP : MonoBehaviour
{
    public float slideSpeed = 5f; 

    void Update()
    {
        
        Vector3 slideDirection = Vector3.right; 

        
        transform.position += slideDirection * slideSpeed * Time.deltaTime;
    }
}
