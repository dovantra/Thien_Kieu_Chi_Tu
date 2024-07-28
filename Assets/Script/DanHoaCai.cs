using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Gau;

public class DanHoaCai : MonoBehaviour
{
    public Rigidbody2D rig;
    public float TocDoBay = 10;
    public float TocDo;
    public int huong = -1;
    public SpriteRenderer spR;

    public float dmg = 3;

    void Start()
    {
       

        if (transform.localPosition.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }

        TocDo = transform.localScale.x * TocDoBay * huong;
        Destroy(gameObject, 5);
        
    }
    
    private void Update()
    {
        
        rig.velocity = new Vector2(TocDo, 0f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            TocDo = 0;
            Destroy(gameObject, 0.1f);
        }
    }
}
