using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuMaThu : MonoBehaviour
{
    [SerializeField] Animator ani;
    [SerializeField] UnityEngine.UI.Slider health;
    [SerializeField] int hp = 50;

    void Start()
    {
        health.maxValue = hp;
        health.value = hp;
    }

    void Update()
    {
        if (health.value <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            ani.SetBool("def", true);
        }

        if (collision.gameObject.CompareTag("ATK_Gau"))
        {
            health.value = health.value - 5;
        }

        if (collision.gameObject.CompareTag("Chameleon_ATK"))
        {
            health.value = health.value - 3;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            ani.SetBool("def", false);
        }
       
    }
}
