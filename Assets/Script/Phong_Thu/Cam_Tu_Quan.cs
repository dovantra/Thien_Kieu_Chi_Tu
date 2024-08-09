using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Tu_Quan : MonoBehaviour
{
    public Animator AniBom;
    public GameObject Bom;

    void Start()
    {
        
        StartCoroutine(BomOn());
        
    }

    IEnumerator BomOn()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(Bom, gameObject.transform.position, transform.rotation);
        Destroy(gameObject, 1.5f);
    }
}

