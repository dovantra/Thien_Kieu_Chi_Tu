using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] Rigidbody2D rig;
    [SerializeField] float TocDoChay = 80;
    [SerializeField] float TocDo;

    [SerializeField] Animator ani;

    [SerializeField] int huong = -1;
    [SerializeField] bool cham = false;

    [SerializeField] Transform viTri;
    [SerializeField] GameObject atk;


    void Start()
    {

        if (transform.localPosition.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);

        }

        TocDo = transform.localScale.x * TocDoChay * huong * Time.deltaTime;
        rig.velocity = new Vector2(TocDo, 0f);
    }


    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("DEF"))
        {
            StartCoroutine(ATK());
        }


    }



    IEnumerator ATK()
    {

            ani.SetBool("Off", true);
            yield return new WaitForSeconds(0.4f);
            Instantiate(atk, viTri.position, transform.rotation);
        Destroy(gameObject);


    }
}
