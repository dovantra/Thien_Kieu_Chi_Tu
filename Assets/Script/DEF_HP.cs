using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DEF_HP : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dan_Hoa_Cai"))
        {
            health.value = health.value - 3;
        }
        if (collision.gameObject.CompareTag("Home"))
        {
            Destroy(parentGameObject);
        }
    }
}
