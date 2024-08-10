using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon_atk : MonoBehaviour
{
    void Start()
    {

        Destroy(gameObject,1);
    }


    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DEF"))
        {
            Destroy(gameObject);
        }
    }
}
