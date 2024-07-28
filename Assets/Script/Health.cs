using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider health;
    [SerializeField] bool cham = false;
    void Start()
    {


    }


    void Update()
    {

    }

 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK_Gau"))
        {
            cham = true;
            health.value = health.value - 5;
        }
    }
}
