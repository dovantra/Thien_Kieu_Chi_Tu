using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DEF_HP : MonoBehaviour
{
    // Mau cua phe tan cong

    [SerializeField] UnityEngine.UI.Slider health;
    [SerializeField] GameObject parentGameObject;
    public InFor tt;
    public string ten;
    public int damge;
    public int hp;
    void Start()
    {
        

        int currentLayer = gameObject.layer;
        string ten = LayerMask.LayerToName(currentLayer);
        var tim = tt.tableObjects.FirstOrDefault(i => i.Plant == ten);

        damge = tim.Dmg;
        hp = tim.Hp;

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
