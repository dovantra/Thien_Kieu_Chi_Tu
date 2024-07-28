using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{


    [SerializeField] UnityEngine.UI.Slider health;
    [SerializeField] GameObject parentGameObject;
    public int hp = 15;
    void Start()
    {
        health.maxValue = hp;
        health.value = hp;
        parentGameObject = transform.parent.gameObject;
    }
    private void Update()
    {
        if (health.value <= 0)
        {
            Destroy(parentGameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK_Gau"))
        {
            health.value = health.value - 5;
        }

        if (collision.gameObject.CompareTag("Chameleon_ATK"))
        {
            health.value = health.value - 3;
        }
    }
}
