using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gau_ATK : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject,1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DEF"))
        {
            Destroy(gameObject);
        }
    }

}
