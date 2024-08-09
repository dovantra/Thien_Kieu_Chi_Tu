using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Canon_Ball : MonoBehaviour
{
    public Rigidbody2D rig;
    public float TocDoBay = 10;
    public float TocDo;
    public GameObject off;
    public Transform viTri ;
    public int huong = -1;



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
        Destroy(gameObject, 3f);


    }

    private void Update()
    {

        rig.velocity = new Vector2(TocDo, 0f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            viTri = gameObject.GetComponent<Transform>();
            TocDo = 0;
            Instantiate(off, viTri.position, transform.rotation);
            Destroy(gameObject, 0.05f);
        }
    }
}
